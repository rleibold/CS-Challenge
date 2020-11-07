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
        static string _url = ""; // TODO - Should not be static, should be private

        public JsonFeed() { }
        public JsonFeed(string endpoint, int results) //TODO Extra parameter in constructor to be removed or implemented
        {
            _url = endpoint;
        }
        
		public static string[] GetRandomJokes(string firstname, string lastname, string category) // TODO- Does not need to be static
		{
			HttpClient client = new HttpClient(); // TODO - this could be injected into the constructor in order to help with mocking?
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

            string joke = Task.FromResult(client.GetStringAsync(url).Result).Result; // TODO - redundant call to Result

            if (firstname != null && lastname != null)
            {
                int index = joke.IndexOf("Chuck Norris");
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
		public static dynamic Getnames() // TODO Does not need to be static, loosely typed return object could be error prone
		{
			// TODO Implement using: https://www.names.privserv.com/api/
			// This method should not be part of this class and should be in it's own class
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_url);
			var result = client.GetStringAsync("").Result;
			return JsonConvert.DeserializeObject<dynamic>(result);
		}

		public static string[] GetCategories() // TODO Does not need to be static
		{
			// TODO - this method does not work correctly - needs to be fixed with /jokes/categories appended to url
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_url);

			return new string[] { Task.FromResult(client.GetStringAsync("categories").Result).Result };
		}
    }
}
