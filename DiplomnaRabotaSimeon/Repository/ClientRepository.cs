using GlobalClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientRepository:IDisposable
    {
        private DiplomnaRabotaEntities context;

        private bool disposed = false;

        public ClientRepository(DiplomnaRabotaEntities contextArg)
        {
            context = contextArg;
        }

        public WebServiceResult AddHealthRequest(Health client)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            Health newClient = new Health();
            Guid guid = Guid.NewGuid();
            newClient.Id = guid;
            newClient.FullName = client.FullName;
            newClient.EGN = client.EGN;
            newClient.UserId = client.UserId;
            newClient.MobilePhone = client.MobilePhone;
            newClient.Email = client.Email;
            newClient.Address = client.Address;
            newClient.DocumentNumber = client.DocumentNumber;
            newClient.IBAN = client.IBAN;
            newClient.AttachFile = client.AttachFile;
            newClient.CreatedAt = DateTime.Now;
            newClient.Company = client.Company;

            context.Healths.Add(newClient);
            context.SaveChanges();

            retVal.Result = "Клиент  " + newClient.FullName + " е добавен";

            return retVal;
        }

        public WebServiceResult AddEstateRequest(Estate client)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            Estate newClient = new Estate();
            Guid guid = Guid.NewGuid();
            newClient.Id = guid;
            newClient.FullName = client.FullName;
            newClient.EGN = client.EGN;
            newClient.MobilePhone = client.MobilePhone;
            newClient.Email = client.Email;
            newClient.Address = client.Address;
            newClient.AttachFile = client.AttachFile;
            newClient.CreatedAt = DateTime.Now;
            newClient.Company = client.Company;
            newClient.Area = client.Area;
            newClient.Kind = client.Kind;
            newClient.InsuranceAmount = client.InsuranceAmount;
            
            context.Estates.Add(newClient);
            context.SaveChanges();

            retVal.Result = "Клиент  " + newClient.FullName + " е добавен";

            return retVal;
        }

        public WebServiceResult AddAutoRequest(Auto client)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            Random rand = new Random();
            Auto newClient = new Auto();
            Guid guid = Guid.NewGuid();
            newClient.Id = guid;
            newClient.OwnerFullName = client.OwnerFullName;
            newClient.OwnerAddress = client.OwnerAddress;
            newClient.OwnerPhone = client.OwnerPhone;
            newClient.MPSModel = client.MPSModel;
            newClient.MPSNumber = client.MPSNumber;
            newClient.TrailerNumber = client.TrailerNumber;
            newClient.InsurerCompany = client.InsurerCompany;
            newClient.InsurerPolicyNumber = client.InsurerPolicyNumber;
            newClient.InsurerGreenCardNumber = client.InsurerGreenCardNumber;
            newClient.ValidFrom = client.ValidFrom;
            newClient.ValidTo = client.ValidTo;
            newClient.InsurerAgency = client.InsurerAgency;
            newClient.InsurerAddress = client.InsurerAddress;
            newClient.InsurerPhone = client.InsurerPhone;
            newClient.LeaderFullName = client.LeaderFullName;
            newClient.LeaderBornDate = client.LeaderBornDate;
            newClient.LeaderAddress = client.LeaderAddress;
            newClient.LeaderPhone = client.LeaderPhone;
            newClient.LeaderCertificate = client.LeaderCertificate;
            newClient.LeaderCategory = client.LeaderCategory;
            newClient.LeaderCertificateValidTo = client.LeaderCertificateValidTo;
            newClient.PolicyNumber = client.PolicyNumber;
            newClient.VisibleDamage = client.VisibleDamage;
            newClient.AttachFile = client.AttachFile;
            newClient.Circumstances = client.Circumstances;
            newClient.CreateDate = DateTime.Now;
            newClient.IsGuilty = client.IsGuilty;

            context.Autoes.Add(newClient);
            context.SaveChanges();

            retVal.Result = "Клиент  " + newClient.LeaderFullName + " е добавен";

            return retVal;
        }

        public List<string> GetCircumstancesById(string list)
        {
            List<string> circumstances = new List<string>();
            foreach(var item in list.Split(','))
            {
                int id = Convert.ToInt32(item);
                string temp = context.Circumstances.Where(u => u.Id == id).Select(u => u.Text).FirstOrDefault();
                circumstances.Add(temp);
            }

            return circumstances;

        }

        public WebServiceResult SendMail(string to,string subject,string body)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            using (MailMessage mm = new MailMessage("simeon.prisadov93@gmail.com", to))
            {
                mm.Subject = subject;
                mm.Body = body;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("simeon.prisadov93@gmail.com", "121212104Moni!");
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }

            retVal.Result = "Успешно изпратен имейл!";

            return retVal;
        }

        public List<Estate> GetEstateDocuments(string fullName, string company)
        {
            List<Estate> documents = new List<Estate>();
            if (fullName == "" && company == "")
            {
                documents = context.Estates.OrderByDescending(u => u.CreatedAt).ToList();
            }
            else
            {
                documents = context.Estates.Where(u => u.FullName == fullName || u.Company == company).OrderByDescending(u => u.CreatedAt).ToList();
            }
            return documents;
        }

        public List<Health> GetHealthDocuments(string fullName,string company)
        {
            List<Health> documents = new List<Health>();
            if (fullName == "" && company == "")
            {
                documents = context.Healths.OrderByDescending(u => u.CreatedAt).ToList();
            }
            else
            {
                documents = context.Healths.Where(u => u.FullName == fullName || u.Company == company).OrderByDescending(u => u.CreatedAt).ToList();
            }
            return documents;
        }

        public List<Auto> GetAutoDocuments(string fullName, string company)
        {
            List<Auto> documents = new List<Auto>();
            if (fullName == "" && company == "")
            {
                documents = context.Autoes.Where(u=> u.IsGuilty == true).OrderByDescending(u => u.CreateDate ).ToList();
            }
            else if(fullName == "" && company != "")
            {
                documents = context.Autoes.Where(u=>u.InsurerCompany == company && u.IsGuilty == true).OrderByDescending(u => u.CreateDate).ToList();
            }
            else
            {
                documents = context.Autoes.Where(u => u.LeaderFullName == fullName).OrderByDescending(u => u.CreateDate).ToList();
            }
            return documents;
        }

        public List<int> GetGuiltyDriverList()
        {
            List<Auto> documents = new List<Auto>();
            List<int> ages = new List<int>();

            documents = context.Autoes.Where(u=>u.IsGuilty==true).ToList();
            ages.Add(documents.Count);

            foreach (var item in documents)
            {
                if(DateTime.Now.Year-item.LeaderBornDate.Year>18 && DateTime.Now.Year - item.LeaderBornDate.Year < 31)
                {
                    ages.Add(item.LeaderBornDate.Year);
                }
            }

            return ages;
        }

        public double GetEstateDocumentsCount(string fullName, string company)
        {
            List<Estate> documents = new List<Estate>();
            if (fullName == "" && company == "")
            {
                documents = context.Estates.OrderByDescending(u => u.CreatedAt).ToList();
            }
            else
            {
                documents = context.Estates.Where(u => u.FullName == fullName || u.Company == company).OrderByDescending(u => u.CreatedAt).ToList();
            }
            return documents.Count;
        }

        public double GetHealthDocumentsCount(string fullName, string company)
        {
            List<Health> documents = new List<Health>();
            if (fullName == "" && company == "")
            {
                documents = context.Healths.OrderByDescending(u => u.CreatedAt).ToList();
            }
            else
            {
                documents = context.Healths.Where(u => u.FullName == fullName || u.Company == company).OrderByDescending(u => u.CreatedAt).ToList();
            }
            return documents.Count;
        }

        public double GetAutoDocumentsCount(string fullName, string company)
        {
            List<Auto> documents = new List<Auto>();
            if (fullName == "" && company == "")
            {
                documents = context.Autoes.ToList();
                return documents.Count / 2;
            }
            else if (fullName == "" && company != "")
            {
                documents = context.Autoes.Where(u => u.InsurerCompany == company && u.IsGuilty == true).ToList();
            }
            else
            {
                documents = context.Autoes.Where(u => u.LeaderFullName == fullName).ToList();
            }
            
            return documents.Count;
        }

        public Health GetHealthPolicyByFullName(string fullName)
        {
            Health document = new Health();
            document = context.Healths.Where(u => u.FullName == fullName).OrderByDescending(u => u.CreatedAt).FirstOrDefault();

            return document;
        }

        public Health GetHealthPolicyById(Guid id)
        {
            Health document = new Health();
            document = context.Healths.Where(u => u.Id == id).FirstOrDefault();

            return document;
        }

        public Estate GetEstatePolicyByFullName(string fullName)
        {
            Estate document = new Estate();
            document = context.Estates.Where(u => u.FullName == fullName).OrderByDescending(u => u.CreatedAt).FirstOrDefault();

            return document;
        }

        public Estate GetEstatePolicyById(Guid id)
        {
            Estate document = new Estate();
            document = context.Estates.Where(u => u.Id == id).FirstOrDefault();

            return document;
        }
        
        public List<Auto> GetAutoPolicyById(Guid id)
        {
            int policy =context.Autoes.Where(u => u.Id == id).FirstOrDefault().PolicyNumber;

            List<Auto> documents = new List<Auto>();
            documents = context.Autoes.Where(u => u.PolicyNumber == policy).OrderByDescending(u => u.IsGuilty).Take(2).ToList();

            return documents;
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

        ~ClientRepository()
        {
            this.Dispose(false);
        }
    }
}
