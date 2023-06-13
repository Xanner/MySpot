using MySpot.Api.Services;

namespace MySpot.Tests.Unit.Shared;

public class TestClock : IClock
{
    public DateTime Current() => new DateTime(2023, 06, 13);
}
