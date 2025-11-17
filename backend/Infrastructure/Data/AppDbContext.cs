using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Show> Shows { get; set; }
    public DbSet<Banda> Bandas { get; set; }
    public DbSet<Amigo> Amigos { get; set; }
}
