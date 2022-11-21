using ErrorOr;
using MediatR;
using MyRestaurant.Application.Authentication.Common;

namespace MyRestaurant.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
