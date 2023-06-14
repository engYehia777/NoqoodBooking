using NoqoodBooking.Domain.Common.Models;

namespace NoqoodBooking.Domain.Reservation.ValueObjects
{
    public sealed class TripId : ValueObject
    {
        public Guid Value { get; private set; }
        private TripId(Guid value)
        {
            Value = value;
        }

        public static TripId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static TripId Create(Guid value)
        {
            return new(value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
