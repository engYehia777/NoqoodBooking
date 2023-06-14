using ErrorOr;
using MediatR;
using NoqoodBooking.Application.Authentication.Common;
using NoqoodBooking.Application.Common.Interfaces.Authentication;
using NoqoodBooking.Application.Common.Interfaces.Persistence;
using NoqoodBooking.Domain.Common.Errors;
using NoqoodBooking.Domain.UserAggregate;

namespace NoqoodBooking.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (await _userRepository.GetUserByEmailAsync(query.Email) is not User user)
        {
            return Errors.Auth.InvalidCredentials;
        }

        if (user is null)
        {
            return Errors.Auth.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}
