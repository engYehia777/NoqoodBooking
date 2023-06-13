using ErrorOr;
using MediatR;
using NoqoodBooking.Domain.Reservation;

namespace NoqoodBooking.Application.Authentication.Commads.Register;

public record CreateReservationCommand(string ReservedBy, string CustomerName, DateTime ReservationDate, string Notes, Guid TripId) : IRequest<ErrorOr<Reservation>>;

