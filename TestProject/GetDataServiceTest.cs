using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using RichardSzalay.MockHttp;
using TestingClasses.Services;

namespace TestProject
{
    [TestClass]
    public class GetDataServiceTest
    {
        private GetDataService _getDataService;

        [TestMethod]
        public void GetTrainerInfoTest()
        {
            var mockHttp = new MockHttpMessageHandler();
            // Setup a respond for the user api (including a wildcard in the URL)
            mockHttp.When("https://vps255073.ovh.net/api/userData")
        .Respond("application/json", "{'id':'22','frontName':'Wiktor Teściak','email':'trener121@szkola.pl','phoneNumber':'null','pesel':'11111111111','readableAdress':'ul.Walcowa 22a Wałbrzych','avatar':'null','city':'Wałbrzych'}");

            var httpClient = new HttpClient(mockHttp);
            httpClient.BaseAddress = new Uri("https://vps255073.ovh.net/api/userData");
            
            var result = _getDataService.GetTrainerInfo(httpClient).Result;

            Assert.AreEqual("trener121@szkola.pl", result.Email);
        }

    }
}
