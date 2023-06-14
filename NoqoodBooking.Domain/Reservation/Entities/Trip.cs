using NoqoodBooking.Domain.Common.Models;
using NoqoodBooking.Domain.Reservation.ValueObjects;

namespace NoqoodBooking.Domain.Reservation.Entities
{
    public sealed class Trip : Entity<TripId>
    {
#pragma warning disable CS8618
        private Trip()
#pragma warning restore CS8618 
        {

        }
        public Trip(TripId id, string name, string cityName, decimal price, string imageUrl, string content, DateTime creationDate) : base(id)
        {
            Name = name;
            CityName = cityName;
            Price = price;
            ImageUrl = imageUrl;
            Content = content;
            CreationDate = creationDate;

        }

        public string Name { get; private set; }
        public string CityName { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
        public string Content { get; private set; }
        public DateTime CreationDate { get; private set; }

        public ICollection<Reservation> Reservations { get; private set; }


        public static Trip Create(string name, string cityName, decimal price, string imageUrl, string content, DateTime creationDate)
        {
            return new(TripId.CreateUnique(), name, cityName, price, imageUrl, content, creationDate);
        }

    }
}
