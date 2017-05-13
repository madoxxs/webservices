using BusinessLayer;
using GlobalClasses;
using Newtonsoft.Json;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DiplomnaRabotaSimeon.Controllers
{
    public class ClientsController : ApiController
    {
        [HttpGet, HttpPost, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage AddHealthRequest(HttpRequestMessage request)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();

            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {

                    string[] json = request.Content.ReadAsStringAsync().Result.Split('=');

                    Dictionary<string, string> result = new Dictionary<string, string>();
                    if (json[0] != null && json[0] == "data")
                    {
                        result = JsonConvert.DeserializeObject<Dictionary<string, string>>(HttpUtility.UrlDecode(json[1]));

                        Health client = new Health()
                        {
                            FullName = Convert.ToString(result["fullName"]),
                            EGN = Convert.ToString(result["EGN"]),
                            MobilePhone = Convert.ToString(result["mobilePhone"]),
                            Email = Convert.ToString(result["email"]),
                            Address = Convert.ToString(result["address"]),
                            DocumentNumber = Convert.ToInt32(result["documentNumber"]),
                            IBAN = Convert.ToString(result["iban"]),
                            UserId = Convert.ToInt32(result["userId"]),
                            AttachFile = Convert.ToString(result["attachFile"]),
                            Company = Convert.ToString(result["company"])
                        };
                        retVal = bl.AddHealthRequest(client);
                    }
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpPost, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage AddAutoRequest(HttpRequestMessage request)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();

            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    string[] json = request.Content.ReadAsStringAsync().Result.Split('=');

                    Dictionary<string, string> result = new Dictionary<string, string>();
                    if (json[0] != null)
                    {
                        result = JsonConvert.DeserializeObject<Dictionary<string, string>>(HttpUtility.UrlDecode(json[1]));

                        Auto client = new Auto()
                        {
                            OwnerFullName = Convert.ToString(result["OwnerFullName"]),
                            OwnerAddress = Convert.ToString(result["OwnerAddress"]),
                            OwnerPhone = Convert.ToString(result["OwnerPhone"]),
                            MPSModel = Convert.ToString(result["MPSModel"]),
                            MPSNumber = Convert.ToString(result["MPSNumber"]),
                            TrailerNumber = (result.ContainsKey("TrailerNumber")) ? (Convert.ToString(result["TrailerNumber"])) : null,
                            InsurerCompany = Convert.ToString(result["InsurerCompany"]),
                            InsurerPolicyNumber = Convert.ToString(result["InsurerPolicyNumber"]),
                            InsurerGreenCardNumber = Convert.ToString(result["InsurerGreenCardNumber"]),
                            ValidFrom = Convert.ToDateTime(result["ValidFrom"]).Date,
                            ValidTo = Convert.ToDateTime(result["ValidTo"]).Date,
                            InsurerAgency = Convert.ToString(result["InsurerAgency"]),
                            InsurerAddress = Convert.ToString(result["InsurerAddress"]),
                            InsurerPhone = Convert.ToString(result["InsurerPhone"]),
                            LeaderFullName = Convert.ToString(result["LeaderFullName"]),
                            LeaderBornDate = Convert.ToDateTime(result["LeaderBornDate"]).Date,
                            LeaderAddress = Convert.ToString(result["LeaderAddress"]),
                            LeaderPhone = Convert.ToString(result["LeaderPhone"]),
                            LeaderCertificate = Convert.ToInt32(result["LeaderCertificate"]),
                            LeaderCategory = Convert.ToString(result["LeaderCategory"]),
                            LeaderCertificateValidTo = Convert.ToDateTime(result["LeaderCertificateValidTo"]).Date,
                            PolicyNumber = Convert.ToInt32(result["PolicyNumber"]),
                            VisibleDamage = Convert.ToString(result["VisibleDamage"]),
                            AttachFile = Convert.ToString(result["AttachFile"]),
                            Circumstances = Convert.ToString(result["Circumstances"]),
                            IsGuilty = Convert.ToBoolean(result["IsGuilty"])
                        };
                        retVal = bl.AddAutoRequest(client);

                    }
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpPost, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage AddEstateRequest(HttpRequestMessage request)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();

            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {

                    string[] json = request.Content.ReadAsStringAsync().Result.Split('=');

                    Dictionary<string, string> result = new Dictionary<string, string>();
                    if (json[0] != null && json[0] == "data")
                    {
                        result = JsonConvert.DeserializeObject<Dictionary<string, string>>(HttpUtility.UrlDecode(json[1]));

                        Estate client = new Estate()
                        {
                            FullName = Convert.ToString(result["fullName"]),
                            EGN = Convert.ToString(result["EGN"]),
                            Kind = Convert.ToString(result["kind"]),
                            MobilePhone = Convert.ToString(result["mobilePhone"]),
                            Email = Convert.ToString(result["email"]),
                            Address = Convert.ToString(result["address"]),
                            Area = Convert.ToInt32(result["area"]),
                            InsuranceAmount = Convert.ToDouble(result["amount"]),
                            AttachFile = Convert.ToString(result["attachFile"]),
                            Company = Convert.ToString(result["company"])
                        };
                        retVal = bl.AddEstateRequest(client);
                    }
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };

            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetAutoDocuments(string fullName = "", string company = "")
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetAutoDocuments(fullName, company);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetEstateDocuments(string fullName = "", string company = "")
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetEstateDocuments(fullName, company);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetHealthDocuments(string fullName = "", string company = "")
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetHealthDocuments(fullName, company);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetHealthDocumentByFullName(string fullName)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetHealthDocumentByFullName(fullName);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetHealthDocumentById(string id)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetHealthDocumentById(new Guid(id));
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetEstateDocumentByFullName(string fullName)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetEstateDocumentByFullName(fullName);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetEstateDocumentById(string id)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetEstateDocumentById(new Guid(id));
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }
        
        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetAutoPolicyById(Guid id)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetAutoPolicyById(id);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }


        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetCircumstancesById(string list)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetCircumstancesById(list);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetAutoDocumentsCount(string fullName = "", string company = "")
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetAutoDocumentsCount(fullName, company);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetEstateDocumentsCount(string fullName = "", string company = "")
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetEstateDocumentsCount(fullName, company);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetHealthDocumentsCount(string fullName = "", string company = "")
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetHealthDocumentsCount(fullName, company);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage GetGuiltyDriverList()
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.GetGuiltyDriverList();
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage AllDocuments(string fullName = "", string company = "")
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    retVal.Result = bl.AllDocuments(fullName, company);
                }

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage SendMail(string to, string subject, string body)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            ClientBusinessLayer bl = new ClientBusinessLayer();
            try
            {
                retVal.Result = bl.SendMail(to, subject, body);
                

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                return new HttpResponseMessage(status)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(ex), Encoding.UTF8, "application/json")
                };
            }
        }

    }
}
