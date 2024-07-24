using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.DTO;
public record ContactUpdateDTO(Guid Guid, string Name, string Email, int DDD, string Phone)
{
}


