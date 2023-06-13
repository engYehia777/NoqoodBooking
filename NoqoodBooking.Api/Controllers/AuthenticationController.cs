using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoqoodBooking.Application.Authentication.Commads.Register;
using NoqoodBooking.Application.Authentication.Common;
using NoqoodBooking.Application.Authentication.Queries.Login;
using NoqoodBooking.Contracts.Authentication;

namespace NoqoodBooking.Api.Controllers;


[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {

        _mediator = mediator;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> autResult = await _mediator.Send(command);

        return autResult.Match(
            autResult => Ok(_mapper.Map<AuthenticationResponse>(autResult)),
            errors => Problem(errors));


    }



    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Auth.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }

        return authResult.Match(
           autResult => Ok(_mapper.Map<AuthenticationResponse>(autResult)),
            errors => Problem(errors));

    }
}
