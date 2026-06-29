namespace APITestingBaselineCSharp.Interfaces;

public interface ITest : IDisposable
{
    IClient Client { get; }
}
