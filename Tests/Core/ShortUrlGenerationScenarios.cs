namespace Core.Tests;

public class ShortUrlGenerationScenarios
{
    // TODO Add Here tests List
    [Fact]
    public void ShouldReturnShorlUrlForZero()
    {
        TokenProvider tokenProvider = new();
        tokenProvider.AssignRange(0, 10);
        ShortUrlGenerator shortUrlGenerator = new(tokenProvider);
        string shortUrl = shortUrlGenerator.GenerateUniqueUrl();
        Assert.Equal("0", shortUrl);

    }
    [Fact]
    public void ShouldReturnShortUrlFor8566857()
    {
        TokenProvider tokenProvider = new();
        tokenProvider.AssignRange(8566857, 1566857);
        ShortUrlGenerator shortUrlGenerator = new(tokenProvider);
        string shortUrl = shortUrlGenerator.GenerateUniqueUrl();
        Assert.Equal("zWD7", shortUrl);
    }
}
