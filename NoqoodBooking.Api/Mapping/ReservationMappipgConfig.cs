using Mapster;
using NoqoodBooking.Application.Authentication.Commads.Register;
using NoqoodBooking.Contracts.Reservations;

namespace NoqoodBooking.Api.Mapping;

public class ReservationMappipgConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateReservationRequest, CreateReservationCommand>();


    }
}
