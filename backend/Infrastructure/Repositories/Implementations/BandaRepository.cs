using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Implementations;

public class BandaRepository : IBandaRepository
{
    private readonly AppDbContext _context;

    public BandaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Banda>> GetAll()
        => await _context.Bandas.ToListAsync();

    public async Task<Banda?> GetById(int id)
        => await _context.Bandas.FindAsync(id);

    public async Task Create(Banda banda)
        => await _context.Bandas.AddAsync(banda);

    public void Update(Banda banda)
        => _context.Bandas.Update(banda);

    public void Delete(Banda banda)
        => _context.Bandas.Remove(banda);

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

}
