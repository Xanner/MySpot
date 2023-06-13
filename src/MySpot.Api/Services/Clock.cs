namespace MySpot.Api.Services;

public class Clock
{
    public DateTime Current() => DateTime.UtcNow;
}
