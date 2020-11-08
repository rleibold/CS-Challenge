using System.Net.Http;
using System.Runtime.CompilerServices;


namespace ConsoleApp1.ApiClients
{

    /// <summary>
    /// Abstract class to be implemented by specific API client calls
    /// </summary>
    public class ApiClient
    {
        private string baseUrl;
        private HttpClient httpClient;

        /// <summary>
        /// Constructor for generic API client
        /// </summary>
        /// <param name="httpClient">Thread-safe HttpClient can be provide following Direct Injection Pattern</param>
        /// <param name="baseUrl">BaseUrl of API</param>
        public ApiClient(HttpClient httpClient, string baseUrl)
        {
            this.httpClient = httpClient;
            this.baseUrl = baseUrl;
        }

        protected string MakeGetApiCall(string specificURLAndParameters = "")
        {
            return this.httpClient.GetStringAsync(this.baseUrl + specificURLAndParameters).Result;
        }
        
    }

 
}