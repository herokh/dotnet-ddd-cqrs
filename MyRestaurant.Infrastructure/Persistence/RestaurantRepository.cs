using MyRestaurant.Application.Persistence;
using MyRestaurant.Domain.RestaurantAggregate;

namespace MyRestaurant.Infrastructure.Persistence;

public class RestaurantRepository : IRestaurantRepository
{
    private static readonly List<Restaurant> _restaurants = new();
    public void Add(Restaurant restaurant)
    {
        _restaurants.Add(restaurant);
    }
}
