using ErrorOr;
using MediatR;
using NoqoodBooking.Application.Authentication.Common;

namespace NoqoodBooking.Application.Authentication.Commads.Register;

public record RegisterCommand(string UserName,
                              string Email,
                              string Password) : IRequest<ErrorOr<AuthenticationResult>>;

