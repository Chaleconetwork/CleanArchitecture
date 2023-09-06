using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        // IEnumerable -> Func: 
        // IQueryable  -> Expression: Representa condiciónes lógicas de mi futura query que a futuro se transformará en una sintaxis de tipo SQL. Las expresiones pueden ser muy dinamicas y varaibles, esto permite ser más flexible a la hora de crear consultas más complejas
        // Delegate: Permite pasar los métodos de una función como parámetros

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>
                                                                  orberBy = null,
                                                                  string includeString = null,
                                                                  bool disableTracking = true);

        // Paginación
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>
                                                                  orberBy = null,
                                                                  List<Expression<Func<T, object>>> includes = null,
                                                                  bool disableTracking = true);
    }
}
