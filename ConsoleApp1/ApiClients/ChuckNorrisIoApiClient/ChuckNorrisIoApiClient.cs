using System.Collections.Immutable;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace ConsoleApp1.ApiClients.ChuckNorrisIoApiClient
{
    
    /// <summary>
    /// Class to provide a client implementation of the chucknorris.io api site
    /// </summary>
    public class ChuckNorrisIoApiClient : ApiClient
    {
        private const string categoryEndpoint = "/jokes/categories";
        private const string jokesEndpoint = "/jokes/random?";
        private const string ampersandString = "&";
        private const string categoryParameterString = "category=";

        public ChuckNorrisIoApiClient(HttpClient httpClient, string baseUrl) : base(httpClient, baseUrl) {}

        public ChuckNorrisIoCategoriesDTO GetCategoriesAPI()
        {
	         var categoriesResponse = this.MakeGetApiCall(categoryEndpoint);
	         
	         // TODO - given more time find a better way to convert this response from the Category endpoint
	         string[] categoryResponseArray = new string[] { categoriesResponse };
	         var chuckNorrisIoCategoriesDTO = new ChuckNorrisIoCategoriesDTO();
	         chuckNorrisIoCategoriesDTO.categoryList = categoryResponseArray.ToList();
	         return chuckNorrisIoCategoriesDTO;
        }
        
        public ChuckNorrisIoJokeDTO GetRandomJokeAPI(string category = null)
        {
	        var jokeResponse = this.MakeGetApiCall(jokesEndpoint + AppendCategoryParameter(category));

	        return JsonSerializer.Deserialize<ChuckNorrisIoJokeDTO>(jokeResponse);
        }

        private string AppendCategoryParameter(string category)
        {
	        string categoryParameter = "";
	        if (category != null)
	        {
		        categoryParameter += ampersandString + categoryParameterString + category;
	        }

	        return categoryParameter;
        }
    }
}