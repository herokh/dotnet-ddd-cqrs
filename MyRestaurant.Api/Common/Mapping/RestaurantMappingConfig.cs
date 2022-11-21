using Mapster;
using MyRestaurant.Application.Restaurant.Commands.CreateRestaurant;
using MyRestaurant.Contracts.Restaurant;

namespace MyRestaurant.Api.Common.Mapping;

public class RestaurantMappingConfig : IRegister
{

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateRestaurantRequest Request, string UserId), CreateRestaurantCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Domain.RestaurantAggregate.Restaurant, CreateRestaurantResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value);
        config.NewConfig<Domain.RestaurantAggregate.Entity.MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        config.NewConfig<Domain.RestaurantAggregate.Entity.MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
