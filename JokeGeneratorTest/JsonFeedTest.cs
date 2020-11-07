using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JokeGeneratorTest
{
    [TestClass]
    public class JsonFeedTest
    {
        private const string nameGeneratorURL = "https://api.chucknorris.io/";
        private const string firstName = "Rob";
        private const string lastName = "Leibold";
        private const string category = "something";
        
        [TestMethod]
        public void GetRandomJokesTestHappyPath()
        {
            var jsonFeed = new JsonFeed(nameGeneratorURL, 0);
            string[] jokes = JsonFeed.GetRandomJokes(firstName, lastName, null);
            
            Assert.IsTrue(jokes.Length > 0);
            Assert.IsTrue(jokes[0].Contains(firstName) && jokes[0].Contains(lastName));
        }

        [TestMethod]
        public void GetCategoriesTestHappyPath()
        {
            var jsonFeed = new JsonFeed(nameGeneratorURL, 0);
            string[] categories = JsonFeed.GetCategories();

            Assert.IsTrue(categories.Length > 0);
        }

    }
}