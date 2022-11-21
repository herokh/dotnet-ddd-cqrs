using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Application.Restaurant.Commands.CreateRestaurant;
using MyRestaurant.Contracts.Restaurant;

namespace MyRestaurant.Api.Controllers;

[Route("users/{userId}/[controller]")]
public class RestaurantsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public RestaurantsController(IMapper mapper,
                                 ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantRequest request, string userId)
    {
        var command = _mapper.Map<CreateRestaurantCommand>((request, userId));
        var createRestaurantResult = await _mediator.Send(command);

        return createRestaurantResult.Match(
            restaurant => Ok(_mapper.Map<CreateRestaurantResponse>(restaurant)),
            errors => Problem(errors)
        );
    }
}
