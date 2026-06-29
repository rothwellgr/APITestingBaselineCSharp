using APITestingBaselineCSharp.Clients;
using APITestingBaselineCSharp.DTOs;

namespace APITestingBaselineCSharp.Tests;

[Parallelizable(ParallelScope.Self)]
public class TestUuidEcho : ITest
{
    public IClient Client { get; } = new Get();
    HTTPBin HttpBin => new(Client);
    UuidDTO? _uuid;
    AnythingDTO? _echo;

    [Test]
    public async Task TestGetThenEchoUuid()
    {
        await TestHelpers.RunAsync(async () =>
        {
            _uuid = await HttpBin.Uuid();
            _echo = await Client.Send<AnythingDTO>($"{HTTPBinUrls.Anything}?uuid={_uuid!.Uuid}");
        });

        Assert.That(_echo!.Args["uuid"], Is.EqualTo(_uuid!.Uuid));
    }

    [TearDown]
    public void Dispose() => Client.Dispose();
}
