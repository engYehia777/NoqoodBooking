using NoqoodBooking.Domain.Common.Models;
using NoqoodBooking.Domain.Reservation.ValueObjects;

namespace NoqoodBooking.Domain.Reservation.Entities
{
    public sealed class Trip : Entity<TripId>
    {
        public Trip(TripId id, string name, string cityName, decimal price, string imageUrl, string content, DateTime creationDate) : base(id)
        {
            Name = name;
            CityName = cityName;
            Price = price;
            ImageUrl = imageUrl;
            Content = content;
            CreationDate = creationDate;

        }

        public string Name { get; }
        public string CityName { get; }
        public decimal Price { get; }
        public string ImageUrl { get; }
        public string Content { get; }
        public DateTime CreationDate { get; }


        public static Trip Create(string name, string cityName, decimal price, string imageUrl, string content, DateTime creationDate)
        {
            return new(TripId.CreateUnique(), name, cityName, price, imageUrl, content, creationDate);
        }

    }
}
