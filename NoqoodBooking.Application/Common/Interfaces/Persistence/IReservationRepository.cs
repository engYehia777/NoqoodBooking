using NoqoodBooking.Domain.Reservation;

namespace NoqoodBooking.Application.Common.Interfaces.Persistence;

public interface IReservationRepository
{

    void Add(Reservation reservation);
}
