using MyRestaurant.Domain.Common.Models;

namespace MyRestaurant.Domain.RestaurantAggregate.ValueObjects;

public sealed class UserId : ValueObject
{
    public string Value { get; }

    public UserId(string value)
    {
        Value = value;
    }

    public static UserId Create(string userId)
    {
        return new(userId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
