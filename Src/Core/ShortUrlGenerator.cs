using Core.Extentions;

namespace Core;

public class ShortUrlGenerator
{
    private TokenProvider _tokenProvider;

    public ShortUrlGenerator(TokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider;
    }

    public string GenerateUniqueUrl()
    {
        return _tokenProvider.GetToken().EncodeToBase62();
    }
}
