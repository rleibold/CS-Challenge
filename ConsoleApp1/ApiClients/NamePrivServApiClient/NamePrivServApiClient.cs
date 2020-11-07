using System.ComponentModel;
using System.Net.Http;
using System.Text.Json;

namespace ConsoleApp1.ApiClients.NamePrivServApiClient
{
    public class NamePrivServApiClient : ApiClient
    {

        public NamePrivServApiClient(HttpClient httpClient, string baseUrl) : base(httpClient, baseUrl) {}

        public NamePrivServNameDTO GetNameAPI()
        {
            var nameResponse = this.MakeGetApiCall();

            return JsonSerializer.Deserialize<NamePrivServNameDTO>(nameResponse);
        }
        
    }
}