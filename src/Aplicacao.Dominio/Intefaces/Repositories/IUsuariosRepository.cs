using Aplicacao.Dominio.Entities;

namespace Aplicacao.Dominio.Intefaces;

public interface IUsuarioRepository : IBaseRepository<Usuario, int>
{
    Task<Usuario?> GetByEmail(string email);
    Task<Usuario?> GetByEmail(string email, int id);
}