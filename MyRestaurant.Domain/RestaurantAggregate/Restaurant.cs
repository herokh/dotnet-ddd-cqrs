using MyRestaurant.Domain.Common.Models;
using MyRestaurant.Domain.RestaurantAggregate.Entity;
using MyRestaurant.Domain.RestaurantAggregate.ValueObjects;

namespace MyRestaurant.Domain.RestaurantAggregate;

public sealed class Restaurant : AggregateRoot<RestaurantId>
{
    private readonly List<MenuSection> _sections = new();

    public string Name { get; }
    public string Description { get; }
    public UserId UserId { get; }

    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private Restaurant(RestaurantId restaurantId,
                      string name,
                      string description,
                      UserId userId,
                      List<MenuSection> menuSection,
                      DateTime createdDateTime,
                      DateTime updatedDateTime) : base(restaurantId)
    {
        Name = name;
        Description = description;
        UserId = userId;
        _sections = menuSection;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Restaurant Create(
        string name,
        string description,
        UserId userId,
        List<MenuSection> menuSection
    )
    {
        return new(RestaurantId.CreateUnique(),
                   name,
                   description,
                   userId,
                   menuSection,
                   DateTime.UtcNow,
                   DateTime.UtcNow);
    }
}

