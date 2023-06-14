using NoqoodBooking.Application.Common.Interfaces.Persistence;
using NoqoodBooking.Domain.Reservation;

namespace NoqoodBooking.Infrastructure.Persistence.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ReservationRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Reservation reservation)
    {
        try
        {
            _dbContext.Add(reservation);
            var res = _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }
}
