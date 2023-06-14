using ErrorOr;
using MediatR;
using NoqoodBooking.Application.Authentication.Common;
using NoqoodBooking.Application.Common.Interfaces.Authentication;
using NoqoodBooking.Application.Common.Interfaces.Persistence;

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

        await _userRepository.AddUserAsync(command);
        // Create JWT token
        //var token = _jwtTokenGenerator.GenerateToken(user);
        //return new AuthenticationResult(user, token);
        return default!;
    }
}
