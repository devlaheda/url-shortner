using System;

namespace Core;

public record Error(string Code, string Description)
{
    public static Error None => new Error(string.Empty,string.Empty);

}
