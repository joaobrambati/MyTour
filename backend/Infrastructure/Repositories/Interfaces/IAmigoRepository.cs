using Domain.Entities;

namespace Infrastructure.Repositories.Interfaces;

public interface IAmigoRepository
{
    Task<List<Amigo>> GetAll();
    Task<Amigo?> GetById(int id);
    Task Create(Amigo amigo);
    void Update(Amigo amigo);
    void Delete(Amigo amigo);
    Task SaveChangesAsync();
}
