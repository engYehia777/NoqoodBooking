
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoqoodBooking.Domain.Reservation;
using NoqoodBooking.Domain.Reservation.Entities;
using NoqoodBooking.Domain.UserAggregate;
using NoqoodBooking.Infrastructure.Persistence.Configurations;

namespace NoqoodBooking.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<Trip> Trips { get; set; } = null!;


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ReservationConfig).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
