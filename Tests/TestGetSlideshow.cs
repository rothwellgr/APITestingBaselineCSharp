using APITestingBaselineCSharp.Clients;
using APITestingBaselineCSharp.DTOs;

namespace APITestingBaselineCSharp.Tests;

/// <summary>
/// Using NUnit as the test framework and runner.
/// </summary>
public class TestGetSlideshow
{
    private HTTPBinClient _httpbin;
    private SlideshowDTO? _response = null;

    [SetUp]
    public void Setup()
    {
        _httpbin = new HTTPBinClient("json");
    }

    [Test]
    public async Task TestGetSlideshowReturnsAuthor()
    {
        _response = await _httpbin.GetSlideshow();
        Assert.That(_response.Slideshow.Author, Is.EqualTo("Yours Truly"));
    }

    [TearDown]
    public void TearDown()
    {
        _httpbin.Dispose();
    }
}