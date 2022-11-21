using MyRestaurant.Domain.Entities;

namespace MyRestaurant.Application.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
