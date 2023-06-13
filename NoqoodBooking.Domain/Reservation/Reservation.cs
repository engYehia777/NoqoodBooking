using NoqoodBooking.Domain.Common.Models;
using NoqoodBooking.Domain.Reservation.ValueObjects;

namespace NoqoodBooking.Domain.Reservation
{
    public sealed class Reservation : AggregateRoot<ReservationId>
    {

        public Reservation(ReservationId id, string reservedBy, string customerName, DateTime reservationDate, string notes, Guid tripId) : base(id)
        {
            ReservedBy = reservedBy;
            CustomerName = customerName;
            ReservationDate = reservationDate;
            Notes = notes;
            TripId = tripId;
        }

        public string ReservedBy { get; }
        public string CustomerName { get; }
        public DateTime ReservationDate { get; }
        public DateTime CreationDate { get; }
        public string Notes { get; }
        public Guid TripId { get; }

        public static Reservation Create(string reservedBy, string customerName, DateTime reservationDate, string notes, Guid tripId)
        {
            return new(ReservationId.CreateUnique(), reservedBy, customerName, reservationDate, notes, tripId);
        }

    }
}
