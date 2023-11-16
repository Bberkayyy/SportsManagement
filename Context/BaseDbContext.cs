using Microsoft.EntityFrameworkCore;
using SportsManagement.Models;
using System.Reflection;

namespace SportsManagement.Context;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Player> Players { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Outfit> Outfits { get; set; }
    public DbSet<Team> Teams { get; set; }

}
