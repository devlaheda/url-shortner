namespace Core;

public record TokenRange
{
    public long Start { get; }
    public long End { get; }

    public TokenRange(long start, long end)
    {
        if (start > end)
            throw new ArgumentException("Invalid Parameters please make sure your start point is greater then end point");
        if (start < 0 || end < 0)
            throw new ArgumentException("Invalid Parameters make sure that you are using postive range");

        Start = start;
        End = end;
    }
}
