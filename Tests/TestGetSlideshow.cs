using APITestingBaselineCSharp.Clients;
using APITestingBaselineCSharp.DTOs;

namespace APITestingBaselineCSharp.Tests;

[Parallelizable(ParallelScope.Self)]
public class TestGetSlideshow : ITest
{
    public IClient Client { get; } = new Get();
    HTTPBin HttpBin => new(Client);
    SlideshowDTO? _slideshow;

    [Test]
    public async Task TestGetSlideshowReturnsAuthor()
    {
        await TestHelpers.RunAsync(async () =>
        {
            _slideshow = await HttpBin.Slideshow();
        });

        Assert.That(_slideshow!.Slideshow.Author, Is.EqualTo("Yours Truly"));
    }

    [TearDown]
    public void Dispose() => Client.Dispose();
}
