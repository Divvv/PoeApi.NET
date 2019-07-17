using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoeApiNET.Library.Helpers
{
    public static class HttpHelper
    {
        public static string Get(string url)
        {
            do
            {
               try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json; charset=utf-8";
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                        return reader.ReadToEnd();
                    }
                }
            } catch (Exception){
                Console.WriteLine("WebException - retrying in 1 second.");
                Thread.Sleep(1000);
            } 
            } while (true);
            
        }
    }
}
