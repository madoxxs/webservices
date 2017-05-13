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
    public class UsersController : ApiController
    {
        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage ForgivPassword(string userName, string email)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };

            try
            {
                UserBusinessLayer bl = new UserBusinessLayer();
                retVal = bl.ForgivPassword(userName, email);

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                if (retVal.Message != "OK")
                    return new HttpResponseMessage(status)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                    };
                else
                    return new HttpResponseMessage(status)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(retVal.Result), Encoding.UTF8, "application/json")
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
        public HttpResponseMessage Login(string user, string pass)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            
            try
            {
                UserBusinessLayer bl = new UserBusinessLayer();
                retVal = bl.Login(user, pass);

                var status = HttpStatusCode.OK;
                if (retVal.Message != "OK")
                    status = HttpStatusCode.InternalServerError;
                if (retVal.Message != "OK")
                    return new HttpResponseMessage(status)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(retVal), Encoding.UTF8, "application/json")
                    };
                else
                    return new HttpResponseMessage(status)
                    {
                        Content = new StringContent(JsonConvert.SerializeObject(retVal.Result), Encoding.UTF8, "application/json")
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

        [HttpPost, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage NewUser(HttpRequestMessage request)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            UserBusinessLayer bl = new UserBusinessLayer();

            try
            {
                
                    string[] json = request.Content.ReadAsStringAsync().Result.Split('=');

                    Dictionary<string, string> result = new Dictionary<string, string>();
                    if (json[0] != null && json[0] == "data")
                    {
                        result = JsonConvert.DeserializeObject<Dictionary<string, string>>(HttpUtility.UrlDecode(json[1]));


                       
                        User user = new User()
                        {
                            Name = Convert.ToString(result["Name"]),
                            FullName = Convert.ToString(result["FullName"]),
                            Address = Convert.ToString(result["Address"]),
                            PassHash = Convert.ToString(result["PassHash"]),
                            Email = Convert.ToString(result["Email"])
                        };
                        retVal = bl.AddUser(user);
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

        [HttpPost, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage UpdateUser(HttpRequestMessage requestUpdate)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            UserBusinessLayer bl = new UserBusinessLayer();

            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    string[] json = requestUpdate.Content.ReadAsStringAsync().Result.Split('=');

                    Dictionary<string, string> result = new Dictionary<string, string>();
                    if (json[0] != null && json[0] == "data")
                    {
                        result = JsonConvert.DeserializeObject<Dictionary<string, string>>(HttpUtility.UrlDecode(json[1]));
                        retVal = bl.UpdateUser(result);
                    }
                    else
                    {
                        retVal = new WebServiceResult() { Message = "POST request parameters error!", Result = "No 'data' parameter" };
                    }
                }
            }

            catch (Exception ex)
            {
                retVal = new WebServiceResult() { Message = "POST request parameters error!", Result = String.Format("Message: {0}, StackTrace: {1}", ex.Message, ex.StackTrace) };
            };

            HttpStatusCode status = HttpStatusCode.OK;
            if (retVal.Message != "OK")
                status = HttpStatusCode.InternalServerError;
            return Request.CreateResponse(status, retVal);

        }

        [HttpGet, HttpOptions]
        [EnableCors("*", "*", "*")]
        public HttpResponseMessage Logout(int userId)
        {
            if (Request.Method == HttpMethod.Options)
                return new HttpResponseMessage(HttpStatusCode.OK);

            WebServiceResult retVal = new WebServiceResult() { Message = "OK", Result = "" };
            UserBusinessLayer bl = new UserBusinessLayer();
            try
            {
                if (!bl.CheckSession(new Guid(Utils.GetSessionId())))
                {
                    retVal.Message = "Session error";
                    retVal.Result = "Invalid session";
                }
                else
                {
                    
                    retVal = bl.Logout(userId);
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
    }
}
