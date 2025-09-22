namespace Core.Urls.Add;

public class AddUrlHandler
{
    private readonly ShortUrlGenerator _shortUrlGenerator;
    private readonly IUrlDataStore _urlDataStore;
    private readonly TimeProvider _timeProvider;

    public AddUrlHandler(ShortUrlGenerator shortUrlGenerator, IUrlDataStore urlDataStore ,TimeProvider timeProvider)
    {
        _shortUrlGenerator = shortUrlGenerator;
        _urlDataStore = urlDataStore;
        _timeProvider = timeProvider;
    }

    public async Task<Result<AddUrlResponse>> HandleAsync(AddUrlRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.CreatedBy))
            return new Error("missing_value", "Created by is required"); // Simple Validation for now
        ShortnedUrl  shortnedUrl = new(request.LongUrl,_shortUrlGenerator.GenerateUniqueUrl(),request.CreatedBy,_timeProvider.GetUtcNow());
        await _urlDataStore.AddAsync(shortnedUrl, cancellationToken);
        return new AddUrlResponse(request.LongUrl , shortnedUrl.ShortUrl);
    }

}
