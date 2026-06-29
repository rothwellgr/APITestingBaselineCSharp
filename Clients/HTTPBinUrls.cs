namespace APITestingBaselineCSharp.Clients;

public static class HTTPBinUrls
{
    public static string BaseUrl =>
        Environment.GetEnvironmentVariable("HTTPBIN_URL") ?? "https://httpbin.org";

    public const string Slideshow = "json";
    public const string Uuid = "uuid";
    public const string Anything = "anything";
}
