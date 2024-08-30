using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure.Repository.ApplicationDbContext;
public class ApplicationDbContext : DbContext
{
  public readonly string _connectionString;
  public ApplicationDbContext()
  {
    IConfigurationManager configurationManager = new ConfigurationManager();
   
    // var conection =  configurationManager.GetConnectionString("DefaultConnection"); 
      var conection =  Environment.GetEnvironmentVariable("DefaultConnection");

    // IConfiguration configuration =
    //         new ConfigurationBuilder()
    //         .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    //         .AddJsonFile("appsettings.json")
    //         .Build();
    //_connectionString = configuration.GetConnectionString("DefaultConnection")!;
    
    _connectionString = conection!;
  }

  public ApplicationDbContext(string connectionString)
  {
    _connectionString = connectionString;
  }

  public DbSet<Contact> Contact { get; set; }
  public DbSet<Region> Region { get; set; }


  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseSqlServer(_connectionString);
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
  }

}
