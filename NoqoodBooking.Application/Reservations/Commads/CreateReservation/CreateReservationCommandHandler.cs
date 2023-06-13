using ErrorOr;
using MediatR;
using NoqoodBooking.Application.Common.Interfaces.Persistence;
using NoqoodBooking.Domain.Reservation;

namespace NoqoodBooking.Application.Authentication.Commads.Register;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, ErrorOr<Reservation>>
{
    private readonly IReservationRepository _reservationRepository;

    public CreateReservationCommandHandler(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<ErrorOr<Reservation>> Handle(CreateReservationCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create reservation (generate unique ID)
        var reservation = Reservation.Create(command.ReservedBy, command.CustomerName, command.ReservationDate, command.Notes, command.TripId);

        // Prsist reservation
        _reservationRepository.Add(reservation);

        return reservation;
    }
}
