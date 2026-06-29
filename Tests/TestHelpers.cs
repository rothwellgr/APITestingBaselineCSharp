namespace APITestingBaselineCSharp.Tests;

public static class TestHelpers
{
    public static async Task RunAsync(Func<Task> test)
    {
        try
        {
            await test();
        }
        catch (HttpRequestException ex)
        {
            Assert.Fail(ex.Message);
        }
    }
}
