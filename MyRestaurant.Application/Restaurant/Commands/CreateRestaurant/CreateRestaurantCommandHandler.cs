using ErrorOr;
using MediatR;
using MyRestaurant.Application.Persistence;
using MyRestaurant.Domain.RestaurantAggregate.Entity;
using MyRestaurant.Domain.RestaurantAggregate.ValueObjects;

namespace MyRestaurant.Application.Restaurant.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, ErrorOr<Domain.RestaurantAggregate.Restaurant>>
{
    private readonly IRestaurantRepository _restaurantRepository;

    public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository)
    {
        _restaurantRepository = restaurantRepository;
    }

    public async Task<ErrorOr<Domain.RestaurantAggregate.Restaurant>> Handle(CreateRestaurantCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // create restaurant
        var restaurant = Domain.RestaurantAggregate.Restaurant.Create(command.Name,
                                                                      command.Description,
                                                                      UserId.Create(command.UserId),
                                                                      command.Sections.ConvertAll(section =>
                                                                        MenuSection.Create(section.Name,
                                                                                           section.Description,
                                                                                           section.Items.ConvertAll(item =>
                                                                                            MenuItem.Create(item.Name,
                                                                                                            item.Description)))));

        // persist restaurant
        _restaurantRepository.Add(restaurant);

        // return restaurant
        return restaurant;
    }
}
