using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            
                using (var client = new HttpClient())
            {
                string endpoint = "http://192.168.43.28/simeoneService/api/Users/ForgivPassword?userName=simeon&email=simeon.prisadov93@gmail.com";
                //string endpoint = "http://192.168.4.147/simeoneService/api/Users/NewUser";
                //string endpoint= "http://192.168.4.147/simeoneService/api/Users/UpdateUser";
                //string endpoint = "http://192.168.4.147/simeoneService/api/Clients/GetHealthDocumentsCount?company=Bulins";
                //string endpoint = "http://192.168.4.147/simeoneService/api/Users/ForgivPassword?userName=simeon&email=madoxxs77@mail.bg";

                client.BaseAddress = new Uri(endpoint);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("SessionId", "9EDED262-12BE-42AF-A2CD-9F32C1753709");

                ////Post request

                //var content = new FormUrlEncodedContent(new[]
                //    {
                //        new KeyValuePair<string, string>(
                //             "data",
                //              "{'PassHash':'ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413','FullName':'simeon simeon','Name':'simeon','Email':'simeon_pri@abv.bg','Address':'simeon'}") });

                //var response = client.PostAsync(endpoint, content).Result;

                //Get request
                var response = client.GetAsync(endpoint).Result;

                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                //Console.ReadKey();
            }
            }
    }
}
