using NoqoodBooking.Application.Authentication.Common;
using NoqoodBooking.Application.Common.Interfaces.Authentication;
using NoqoodBooking.Application.Common.Interfaces.Persistence;
using NoqoodBooking.Domain.Common.Errors;
using NoqoodBooking.Domain.Entities;
using ErrorOr;
using MediatR;

namespace NoqoodBooking.Application.Authentication.Commads.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Check if user already exists
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        // Create user (generate unique ID)
        var user = new User
        {
            FirstName = command.Firstname,
            LastName = command.Lastname,
            Email = command.Email,
            Password = command.Password
        };
        _userRepository.AddUser(user);
        // Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}
