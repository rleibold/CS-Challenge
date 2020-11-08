using System.Net.Http;
using ConsoleApp1.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JokeGeneratorTest.Services
{
    [TestClass]
    public class JokeGeneratorServiceTest
    {
        private const string chuckNorrisApiBaseUrl = "https://api.chucknorris.io";
        private const string categoryAnimal = "animal";
        private const string firstname = "Rob";
        private const string lastname = "Leibold";
        private const string chuckNorrisName = "Chuck Norris";

        
        [TestMethod]
        public void GetRandomJokeAPIWithFirstAndLastNameNoCategoryTest() 
        {
            var jokeGeneratorService = new JokeGeneratorService(new HttpClient(), chuckNorrisApiBaseUrl, "");

            var joke = jokeGeneratorService.GetRandomJoke(firstname, lastname);
            
            Assert.IsNotNull(joke);
            Assert.IsTrue(joke.Contains(firstname + " " + lastname));
        }
        
        [TestMethod]
        public void GetRandomJokeAPIWithNoFirstNameNoLastNameNoCategoryTest() 
        {
            var jokeGeneratorService = new JokeGeneratorService(new HttpClient(), chuckNorrisApiBaseUrl, "");

            var joke = jokeGeneratorService.GetRandomJoke(null, null, null);
            
            Assert.IsNotNull(joke);
            Assert.IsTrue(joke.Contains(chuckNorrisName));
        }

        [TestMethod]
        public void GetRandomJokeAPIWithFirstNameLastNameCategoryTest() 
        {
            var jokeGeneratorService = new JokeGeneratorService(new HttpClient(), chuckNorrisApiBaseUrl, "");

            var joke = jokeGeneratorService.GetRandomJoke(firstname, lastname, categoryAnimal);
            
            Assert.IsNotNull(joke);
            Assert.IsTrue(joke.Contains(firstname + " " + lastname));
        }

        
    }
}