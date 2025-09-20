using Core.Extentions;

namespace Core.Tests;

public class Base62EncodingScenarios
{
    // TODO Add Here tests List
    // 
    [Theory]
    [InlineData(1, "1")]
    [InlineData(197874136, "dog6k")]
    [InlineData(21286525, "1rjB3")]
    [InlineData(156654, "EKG")]
    [InlineData(545361, "2hS9")]
    [InlineData(19867612, "1lmtm")]
    public void ShouldEncodeNumberToBase62(long number, string base62Encode)
    {
        Assert.Equal(number.EncodeToBase62(), base62Encode);
    }


    [Theory]
    [InlineData("dog6k", 197874136)]
    [InlineData("1rjB3", 21286525)]
    [InlineData("EKG", 156654)]
    [InlineData("2hS9", 545361)]
    [InlineData("1lmtm", 19867612)]
    public void ShouldDecodeBase32ToNumber(string base62, long number)
    {
        Assert.Equal(base62.DecodeFromBase62String(), number);
    }


    [Fact]
    public void ShouldThrowExceptionIfPassedEmtyOrNullString()
    {
        Assert.Throws<ArgumentException>(()=>"".DecodeFromBase62String());
    }

}
