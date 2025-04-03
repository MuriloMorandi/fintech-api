using Aplicacao.Dominio.Entities;
using Aplicacao.Dominio.Intefaces;
using Aplicacao.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao.Infra.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;
    

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    #region Command

    public async Task<int> Create(Usuario entity)
    {
        await _context.Set<Usuario>().AddAsync(entity);
        await _context.SaveChangesAsync();
        
        return entity.Id;
    }

    public async Task Update(int id, Usuario entity)
    {
        var usuario = await this.GetById(id);
        if (usuario != null)
        {
            usuario.Nome = entity.Nome;
            usuario.Email = entity.Email;
            
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task Remove(int id)
    {
        var usuario = await this.GetById(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }

    #endregion

    #region Query
    
    public async Task<IEnumerable<Usuario>> ReadAll()
    {
        return await _context.Set<Usuario>().ToListAsync();
    }
    
    public async Task<Usuario?> GetById(int id)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Id == id);
    }
    
    public async Task<Usuario?> GetByEmail(string email)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == email);
    }
    
    public async Task<Usuario?> GetByEmail(string email, int id)
    {
        return await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == email && u.Id != id);
    }

    #endregion
}