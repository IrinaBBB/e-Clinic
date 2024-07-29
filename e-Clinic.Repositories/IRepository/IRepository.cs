using e_Clinic.DataAccess.Entities;
using System.Linq.Expressions;

namespace e_Clinic.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<IEnumerable<T>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50, Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        Task<int> GetPageCount(int pageSize);
        Task<bool> CreateUserWithIdentityAsync<U>(U user, string password) where U : BaseUser;
        Task<bool> RemoveUserWithIdentityAsync<U>(U user) where U : BaseUser;
    }
}
