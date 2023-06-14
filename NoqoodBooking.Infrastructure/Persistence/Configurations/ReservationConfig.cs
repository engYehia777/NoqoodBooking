using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoqoodBooking.Domain.Reservation;
using NoqoodBooking.Domain.Reservation.ValueObjects;

namespace NoqoodBooking.Infrastructure.Persistence.Configurations
{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservations");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => ReservationId.Create(value));

            builder.HasOne(r => r.Trip).WithMany(x => x.Reservations);

        }
    }
}
