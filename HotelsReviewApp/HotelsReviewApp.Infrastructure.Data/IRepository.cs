using HotelsReviewApp.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelsReviewApp.Infrastructure.Data
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> QueryAll();
        IQueryable<T> QueryAllNoTracking();
        void Add(T item);
        void Delete(T item);
        void Delete(int id);
        T FindById(int id);
        Task<T> FindByIdAsync(int id);
        void DeleteRange(IEnumerable<T> entities);
    }
}
