using ErrorOr;
using MediatR;
using MyRestaurant.Application.Authentication.Common;

namespace MyRestaurant.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
