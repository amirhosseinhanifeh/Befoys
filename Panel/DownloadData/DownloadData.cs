using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Panel.DownloadData
{
    public class DownloadData<T> where T :class
    { 

        public static T DownloadValue(string url,string METHOD,string data,string token =null)
        {
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers[HttpRequestHeader.Authorization] = "Bearer "+token;
            string Result= client.UploadString(url,METHOD,data);
            return JsonConvert.DeserializeObject<T>(Result);
        }
    }
}
