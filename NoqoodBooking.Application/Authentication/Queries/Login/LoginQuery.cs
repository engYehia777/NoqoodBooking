using NoqoodBooking.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace NoqoodBooking.Application.Authentication.Queries.Login;

public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
