using APITestingBaselineCSharp.DTOs;
using Newtonsoft.Json;
using RestSharp;

namespace APITestingBaselineCSharp.Clients;

/// <summary>
/// Authenticator not required for HTTPBin. Returns DTOs for ease of object transport. 
/// </summary>
/// <param name="endPoint">The end of the endpoint eg. "json" in https://httpbin.org/json</param>
public class HTTPBinClient(string endPoint) : IDisposable
{
    readonly RestClient _client = new();
    readonly RestRequest _request = new RestRequest("https://httpbin.org/" + endPoint).AddHeader("accept", "application/json");

    public async Task<SlideshowDTO> GetSlideshow()
    {
        var response = await _client.GetAsync(_request);

        var deserialise = JsonConvert.DeserializeObject<SlideshowDTO>(response.Content
         ?? throw new NullReferenceException("Null reference getting json content."))
         ?? throw new NullReferenceException("Null reference deserializing json.");
        return deserialise;
    }

    public void Dispose()
    {
        _client?.Dispose();
        GC.SuppressFinalize(this);
    }
}