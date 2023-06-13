using NoqoodBooking.Domain.UserAggregate;

namespace NoqoodBooking.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
