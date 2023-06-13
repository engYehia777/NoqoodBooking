namespace NoqoodBooking.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime UTcNow { get; }
}
