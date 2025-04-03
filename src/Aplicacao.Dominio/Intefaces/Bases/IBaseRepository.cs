namespace Aplicacao.Dominio.Intefaces;

public interface IBaseRepository<T, TKeyId> where T : class
{
    Task<TKeyId> Create(T entity);
    Task Update(TKeyId id,T entity);
    Task<IEnumerable<T>> ReadAll();
    Task Remove(TKeyId id);
    Task<T?> GetById(TKeyId id);
}