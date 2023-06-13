using FluentValidation;

namespace NoqoodBooking.Application.Authentication.Commads.Register
{
    public class CreateReservationCommandValidator : AbstractValidator<CreateReservationCommand>
    {
        public CreateReservationCommandValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty();
            RuleFor(x => x.ReservedBy).NotEmpty();
            RuleFor(x => x.ReservationDate).NotEmpty();
            RuleFor(x => x.Notes).NotEmpty();
            RuleFor(x => x.TripId).NotEmpty();

        }
    }
}
