using App.Domain.Common;
using App.Domain.Entities;

namespace App.Domain.Events
{
    public class CountryAdded : BaseEvent
    {
        public CountryAdded(Country country)
        {
            Country = country;
        }

        public Country Country { get; }
    }
}
