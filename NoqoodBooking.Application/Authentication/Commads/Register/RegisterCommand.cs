using NoqoodBooking.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace NoqoodBooking.Application.Authentication.Commads.Register;

public record RegisterCommand(string Firstname,
                              string Lastname,
                              string Email,
                              string Password) : IRequest<ErrorOr<AuthenticationResult>>;

