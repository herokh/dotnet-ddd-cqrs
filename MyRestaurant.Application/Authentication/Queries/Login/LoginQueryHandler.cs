using ErrorOr;
using MediatR;
using MyRestaurant.Application.Authentication.Common;
using MyRestaurant.Application.Common.Interfaces.Authentication;
using MyRestaurant.Application.Persistence;
using MyRestaurant.Domain.Entities;

namespace MyRestaurant.Application.Authentication.Queries.Login;

public class LoginQueryHandler :
    IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. validate user exists
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;
        }

        // 2. validate the password is correct
        if (user.Password != query.Password)
        {
            return Domain.Common.Errors.Errors.Authentication.InvalidCredentials;
        }

        // 3. create jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user,
            token);
    }
}
