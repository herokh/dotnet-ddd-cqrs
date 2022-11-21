using MyRestaurant.Application.Common.Interfaces.Services;

namespace MyRestaurant.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
