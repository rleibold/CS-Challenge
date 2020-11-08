using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JokeGeneratorTest.ApiClients.NamePrivServApiClient
{
    
    [TestClass]
    public class NamePrivServApiClientTest
    {
        private const string namePrivServApiBaseUrl = "https://names.privserv.com/api/";

        [TestMethod]
        public void GetNameApiTest()
        {
            var namePrivServApiClient = new ConsoleApp1.ApiClients.NamePrivServApiClient.NamePrivServApiClient(new HttpClient(), namePrivServApiBaseUrl);

            var namePrivServNameDto = namePrivServApiClient.GetNameAPI();
            
            Assert.IsNotNull(namePrivServNameDto.name);
            Assert.IsNotNull(namePrivServNameDto.surname);
        }
        
        
    }
}