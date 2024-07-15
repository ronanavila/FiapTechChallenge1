using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Repository;
public interface IRepository<T> where T : BaseEntity
{
  Task<IList<T>> GetAll();
  Task<T> GetById(Guid guid);
  Task<T> Create(T entidade);
  void Update(T entidade);
  void Delete(Guid guid);
}
