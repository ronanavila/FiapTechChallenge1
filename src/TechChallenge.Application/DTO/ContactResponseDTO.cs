using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.DTO;
public record ContactResponseDTO(Guid Guid, string Name, string Email, int DDD, string Phone, Region Region)
{
}