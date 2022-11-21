namespace MyRestaurant.Contracts.Restaurant;

public record CreateRestaurantResponse(
    Guid Id,
    string Name,
    string Description,
    string UserId,
    List<MenuSectionResponse> Sections,
    DateTime CreatedDateTime,
    DateTime UpdatedDateTime
);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description,
    List<MenuItemResponse> Items
);

public record MenuItemResponse(
    string Id,
    string Name,
    string Description
);
