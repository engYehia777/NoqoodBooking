using NoqoodBooking.Domain.Common.Models;

namespace NoqoodBooking.Domain.Reservation.ValueObjects
{
    public sealed class ReservationId : ValueObject
    {
        public Guid Value { get; }
        private ReservationId(Guid value)
        {
            Value = value;
        }

        public static ReservationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
