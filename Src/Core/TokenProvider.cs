namespace Core;

public class TokenProvider
{
    private TokenRange _tokenRange;

    public void AssignRange(int start, int end) => _tokenRange = new(start, end);
    public void AssignRange(TokenRange tokenRange) => _tokenRange = tokenRange;

    public long GetToken()
    {
        //TODO This is just for testing purposes
        return _tokenRange.Start;
    }
}
