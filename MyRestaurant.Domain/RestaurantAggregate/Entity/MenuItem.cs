using MyRestaurant.Domain.Common.Models;
using MyRestaurant.Domain.RestaurantAggregate.ValueObjects;

namespace MyRestaurant.Domain.RestaurantAggregate.Entity;

public sealed class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private MenuItem(MenuItemId menuItemId,
                    string name,
                    string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
}
