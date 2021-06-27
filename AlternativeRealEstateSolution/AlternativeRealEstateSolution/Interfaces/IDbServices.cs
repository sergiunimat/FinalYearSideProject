using AlternativeRealEstateSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlternativeRealEstateSolution.Interfaces
{
    public interface IDbServices
    {
        Task AddEventAsync(Event incommingEvent);
        Task<List<Event>> GetAllEventsAsync();
        Task AddPropertyAsync(Property property);
        Task<List<Property>> GetAllPropertiesAsync();
        Task<List<User>> GetAllUsersAsync();
    }
}
