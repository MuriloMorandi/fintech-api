using Aplicacao.Dominio.Entities;
using Aplicacao.Dominio.Intefaces;
using Aplicacao.Infra.Context;

namespace Aplicacao.Infra.Repositories;

public class ContasBancariasRepository : IBaseRepository<ContasBancarias, int>
{
    private readonly AppDbContext _context;
    private IBaseRepository<ContasBancarias, int> _baseRepositoryImplementation;

    public ContasBancariasRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Create(ContasBancarias entity)
    {
        await _context.Set<ContasBancarias>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return 0;
    }

    public Task Update(int id, ContasBancarias entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ContasBancarias>> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Task Remove(int id)
    {
        throw new NotImplementedException();
    }
    
    public async Task<ContasBancarias?> GetById(int id)
    {
        return await _context.Set<ContasBancarias>().FindAsync(id);
    }
    
}