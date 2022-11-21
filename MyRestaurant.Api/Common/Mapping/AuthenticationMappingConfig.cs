using Mapster;
using MyRestaurant.Application.Authentication.Commands.Register;
using MyRestaurant.Application.Authentication.Common;
using MyRestaurant.Application.Authentication.Queries.Login;
using MyRestaurant.Contracts.Authentication;

namespace MyRestaurant.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}
