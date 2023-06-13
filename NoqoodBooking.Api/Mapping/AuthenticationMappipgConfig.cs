using NoqoodBooking.Application.Authentication.Common;
using NoqoodBooking.Contracts.Authentication;
using Mapster;

namespace NoqoodBooking.Api.Mapping;

public class AuthenticationMappipgConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(des => des.Token, src => src.Token)
            .Map(des => des, src => src.User); // file the rest of pros from the src
    }
}
