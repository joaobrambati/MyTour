using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface IBandaRepository
{
    Task<List<Banda>> GetAll();
    Task<Banda?> GetById(int id);
    Task Create(Banda banda);
    void Update(Banda banda);
    void Delete(Banda banda);
    Task SaveChangesAsync();
}