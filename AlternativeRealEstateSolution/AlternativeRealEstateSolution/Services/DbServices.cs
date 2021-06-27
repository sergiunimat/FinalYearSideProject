using AlternativeRealEstateSolution.Data;
using AlternativeRealEstateSolution.Interfaces;
using AlternativeRealEstateSolution.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlternativeRealEstateSolution.Services
{
    public class DbServices : IDbServices
    {
        readonly AppDbContext _ctx;

        public DbServices(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddEventAsync(Event incommingEvent)
        {
            await _ctx.Events.AddAsync(incommingEvent);
            await _ctx.SaveChangesAsync();
        }

        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _ctx.Events.ToListAsync();
        }

        public async Task AddPropertyAsync(Property property)
        {
            await _ctx.Properties.AddAsync(property);
            await _ctx.SaveChangesAsync();
        }
        public async Task<List<Property>> GetAllPropertiesAsync()
        {
            return await _ctx.Properties.ToListAsync();
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _ctx.Users.ToListAsync();
        }
    }
}
