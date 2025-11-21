using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations;
public class AmigoRepository : IAmigoRepository
{
    private readonly AppDbContext _context;

    public AmigoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Amigo>> GetAll()
        => await _context.Amigos.ToListAsync();

    public async Task<Amigo?> GetById(int id)
        => await _context.Amigos.FindAsync(id);

    public async Task Create(Amigo amigo)
        => await _context.Amigos.AddAsync(amigo);

    public void Update(Amigo amigo)
        => _context.Amigos.Update(amigo);

    public void Delete(Amigo amigo)
        => _context.Amigos.Remove(amigo);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

}
