using System.Text;
namespace Core.Extentions;
public static class Base62Extentions
{
    const string _base62Digits = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static string EncodeToBase62(this long number)
    {
        if (number  == 0)
            return "0";
        Stack<char> base62 = new();
        
        while (number > 0)
        {
            base62.Push(_base62Digits[(int)number % 62]);
            number /= 62;
        }
        return new string(base62.ToArray());
    }
    public static long DecodeFromBase62String(this string base62)
    {
        if (base62 is null || base62.Length == 0)
            throw new ArgumentException("Argument should not be null or empty");
        long result = 0;
        int power = 0;
        foreach (var character in base62.Reverse())
        {
            result += (long)(_base62Digits.IndexOf(character) * Math.Pow(62, power));
            power++;          
        }
        return result;
    }
}