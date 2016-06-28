using System.Net;
using FluentAssertions;
using NUnit.Framework;
using Ryan.Application.Models;
using Ryan.Utility;

namespace Ryan.Unitest.Other
{
    public class Utility
    {
        [Test]
        public void WebClientTest()
        {
            var response= "http://localhost:6666/api/Ryan/KickBall".GetResponse(new Ball() {Name = "adsf"}).Result;
            if (response.StatusCode==HttpStatusCode.OK)
            {
                true.Should().BeTrue();
            }
            else
            {
              
                true.Should().BeFalse("请求失败");
            }
            //WebClient client = new WebClient();

            //var dd = client.GetData<int[]>("http://localhost:6666/api/Ryan/KickBall", new Ball() {Name ="adsf"}).Result;
            //dd.Should().NotBeNull();

            //ModelConfig.SaveSetting(new RyanSetting {CanGet = true}).Should().BeTrue();
            //ModelConfig.GetSetting<RyanSetting>().CanGet.Should().BeTrue();
        }
    }
}