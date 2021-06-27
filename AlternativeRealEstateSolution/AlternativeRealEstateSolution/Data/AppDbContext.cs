using AlternativeRealEstateSolution.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlternativeRealEstateSolution.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users{ get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}
