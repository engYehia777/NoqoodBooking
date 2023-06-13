using NoqoodBooking.Application.Common.Interfaces.Services;

namespace NoqoodBooking.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UTcNow => DateTime.UtcNow;
}
