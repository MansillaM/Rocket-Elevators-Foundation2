using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using RocketElevatorsRestApi.Models;

namespace RocketElevatorsRestApi.Models
{
    public class RocketElevatorsContext : DbContext
    {
        public RocketElevatorsContext(DbContextOptions<RocketElevatorsContext> options)
            : base(options)
        {
        }

        public DbSet<elevators> elevators { get; set; } = null!;

        public DbSet<RocketElevatorsRestApi.Models.leads>? leads { get; set; }

        public DbSet<RocketElevatorsRestApi.Models.customers>? customers { get; set; }
        public DbSet<RocketElevatorsRestApi.Models.Battery>? Batteries { get; set; }
        public DbSet<RocketElevatorsRestApi.Models.Column>? Columns { get; set; }
        
    }
}