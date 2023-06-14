using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoqoodBooking.Domain.Reservation.Entities;
using NoqoodBooking.Domain.Reservation.ValueObjects;

namespace NoqoodBooking.Infrastructure.Persistence.Configurations
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.ToTable("Trips");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => TripId.Create(value));

            builder.HasMany(t => t.Reservations)
                .WithOne(e => e.Trip)
                .HasForeignKey(e => e.TripId);


        }
    }
}
