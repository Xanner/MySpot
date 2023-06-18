using MySpot.Core.Exceptions;

namespace MySpot.Core.ValueObjects;

public sealed record UserName
{
    public string Value { get; }

    public UserName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length is > 30 or < 3)
        {
            throw new InvalidFullNameException(value);
        }

        Value = value;
    }

    public static implicit operator UserName(string value) => new UserName(value);

    public static implicit operator string(UserName value) => value?.Value;

    public override string ToString() => Value;
}