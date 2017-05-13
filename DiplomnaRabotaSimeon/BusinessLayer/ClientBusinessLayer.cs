using GlobalClasses;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ClientBusinessLayer
    {
        private readonly ClientRepository _userRepository;
        public ClientBusinessLayer()
        {
            _userRepository = new ClientRepository(new DiplomnaRabotaEntities());
        }

        public ClientBusinessLayer(ClientRepository clientRepository)
        {
            _userRepository = clientRepository;
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

        public WebServiceResult SendMail(string to, string subject, string body)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.SendMail(to, subject, body);

            }
            return retVal;
        }

        public WebServiceResult AddHealthRequest(Health client)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                
                string path =@"D:\recourse\health\"+client.FullName.Split(' ')[0]+client.DocumentNumber+".jpg";
                if (File.Exists(path))
                {
                    retVal.Message = "Error";
                    retVal.Result = "Този файл вече съществува!";
                }
                else
                {
                    File.WriteAllBytes(path, Convert.FromBase64String(client.AttachFile.ToString()));
                    File.Copy(path, @"C:\inetpub\wwwroot\front\images\Health\" + client.FullName.Split(' ')[0] + client.DocumentNumber + ".jpg");
                    client.AttachFile = path;

                    retVal = rep.AddHealthRequest(client);
                }
            }
            return retVal;
        }

        public WebServiceResult AddAutoRequest(Auto client)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {

                string path = @"D:\recourse\auto\" + client.LeaderFullName.Split(' ')[0] + client.PolicyNumber + ".jpg";
                if (File.Exists(path))
                {
                    retVal.Message = "Error";
                    retVal.Result = "Този файл вече съществува!";
                }
                else
                {
                    File.WriteAllBytes(path, Convert.FromBase64String(client.AttachFile.ToString()));
                    File.Copy(path, @"C:\inetpub\wwwroot\front\images\Auto\" + client.LeaderFullName.Split(' ')[0] + client.PolicyNumber + ".jpg");
                    client.AttachFile = path;

                    retVal = rep.AddAutoRequest(client);
                }
            }
            return retVal;
        }

        public List<Auto> GetAutoDocuments(string fullName, string company)
        {
            var retVal = new List<Auto>();

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetAutoDocuments(fullName,company);
            }

            return retVal;
        }

        public List<int> GetGuiltyDriverList()
        {
            var retVal = new List<int>();

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetGuiltyDriverList();
            }

            return retVal;
        }



        public List<Estate> GetEstateDocuments(string fullName, string company)
        {
            var retVal = new List<Estate>();

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetEstateDocuments(fullName, company);
            }

            return retVal;
        }

        public List<Health> GetHealthDocuments(string fullName,string company)
        {
            var retVal = new List<Health>();

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetHealthDocuments(fullName,company);
            }

            return retVal;
        }

        public double GetAutoDocumentsCount(string fullName, string company)
        {
            double retVal = 0;

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                if (rep.GetAutoDocumentsCount(fullName, company) != 0)
                {
                    retVal = 50 / (AllDocuments(fullName, company) / (rep.GetAutoDocumentsCount(fullName, company)));
                }
                
            }

            return retVal;
        }

        public double GetEstateDocumentsCount(string fullName, string company)
        {
            double retVal = 0;

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                if (rep.GetEstateDocumentsCount(fullName, company) != 0)
                {
                    retVal = 50 / (AllDocuments(fullName, company) / rep.GetEstateDocumentsCount(fullName, company));
                }
            }
            return retVal;
        }

        public double GetHealthDocumentsCount(string fullName, string company)
        {
            double retVal = 0;

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                if (rep.GetEstateDocumentsCount(fullName, company) != 0)
                {
                    retVal = 50 / (AllDocuments(fullName, company) / rep.GetHealthDocumentsCount(fullName, company));
                }
            }

            return retVal;
        }

        public double AllDocuments(string fullName, string company)
        {
            double retVal = 0;

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetHealthDocumentsCount(fullName, company)+ rep.GetEstateDocumentsCount(fullName, company)+ rep.GetAutoDocumentsCount(fullName, company);
            }

            return retVal;

        }

        public List<string> GetCircumstancesById(string list)
        {
            var retVal = new List<string>();

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetCircumstancesById(list);
            }

            return retVal;
        }

        public Health GetHealthDocumentByFullName(string fullName)
        {
            Health retVal = new Health();

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetHealthPolicyByFullName(fullName);
                //byte[] bytesInfo = File.ReadAllBytes(retVal.AttachFile);
                //string base64Info = Convert.ToBase64String(bytesInfo);
                //retVal.AttachFile = base64Info;
            }

            return retVal;
        }

        public Health GetHealthDocumentById(Guid id)
        {
            Health retVal = new Health();

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetHealthPolicyById(id);
            }

            return retVal;
        }

        public Estate GetEstateDocumentByFullName(string fullName)
        {
            Estate retVal = new Estate();

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetEstatePolicyByFullName(fullName);
            }

            return retVal;
        }

        public Estate GetEstateDocumentById(Guid id)
        {
            Estate retVal = new Estate();

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetEstatePolicyById(id);
            }

            return retVal;
        }
        
        public List<Auto> GetAutoPolicyById(Guid id)
        {
            var retVal = new List<Auto>();

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {
                retVal = rep.GetAutoPolicyById(id);
            }

            return retVal;
        }

        public WebServiceResult AddEstateRequest(Estate client)
        {
            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            using (ClientRepository rep = new ClientRepository(new DiplomnaRabotaEntities()))
            {

                string path = @"D:\recourse\estate\" + client.FullName.Split(' ')[0] + "_" + client.Area + "_" + client.InsuranceAmount + ".jpg";
                if (File.Exists(path))
                {
                    retVal.Message = "Error";
                    retVal.Result = "Този файл вече съществува!";
                }
                else
                {
                    File.WriteAllBytes(path, Convert.FromBase64String(client.AttachFile.ToString()));
                    File.Copy(path, @"C:\inetpub\wwwroot\front\images\Estate\" + client.FullName.Split(' ')[0] + "_" + client.Area + "_" + client.InsuranceAmount + ".jpg");
                    client.AttachFile = path;

                    retVal = rep.AddEstateRequest(client);
                }
            }
            return retVal;
        }
    }
}
