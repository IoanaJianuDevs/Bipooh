using Bipooh.Helpers;
using Bipooh.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace Bipooh.Handler
{
    public class APIRequestHandler
    {
        //documentation on api https://collegescorecard.ed.gov/data/api/
        TokenProvider tokenProvider = new TokenProvider();
        public School SearchSchoolByName(string name)
        {
            School schoolsList = new School();
            try
            {
                string apikey = tokenProvider.Get();
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("https://api.data.gov/ed/collegescorecard/v1/schools?api_key={0}&school.name={1}", apikey, name));
                httpWebRequest.Method = WebRequestMethods.Http.Get;
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
                httpWebRequest.Accept = "*/*";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                
                
                HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        string content = reader.ReadToEnd();
                        dynamic Result = JsonConvert.DeserializeObject<object>(content);
                        dynamic results = Result["results"];
                        dynamic latest = results["latest"];
                        dynamic dataResult = latest["school"];

                        if (Result != null)
                        {
                            schoolsList.Name = dataResult.name ?? "N/A";
                            schoolsList.ZipCode = dataResult.zip ?? "N/A";
                            schoolsList.City = dataResult.city ?? "N/A";
                        }
                        return schoolsList;


                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return schoolsList;
        }
    }
}
