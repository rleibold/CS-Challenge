
namespace ConsoleApp1.ApiClients.NamePrivServApiClient
{
    /// <summary>
    /// Simple Data Transfer Object to represent https://www.names.privserv.com/ Name API response
    /// </summary>
    public class NamePrivServNameDTO
    {
        public string name { get; set; }
        
        public string surname { get; set; }
        
        public string gender { get; set; }
        
        public string region { get; set; }
    }
}