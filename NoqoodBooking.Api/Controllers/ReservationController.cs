using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoqoodBooking.Application.Authentication.Commads.Register;
using NoqoodBooking.Contracts.Reservations;

namespace NoqoodBooking.Api.Controllers
{
    [Route("[controller]")]
    public class ReservationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public ReservationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet(nameof(GetListAsync))]
        public IActionResult GetListAsync()
        {
            return Ok(Array.Empty<string>());
        }

        [HttpPost(nameof(CreateAsync))]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync(CreateReservationRequest request)
        {
            var command = _mapper.Map<CreateReservationCommand>(request);
            var reservationResult = await _mediator.Send(command);

            return reservationResult.Match(
                res => Ok(res),
                errors => Problem(errors));

        }
    }
}
