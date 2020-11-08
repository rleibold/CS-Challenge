using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class JsonFeed // Updated to public to allow for unit testing
    {
	    // TODO - Should not be static, and should be private, this will cause issues for multiple instances
	    // of JsonFeed running in the same application as they will all share the same _url variable 
	    // Not Thread safe
	    static string _url = "";  

        public JsonFeed() { }
        public JsonFeed(string endpoint, int results) //TODO - results parameter in constructor to be removed or implemented
        {
            _url = endpoint;
        }
        
        [Obsolete("GetRandomJokes method is deprecated.  Please use JokeGeneratorService.GetRandomJoke()")]
        public static string[] GetRandomJokes(string firstname, string lastname, string category) // TODO- Does not need to be static
		{
			// TODO - this could be injected into the constructor in order to help with mocking
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_url);
			string url = "jokes/random";
			if (category != null)
			{
				if (url.Contains('?'))
					url += "&";
				else url += "?";
				url += "category=";
				url += category;
			}

            string joke = Task.FromResult(client.GetStringAsync(url).Result).Result;

            if (firstname != null && lastname != null)
            {
                int index = joke.IndexOf("Chuck Norris"); // TODO - overly complicated, this could be simplified using .Replace() method
                string firstPart = joke.Substring(0, index);
                string secondPart = joke.Substring(0 + index + "Chuck Norris".Length, joke.Length - (index + "Chuck Norris".Length));
                joke = firstPart + " " + firstname + " " + lastname + secondPart;
            }

            return new string[] { JsonConvert.DeserializeObject<dynamic>(joke).value };
        }

        /// <summary>
        /// returns an object that contains name and surname
        /// </summary>
        /// <param name="client2"></param>
        /// <returns></returns>
        [Obsolete("Getnames method is deprecated.  Please use JokeGeneratorService.GetRandomName()")]
        public static dynamic Getnames() // TODO Does not need to be static, loosely typed return object could be error prone
		{
			// TODO Implement using: https://www.names.privserv.com/api/
			// This method should not be part of this class and should be in it's own class
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_url);
			var result = client.GetStringAsync("").Result;
			return JsonConvert.DeserializeObject<dynamic>(result);
		}

		[Obsolete("GetCategories method is deprecated.  Please use JokeGeneratorService.GetCategories()")]
        public static string[] GetCategories() // TODO Does not need to be static
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_url);

			return new string[] { Task.FromResult(client.GetStringAsync("categories").Result).Result };
		}
    }
}
