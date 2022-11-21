using MyRestaurant.Domain.Entities;

namespace MyRestaurant.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
