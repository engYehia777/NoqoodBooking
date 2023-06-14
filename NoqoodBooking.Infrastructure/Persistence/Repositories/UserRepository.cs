using Microsoft.AspNetCore.Identity;
using NoqoodBooking.Application.Authentication.Commads.Register;
using NoqoodBooking.Application.Common.Interfaces.Persistence;
using NoqoodBooking.Domain.UserAggregate;

namespace NoqoodBooking.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;

    public UserRepository(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task AddUserAsync(RegisterCommand userCommand)
    {
        // Check if user already exists
        var userExist = _userManager.Users.Any(u => u.UserName.ToLower() == userCommand.UserName.ToLower() || u.Email.ToLower() == userCommand.Email.ToLower());
        if (userExist) { throw new DuplicateWaitObjectException(nameof(userCommand.Email)); }
        //if (userExist)
        //    return new DataResponse<User?> { IsDone = true, Data = null, Message = "UserName or Email Already Exist!" };

        //var roleExist = await _roleManager.FindByNameAsync(userDto.Role.Trim());

        //if (roleExist == null && !string.IsNullOrEmpty(userDto.Role))
        //    return new BaseResponse { IsDone = true, Message = "Role Does Not Exist!" };

        User user = new User { UserName = userCommand.UserName.Trim(), Email = userCommand.Email, EmailConfirmed = true };

        var result = await _userManager.CreateAsync(user, userCommand.Password);

        //Add Role To User
        //if (!string.IsNullOrEmpty(userDto.Role) && result.Succeeded)
        //{
        //    await _userManager.AddToRoleAsync(user, userDto.Role.Trim());
        //}

        await Task.CompletedTask;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }
}
