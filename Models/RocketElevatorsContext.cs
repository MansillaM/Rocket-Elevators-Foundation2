using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using RocketElevatorsRestApi.Models;
using RocketElevatorsRestApi.models;

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
        public DbSet<RocketElevatorsRestApi.Models.battery>? batteries { get; set; }
        public DbSet<RocketElevatorsRestApi.Models.column>? columns { get; set; }
        public DbSet<RocketElevatorsRestApi.Models.building>? buildings { get; set; }
        public DbSet<RocketElevatorsRestApi.models.interventions>? interventions { get; set; }
        
    }
}