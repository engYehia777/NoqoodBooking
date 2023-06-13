using NoqoodBooking.Domain.Entities;

namespace NoqoodBooking.Application.Authentication.Common;

public record AuthenticationResult(User User, string Token);
