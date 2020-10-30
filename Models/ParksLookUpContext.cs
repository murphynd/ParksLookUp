using Microsoft.EntityFrameworkCore;
using System;

namespace ParksLookUp.Models
{
  public class ParksLookUpContext : DbContext
  {
    public ParksLookUpContext(DbContextOptions<ParksLookUpContext> options)
        : base(options)
    {
    }

    public DbSet<Park> Parks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
          .HasData(
              new Park { ParkId = -1, Title = "Yosemite", Location = "California", Desc = "USA", Date = DateTime.Now, Rating = 7, Kind = "State" },
              new Park { ParkId = -2, Title = "Smokey Mountians", Location = "North Carolina", Desc = "USA", Date = DateTime.Now, Rating = 10, Kind = "National" },
              new Park { ParkId = -3, Title = "Zion", Location = "Utah", Desc = "USA", Date = DateTime.Now, Rating = 2, Kind = "State" },
              new Park { ParkId = -4, Title = "Yellowstone", Location = "Wyoming", Desc = "USA", Date = DateTime.Now, Rating = 4, Kind = "National" },
              new Park { ParkId = -5, Title = "Joshua Tree", Location = "California", Desc = "USA", Date = DateTime.Today, Rating = 2, Kind = "State" }
          );
    }
  }
}