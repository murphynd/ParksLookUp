using Microsoft.EntityFrameworkCore;

namespace ParksLookUp.Models
{
  public class ParksLookUpContext : DbContext
  {
    public ParksLookUpContext(DbContextOptions<ParksLookUpContext> options)
        : base(options)
    {
    }

    public DbSet<Park> Parks { get; set; }
  }
}