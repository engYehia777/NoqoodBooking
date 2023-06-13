using NoqoodBooking.Application.Common.Interfaces.Persistence;
using NoqoodBooking.Domain.Reservation;

namespace NoqoodBooking.Infrastructure.Persistence;

public class ReservationRepository : IReservationRepository
{
    private static readonly List<Reservation> _reservations = new();

    public void Add(Reservation reservation)
    {
        _reservations.Add(reservation);
    }
}
