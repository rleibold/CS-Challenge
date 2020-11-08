using Newtonsoft.Json;

namespace ConsoleApp1.ApiClients.ChuckNorrisIoApiClient
{
    
    /// <summary>
    /// Simple Data Transfer Object to represent ChuckNorris.io Joke API response
    /// </summary>
    public class ChuckNorrisIoJokeDTO
    {
        [JsonProperty(PropertyName = "icon_url")]
        public string iconUrl { get; set; }
        
        public string id { get; set; }
        
        public string url { get; set; }
        
        public string value { get; set; }
    }
}