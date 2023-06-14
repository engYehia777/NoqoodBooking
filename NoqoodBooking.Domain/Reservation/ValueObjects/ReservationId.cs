using NoqoodBooking.Domain.Common.Models;

namespace NoqoodBooking.Domain.Reservation.ValueObjects
{
    public sealed class ReservationId : ValueObject
    {
        public Guid Value { get; private set; }
        private ReservationId(Guid value)
        {
            Value = value;
        }

        public static ReservationId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static ReservationId Create(Guid value)
        {
            return new(value);
        }



        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
