using Microsoft.EntityFrameworkCore;
using TechChallenge.Application.Services;
using TechChallenge.Domain.Repository;
using TechChallenge.Infrastructure.Repository;
using TechChallenge.Infrastructure.Repository.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
  options.UseLazyLoadingProxies();
}, ServiceLifetime.Scoped);

builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
