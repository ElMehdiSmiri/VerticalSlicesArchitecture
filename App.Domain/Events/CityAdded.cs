using App.Domain.Common;
using App.Domain.Entities;

namespace App.Domain.Events
{
    public class CityAdded : BaseEvent
    {
        public CityAdded(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
