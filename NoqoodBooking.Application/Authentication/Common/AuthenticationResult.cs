using NoqoodBooking.Domain.UserAggregate;

namespace NoqoodBooking.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
