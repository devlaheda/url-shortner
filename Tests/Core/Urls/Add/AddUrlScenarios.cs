using System.Threading.Tasks;
using Core.Tests.Moqs;
using Core.Urls.Add;
using Microsoft.Extensions.Time.Testing;

namespace Core.Tests.Urls.Add;

public class AddUrlScenarios
{
    private readonly AddUrlHandler _handler;
    private readonly InMemoryUrlDataStore _urlDataStore = new();
    private FakeTimeProvider fakeTimeProvider = new();
    public AddUrlScenarios()
    {

        var tokenprovider = new TokenProvider();
        tokenprovider.AssignRange(1, 10);
        var shortUrlGenerator = new ShortUrlGenerator(tokenprovider);
        _handler = new AddUrlHandler(shortUrlGenerator, _urlDataStore, fakeTimeProvider);
    }
    [Fact]
    public async Task Should_Return_ShortnedUrl()
    {
        AddUrlRequest request = CreatAddUrlRequest();
        var  response = await _handler.HandleAsync(request, default);
        Assert.NotNull(response);
    }
    [Fact]
    public async Task Should_Save_ShortUrl_ToDataStore()
    {
        var request = CreatAddUrlRequest();
        var response = await _handler.HandleAsync(request, default);
        var checkIfConatinsKey = _urlDataStore.ContainsKey(response.shortnedUrl);
        Assert.True(checkIfConatinsKey);
    }
    [Fact]
    public async Task Should_Save_ShortUrl_Metadata_ToDataStore()
    {
        var request = CreatAddUrlRequest();
        var response = await _handler.HandleAsync(request, default);
        var checkIfConatinsKey = _urlDataStore.ContainsKey(response.shortnedUrl);
        Assert.True(checkIfConatinsKey);
        Assert.Equal(_urlDataStore[response.shortnedUrl].CreatedBy, request.CreatedBy);
        Assert.Equal(_urlDataStore[response.shortnedUrl].CreatedOn, fakeTimeProvider.GetUtcNow());
    }

    private AddUrlRequest CreatAddUrlRequest()
    {
        return new AddUrlRequest(new Uri("https://github.com"),"devlaheda@github.com");
    }
}
