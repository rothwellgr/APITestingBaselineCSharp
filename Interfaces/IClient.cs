using RestSharp;

namespace APITestingBaselineCSharp.Interfaces;

public interface IClient : IDisposable
{
    RestClient RestClient { get; }
    Task<T> Send<T>(string endpoint);
}
