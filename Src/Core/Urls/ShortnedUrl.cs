
namespace Core.Urls;

public record ShortnedUrl
{
    public string CreatedBy { get; }

    public Uri LongUrl{ get; }
    public string ShortUrl { get; }
    public DateTimeOffset CreatedOn { get; }

    public ShortnedUrl(Uri longUrl, string shortUrl, string createdBy, DateTimeOffset createdOn)
    {
        LongUrl = longUrl;
        ShortUrl = shortUrl;
        CreatedBy = createdBy;
        CreatedOn = createdOn;
    }
}
