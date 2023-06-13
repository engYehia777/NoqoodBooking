using Microsoft.AspNetCore.Mvc;

namespace NoqoodBooking.Api.Controllers
{
    [Route("[controller]")]
    public class ReservationController : ApiController
    {
        [HttpGet]
        public ActionResult GetReservations()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
