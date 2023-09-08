using DevSquad.Api.Squads.Models;
using Microsoft.EntityFrameworkCore;

namespace DevSquad.Api.Squads.Data
{
    public class SquadsDbContext : DbContext
    {
        public SquadsDbContext(DbContextOptions<SquadsDbContext> options) : base(options)
        {            
        }

        public DbSet<Squad> Squads { get; set; }
    }
}