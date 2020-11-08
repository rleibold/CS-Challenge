using System.Collections.Generic;
using System.Net.Http;
using ConsoleApp1.ApiClients.ChuckNorrisIoApiClient;
using ConsoleApp1.ApiClients.NamePrivServApiClient;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// This class will be responsible for the joke generation logic
    /// </summary>
    public class JokeGeneratorService
    {
        private const string chuckNorrisName = "Chuck Norris";
        
        private ChuckNorrisIoApiClient chuckNorrisIoApiClient;
        private NamePrivServApiClient namePrivServApiClient;
        
        public JokeGeneratorService(HttpClient httpClient, string chuckNorrisBaseUrl, string namePrivServBaseUrl)
        {
            chuckNorrisIoApiClient = new ChuckNorrisIoApiClient(httpClient, chuckNorrisBaseUrl);
            namePrivServApiClient = new NamePrivServApiClient(httpClient, namePrivServBaseUrl);
        }

        public string GetRandomJoke(string firstname, string lastname, string category = null)
        {
            var chuckNorrisIoJokeDTO = chuckNorrisIoApiClient.GetRandomJokeAPI(category);

            var jokeString = chuckNorrisIoJokeDTO.value;
            if (firstname != null && lastname != null)
            {
                return jokeString.Replace(chuckNorrisName, firstname + " " + lastname);
            }
            else
            {
                return jokeString;
            }
        }

        public List<string> GetCategories()
        {
            var chuckNorrisIoCategoriesDto = chuckNorrisIoApiClient.GetCategoriesAPI();
            return chuckNorrisIoCategoriesDto.categoryList;
        }
        
        public string GetRandomName()
        {
            var namePrivServNameDTO =  namePrivServApiClient.GetNameAPI();
            return namePrivServNameDTO.name + " " + namePrivServNameDTO.surname;
        }
    }
}