namespace MyRestaurant.Application.Persistence;

public interface IRestaurantRepository
{
    void Add(Domain.RestaurantAggregate.Restaurant restaurant);
}
