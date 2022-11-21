using MyRestaurant.Domain.Common.Models;

namespace MyRestaurant.Domain.RestaurantAggregate.ValueObjects;

public sealed class RestaurantId : ValueObject
{
    public Guid Value { get; }

    public RestaurantId(Guid value)
    {
        Value = value;
    }

    public static RestaurantId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
