using System.Net.Http;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JokeGeneratorTest.ApiClients.ChuckNorrisIoApiClient
{
    [TestClass]
    public class ChuckNorrisIoApiClientTest
    {
        private const string chuckNorrisApiBaseUrl = "https://api.chucknorris.io";
        private const string categoryAnimal = "animal";

        // TODO - add unit tests around AppendCategoryParameter method
        
        [TestMethod]
        public void MakeRandomJokeAPIWithNoCategoryTest() 
        {
            var chuckNorrisIoApiClient = new ConsoleApp1.ApiClients.ChuckNorrisIoApiClient.ChuckNorrisIoApiClient(new HttpClient(), chuckNorrisApiBaseUrl);

            var apiResponse = chuckNorrisIoApiClient.GetRandomJokeAPI();

            Assert.IsNotNull(apiResponse);
            Assert.IsNotNull(apiResponse.value);
        }

        [TestMethod]
        public void MakeRandomJokeAPIWithCategoryTest()
        {
            var chuckNorrisIoApiClient = new ConsoleApp1.ApiClients.ChuckNorrisIoApiClient.ChuckNorrisIoApiClient(new HttpClient(), chuckNorrisApiBaseUrl);

            var apiResponse = chuckNorrisIoApiClient.GetRandomJokeAPI(categoryAnimal);

            Assert.IsNotNull(apiResponse.id);
            Assert.IsNotNull(apiResponse.value);
        }
        
        [TestMethod]
        public void GetCategoriesAPITest() 
        {
            var chuckNorrisIoApiClient = new ConsoleApp1.ApiClients.ChuckNorrisIoApiClient.ChuckNorrisIoApiClient(new HttpClient(), chuckNorrisApiBaseUrl);

            var chuckNorrisIoCategoriesDTO = chuckNorrisIoApiClient.GetCategoriesAPI();

            Assert.IsNotNull(chuckNorrisIoCategoriesDTO.categoryList);
            Assert.IsTrue(chuckNorrisIoCategoriesDTO.categoryList.Count > 0);
        }
    }
}