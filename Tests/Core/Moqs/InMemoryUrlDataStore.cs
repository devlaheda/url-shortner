using Core.Urls;
using Core.Urls.Add;

namespace Core.Tests.Moqs;

public class InMemoryUrlDataStore : Dictionary<string, ShortnedUrl>, IUrlDataStore
{
    public Task AddAsync(ShortnedUrl shortnedUrl, CancellationToken cancellationToken)
    {
        Add(shortnedUrl.ShortUrl, shortnedUrl);
        return Task.CompletedTask;
    }
}
