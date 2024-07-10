using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure.Repository.ApplicationDbContext;
public class ApplicationDbContext : DbContext
{
  private readonly string _connString = "Server=localhost,1433;Database=TechChallenge;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
  public ApplicationDbContext()
  {
    
  }

  public DbSet<Contact> Contact { get; set; }
  public DbSet<Region> Region { get; set; }


  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(_connString);
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
  }

}
