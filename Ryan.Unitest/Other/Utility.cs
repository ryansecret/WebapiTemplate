using FluentAssertions;
using NUnit.Framework;
using Ryan.Core.Utility;

namespace Ryan.Unitest.Other
{
    public class Utility
    {
        [Test]
        public void WebClientTest()
        {
            //WebClient client=new WebClient();
            //var dd= client.GetData<int[]>("http://localhost:30663/api/Values/Ryan",5).Result;
            //dd.Should().NotBeNull();
            ModelConfig.SaveSetting(new RyanSetting {CanGet = true}).Should().BeTrue();
            ModelConfig.GetSetting<RyanSetting>().CanGet.Should().BeTrue();
        }
    }
}