using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ryan.Utility
{ 
    public static class WebClientEx
    {
        public static async Task<T> GetData<T>(this WebClient client,string url, object param, string contentType= "application/json")
        {
            try
            { 
                client.Headers.Add("Content-Type", contentType);
                string data = await client.UploadStringTaskAsync(url, contentType == ContentType.JsonType ? JsonConvert.SerializeObject(param) : param.ToString());
                return JsonConvert.DeserializeObject<T>(data);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public static async  Task<HttpResponseMessage> GetResponse(this string url, object param, string contentType = "application/json")
        {
             MediaTypeFormatter typeFormater=new JsonMediaTypeFormatter();
            if (contentType==ContentType.FormUrlEncode)
            {
                 typeFormater=new FormUrlEncodedMediaTypeFormatter();
            }
             HttpClient client=new HttpClient();
             HttpContent httpContent = new ObjectContent(param.GetType(),param, typeFormater);
             var response=await  client.PostAsync(url, httpContent);
             return response;
            //HttpWebRequest request = WebRequest.CreateHttp(url);
            //request.Method = WebRequestMethods.Http.Post;
            //request.ContentType = contentType;
            //using (var stream = request.GetRequestStream())
            //{
            //    byte[] buffer = new byte[1024 * 5];
            //    if (contentType == ContentType.JsonType)
            //    {
            //        buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(param));
            //    }

            //    stream.Write(buffer, 0, buffer.Length);
            //}
            //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //return response;
        }
    }

    public class ContentType
    {
        public const string JsonType = "application/json";

        public const string FormUrlEncode = "application/x-www-form-urlencoded";
    }
}