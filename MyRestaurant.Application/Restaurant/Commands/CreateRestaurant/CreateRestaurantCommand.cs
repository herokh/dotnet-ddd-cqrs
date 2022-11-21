using ErrorOr;
using MediatR;

namespace MyRestaurant.Application.Restaurant.Commands.CreateRestaurant;

public record CreateRestaurantCommand(string UserId,
                                      string Name,
                                      string Description,
                                      List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Domain.RestaurantAggregate.Restaurant>>;

public record MenuSectionCommand(string Name,
                          string Description,
                          List<MenuItemCommand> Items);

public record MenuItemCommand(string Name,
                       string Description);
