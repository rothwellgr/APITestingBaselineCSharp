using Newtonsoft.Json;
using RestSharp;

namespace APITestingBaselineCSharp.Clients;

public class Get : IClient
{
    public RestClient RestClient { get; } = new(new RestClientOptions { Timeout = TimeSpan.FromSeconds(30) });

    public async Task<T> Send<T>(string endpoint)
    {
        var request = new RestRequest($"{HTTPBinUrls.BaseUrl}/{endpoint}")
            .AddHeader("accept", "application/json");

        HTTPHelpers.Log($"GET {HTTPBinUrls.BaseUrl}/{endpoint}");
        var response = await HTTPHelpers.Request(RestClient, request);
        HTTPHelpers.Log($"response {(int)response.StatusCode}");
        HTTPHelpers.HandleResponse(response);

        return JsonConvert.DeserializeObject<T>(response.Content
         ?? throw new NullReferenceException("Null reference getting json content."))
         ?? throw new NullReferenceException("Null reference deserializing json.");
    }

    public void Dispose()
    {
        RestClient?.Dispose();
        GC.SuppressFinalize(this);
    }
}
