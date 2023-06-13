using NoqoodBooking.Domain.Common.Models;

namespace NoqoodBooking.Domain.Reservation.ValueObjects
{
    public sealed class TripId : ValueObject
    {
        public Guid Value { get; }
        private TripId(Guid value)
        {
            Value = value;
        }

        public static TripId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
