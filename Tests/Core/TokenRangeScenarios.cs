namespace Core.Tests;

public class TokenRangeScenarios
{
    [Fact]
    public void ShouldThrowArgumentExceptionWhenStartIsLessThenEnd()
    {
        var action = () => new TokenRange(200, 100);
        var exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal("Invalid Parameters please make sure your start point is greater then end point", exception.Message);
    }
    [Fact]
    public void ShouldThrowArgumentExceptionWhenStartIsNegative()
    {
        var action = () => new TokenRange(-100, 1000);
        var exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal("Invalid Parameters make sure that you are using postive range", exception.Message);
    }
    [Fact]
    public void ShouldThrowArgumentExceptionWhenEndIsNegative()
    {
        var action = () => new TokenRange(-200, -100);
        var exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal("Invalid Parameters make sure that you are using postive range", exception.Message);
    }

}
