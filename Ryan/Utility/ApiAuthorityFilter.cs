using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using Castle.Components.DictionaryAdapter;
using Microsoft.Owin.Security;

namespace Ryan.Utility
{
    /// <summary>
    /// </summary>
    public class ApiAuthorityFilter : IAuthenticationFilter
    {
        /// <summary>
        /// </summary>
        public bool AllowMultiple { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {

            if (!context.Request.Headers.Contains("sign"))
            {
                
                context.ErrorResult = new JsonResult<object> (new { ResultStatus = 500, Message = "签名不正确" }, null,
                    Encoding.UTF8, context.Request);
            }
            else
            {
                var sign = context.Request.Headers.GetValues("sign").FirstOrDefault();
                var conent = await context.Request.Content.ReadAsStringAsync();

                if (sign != HashPassWord(conent))
                {
                     
                    context.ErrorResult = new JsonResult<object>(new { ResultStatus = 500, Message = "签名不正确" },
                        null, Encoding.UTF8, context.Request);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            await Task.Factory.StartNew(() => { });
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string HashPassWord(string message)
        {
            var md5 = new MD5CryptoServiceProvider();
            var salt = ConfigurationManager.AppSettings["appSecretKey"];
            var byt = Encoding.UTF8.GetBytes(salt + message);
            var bytHash = md5.ComputeHash(byt);
            md5.Clear();
            var sTemp = "";
            for (var i = 0; i < bytHash.Length; i++)
            {
                sTemp += bytHash[i].ToString("x").PadLeft(2, '0');
            }
            return sTemp;
        }
    }
}