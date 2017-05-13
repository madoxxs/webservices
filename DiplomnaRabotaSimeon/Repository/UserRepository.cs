using GlobalClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : IDisposable
    {
        private DiplomnaRabotaEntities context;

        private bool disposed = false;

        public UserRepository(DiplomnaRabotaEntities contextArg)
        {
            context = contextArg;
        }

        public WebServiceResult Login(string name, string pass)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            var user = context.Users.Where(x => x.Name == name && x.PassHash == pass).FirstOrDefault();

            if (user == null)
            {
                retVal.Message = "Login error";
                retVal.Result = "Username not found";
            }
            else
            {
                //check is user active
                if (!user.IsEnabled)
                {
                    retVal.Message = "Login error";
                    retVal.Result = "Неактивен потребител";
                }
                
                //get the last used session by username and ip
                var session = context.Sessions.
                    Where(x => x.UserId == user.UserId).
                    OrderByDescending(o => o.ExpirationTime).
                    FirstOrDefault();

                if (session != null)
                {
                    //update the session info
                    session.StartTime = DateTime.Now;
                    session.ExpirationTime = DateTime.Now.AddDays(1);
                }
                else
                {
                    //create new session
                    session = context.Sessions.Add(new Session
                    {
                        SessionId = Guid.NewGuid(),
                        ExpirationTime = DateTime.Now.AddDays(1),
                        StartTime = DateTime.Now,
                        UserId = user.UserId
                    });
                }

                retVal.Result = new
                {
                    sessionId = session.SessionId.ToString(),
                    userId = user.UserId,
                    userName = user.Name,
                    fullName = user.FullName,
                    address = user.Address,
                    email = user.Email
                };

                context.SaveChanges();
            }
            return retVal;
        }

        public User GetuserByUserName(string userName)
        {
            User retVal = new User();
            try
            {
                // Important!
                context.Configuration.ProxyCreationEnabled = false;

                retVal = context.Users.Where(q => q.Name == userName).FirstOrDefault();
            }
            catch (Exception)
            {
                retVal = null;
            }
            return retVal;
        }

        public void UpdateUser(User user)
        {
            using (var context = new DiplomnaRabotaEntities())
            {
                context.Entry(user).State = EntityState.Modified; //System.Data.EntityState.Added; EF4
                context.SaveChanges();
            }
        }

        public WebServiceResult ForgivPassword(string userName,string email)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities());

            var user = context.Users.Where(x => x.Name == userName && x.Email == email).FirstOrDefault();

            if (user == null)
            {
                retVal.Message = "Error";
                retVal.Result = "Username and email are not found";
            }
            else
            {
                user.PassHash = "c6001d5b2ac3df314204a8f9d7a00e1503c9aba0fd4538645de4bf4cc7e2555cfe9ff9d0236bf327ed3e907849a98df4d330c4bea551017d465b4c1d9b80bcb0"; //0000
                context.SaveChanges();

                retVal.Result=rep.SendMail(email, "reset password", "Новата ви парола в системата за регистрация на авариини ситуации е 0000. Можете да е смените след като влезнете в системата!");
                
            }
            

            return retVal;

        }

        public bool Logout(int UserID)
        {
            bool retVal = true;
            try
            {
                context.Sessions.RemoveRange(context.Sessions.Where(w => w.UserId == UserID));
                context.SaveChanges();
            }
            catch (Exception)
            {

                retVal = false;
            }
            return retVal;
        }

        public bool CheckSession(Guid sessionID)
        {
            bool retVal = true;
            Session session = context.Sessions.Where(s => s.SessionId == sessionID).SingleOrDefault();
            if (session == null)
                retVal = false;
            return retVal;
        }

        public WebServiceResult NewUser(User user)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            if (context.Users.Where(u => u.Name == user.Name).Any())
            {
                retVal.Message = "NewUser error";
                retVal.Result = "Потребител с това име вече съществува";
                return retVal;
            }

            User newUser = new User();
            Guid guid = Guid.NewGuid();
            newUser.Id = guid;
            newUser.CreatedAt = DateTime.Now;
            int max = context.Users.OrderByDescending(u => u.UserId).FirstOrDefault().UserId;
            newUser.UserId =max+1;
            newUser.IsEnabled = true;
            newUser.CanChgPass = false;
            newUser.Name = user.Name;
            newUser.FullName = user.FullName;
            newUser.Address = user.Address;
            newUser.PassHash = user.PassHash;
            newUser.Email = user.Email;
            newUser.UserLastLogin = DateTime.Now;
            newUser.PassDateChng = DateTime.Now;
            newUser.ModifiedAt = DateTime.Now;

            context.Users.Add(newUser);
            context.SaveChanges();

            retVal.Result = "Потребител " + newUser.Name + " е добавен";

            return retVal;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free any other managed objects here. 
                    if (context != null)
                    {
                        context.Dispose();
                        context = null;
                    }
                }
            }

            // Free any unmanaged objects here. 

            disposed = true;
        }

        ~UserRepository()
        {
            this.Dispose(false);
        }
    }
}
   
        
