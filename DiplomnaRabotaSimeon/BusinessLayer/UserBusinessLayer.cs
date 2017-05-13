using GlobalClasses;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace BusinessLayer
{
    public class UserBusinessLayer
    {
        private readonly UserRepository _userRepository;
        public UserBusinessLayer()
        {
            _userRepository = new UserRepository(new DiplomnaRabotaEntities());
        }

        public UserBusinessLayer(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public WebServiceResult ForgivPassword(string userName, string email)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            using (UserRepository rep = new UserRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.ForgivPassword(userName, email);
            }

            return retVal;
        }

        public WebServiceResult Login(string name, string pass)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            using (UserRepository rep = new UserRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.Login(name, pass);
            }

            if (retVal.Result.ToString() != "Username not found")
            {
                int? userId = Convert.ToInt32(Utils.GetPropertyValueFromAnonymousObject(retVal.Result, "userId"));
                Guid? sessionId = new Guid(Utils.GetPropertyValueFromAnonymousObject(retVal.Result, "sessionId").ToString());
                string userName = Utils.GetPropertyValueFromAnonymousObject(retVal.Result, "userName").ToString();
                string fullName = Utils.GetPropertyValueFromAnonymousObject(retVal.Result, "fullName").ToString();
                string address = Utils.GetPropertyValueFromAnonymousObject(retVal.Result, "address").ToString();
                string email = Utils.GetPropertyValueFromAnonymousObject(retVal.Result, "email").ToString();

                retVal.Result = new
                {
                    userId = userId,
                    sessionId = sessionId,
                    userName = userName,
                    firstName = fullName.Split(' ')[0],
                    lastName = fullName.Split(' ')[1],
                    address = address,
                    email = email
                };
            }

            return retVal;
        }

        public WebServiceResult UpdateUser(Dictionary<string, string> formData)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            using (UserRepository rep = new UserRepository(new DiplomnaRabotaEntities()))
            {
                User user = rep.GetuserByUserName(formData["oldUserName"]);

                user.PassHash = (formData.ContainsKey("PassHash") && formData["PassHash"] != "") ? formData["PassHash"] : user.PassHash;
                user.FullName = (formData.ContainsKey("FullName") && formData["FullName"] != "") ? formData["FullName"] : user.FullName;
                user.Address = (formData.ContainsKey("Address") && formData["Address"] != "") ? formData["Address"] : user.FullName;
                user.Email = (formData.ContainsKey("Email") && formData["Email"] != "") ? formData["Email"] : user.FullName;
                user.ModifiedAt = DateTime.Now;
                rep.UpdateUser(user);
            }
            return retVal;
        }


        public WebServiceResult Logout(int userId)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            using (UserRepository rep = new UserRepository(new DiplomnaRabotaEntities()))
            {
                if (!rep.Logout(userId))
                {
                    retVal.Message = "Logout error";
                    retVal.Result = "Logout error";
                }
            }
            return retVal;
        }

        public WebServiceResult AddUser(User user)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            using (UserRepository rep = new UserRepository(new DiplomnaRabotaEntities()))
            {

                retVal = rep.NewUser(user);
            }
            return retVal;

        }

        public bool CheckSession(Guid sessionID)
        {
            bool retVal = true;
            using (UserRepository rep = new UserRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.CheckSession(new Guid(Utils.GetSessionId()));
            }

            return retVal;
        }
    }
}
