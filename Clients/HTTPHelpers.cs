using RestSharp;

namespace APITestingBaselineCSharp.Clients;

public static class HTTPHelpers
{
    public static void Log(string message) =>
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] [{TestContext.CurrentContext.WorkerId}] [{TestContext.CurrentContext.Test.Name}] -> {message}");

    public static async Task<RestResponse> Request(RestClient client, RestRequest request) =>
        await client.ExecuteAsync(request);

    public static void HandleResponse(RestResponse response)
    {
        if ((int)response.StatusCode == 0)
            throw new HttpRequestException("Request timed out after 20 seconds.");

        if ((int)response.StatusCode == 503)
            throw new HttpRequestException("HTTPBin returned 503 Service Temporarily Unavailable. Try again later.");

        if (!response.IsSuccessful)
            throw new HttpRequestException($"HTTPBin returned {(int)response.StatusCode}.");
    }
}
