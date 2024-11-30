using Microsoft.EntityFrameworkCore;
using sistema_academico.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<usuario> Usuarios { get; set; } // Tabla de usuarios
   
}
