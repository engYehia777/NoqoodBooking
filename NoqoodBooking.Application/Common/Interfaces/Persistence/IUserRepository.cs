using NoqoodBooking.Application.Authentication.Commads.Register;
using NoqoodBooking.Domain.UserAggregate;

namespace NoqoodBooking.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task AddUserAsync(RegisterCommand userCommand);
}
