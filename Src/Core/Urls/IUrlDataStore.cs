namespace Core.Urls;

public interface IUrlDataStore
{
    Task AddAsync(ShortnedUrl shortnedUrl, CancellationToken cancellationToken);
}