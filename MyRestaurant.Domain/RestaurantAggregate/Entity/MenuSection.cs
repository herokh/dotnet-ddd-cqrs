using MyRestaurant.Domain.Common.Models;
using MyRestaurant.Domain.RestaurantAggregate.ValueObjects;

namespace MyRestaurant.Domain.RestaurantAggregate.Entity;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();
    public string Name { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    private MenuSection(MenuSectionId menuSectionId,
                       string name,
                       string description,
                       List<MenuItem> items) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = items;
    }



    public static MenuSection Create(string name, string description, List<MenuItem> items)
    {
        return new(MenuSectionId.CreateUnique(),
                   name,
                   description,
                   items);
    }
}
