using NoqoodBooking.Domain.Common.Models;
using NoqoodBooking.Domain.Reservation.Entities;
using NoqoodBooking.Domain.Reservation.ValueObjects;

namespace NoqoodBooking.Domain.Reservation
{
    public sealed class Reservation : AggregateRoot<ReservationId>
    {
#pragma warning disable CS8618
        private Reservation()
#pragma warning restore CS8618 
        {

        }
        public Reservation(ReservationId id, string reservedBy, string customerName, DateTime reservationDate, string notes, DateTime creationDate, TripId tripId) : base(id)
        {
            ReservedBy = reservedBy;
            CustomerName = customerName;
            ReservationDate = reservationDate;
            Notes = notes;
            TripId = tripId;
            CreationDate = creationDate;
        }

        public string ReservedBy { get; private set; }
        public string CustomerName { get; private set; }
        public DateTime ReservationDate { get; private set; }
        public DateTime CreationDate { get; private set; }
        public string Notes { get; private set; }
        public TripId TripId { get; private set; }
        public Trip Trip { get; private set; }

        public static Reservation Create(string reservedBy, string customerName, DateTime reservationDate, string notes, Guid tripId)
        {
            return new(ReservationId.CreateUnique(), reservedBy, customerName, reservationDate, notes, DateTime.Now, TripId.Create(tripId));
        }

    }
}
