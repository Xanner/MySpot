using MySpot.Core.Abstractions;

namespace MySpot.Tests.Unit.Shared;

public class TestClock : IClock
{
    public DateTime Current() => new(2023, 06, 17, 12, 0, 0);
}
