using MyRestaurant.Domain.Entities;

namespace MyRestaurant.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);
