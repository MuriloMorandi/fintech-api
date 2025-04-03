using Aplicacao.Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Definindo as tabelas (entidades) do banco de dados
    public DbSet<ContasBancarias> ContasBancarias { get; set; }
    public DbSet<TransacoesBancarias> TransacoesBancarias { get; set; }
    public DbSet<Categorias> Categorias { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region ContasBancarias
        modelBuilder.Entity<ContasBancarias>().ToTable("ContasBancarias");
        modelBuilder.Entity<ContasBancarias>().HasKey(t => t.Id);
        
        

        #endregion
        
        #region Usuarios
        modelBuilder.Entity<Usuario>().ToTable("Usuarios");
        modelBuilder.Entity<Usuario>().HasKey(t => t.Id);
        modelBuilder.Entity<Usuario>().HasIndex(p => p.Email).IsUnique();
        modelBuilder.Entity<Usuario>().Property(f => f.Nome).IsRequired().HasMaxLength(100);

        #endregion
    }

}
