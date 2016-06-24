using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ryan.Utility
{
    public static class WebClientEx
    {
        public static async Task<T> GetData<T>(this WebClient client,string url, object param, string contentType= "application/json")
        {
           
            client.Headers.Add("Content-Type",contentType);
            string data = await client.UploadStringTaskAsync(url,JsonConvert.SerializeObject(param));
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}