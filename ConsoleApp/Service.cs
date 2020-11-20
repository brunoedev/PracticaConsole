using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Service
    {
        string EndPoint1 = ConfigurationManager.AppSettings.Get("endPoint1");
        string EndPoint2 = ConfigurationManager.AppSettings.Get("endPoint2");
        public List<Empleado> GetList()
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = EndPoint1;
                    var json = webClient.DownloadString("v1/employees");
                    var obj = JsonConvert.DeserializeObject<RequestObject>(json);
                    return obj.data.ToList();
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public string Save(Empleado obj)
        {
            //string result = "";
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = EndPoint2;
                    var url = "Empleado";
                    webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(obj);
                    var response = webClient.UploadString(url, data);
                    //result = JsonConvert.DeserializeObject<string>(response);
                    return response;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
