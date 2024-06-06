using ASPNetCore.Models;

namespace ASPNetCore
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        bool Exist(int id);
        Task Update(T entity);
        void Remove(int id);
        Task<T> FindById(int id);
        Task<List<T>> GetAll();
    }
}
