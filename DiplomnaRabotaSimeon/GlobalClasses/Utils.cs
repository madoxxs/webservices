using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GlobalClasses
{
    public class Utils
    {
        public static object GetPropertyValueFromAnonymousObject(object source, string key)
        {
            Type t = source.GetType();
            PropertyInfo p = t.GetProperty(key);
            return p.GetValue(source, null);
        }

       

        public static string GetSessionId()
        {
            dynamic sessionId = HttpContext.Current.Request.Headers["SessionId"];
            return sessionId.ToString();
        }

        

    }
}
