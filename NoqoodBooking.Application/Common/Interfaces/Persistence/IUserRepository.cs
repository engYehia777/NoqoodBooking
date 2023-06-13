using NoqoodBooking.Domain.Entities;

namespace NoqoodBooking.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}
