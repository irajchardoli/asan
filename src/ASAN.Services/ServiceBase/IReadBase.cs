using ASAN.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASAN.Services.ServiceBase
{
    public interface IReadBase<T> : System.IDisposable where T : class , IKey64
    {
        T GetItemByKey(Int64 id, params string[] includes);

        Task<T> GetItemByKeyAsync(Int64 id, params string[] includes);

        List<T> GetItems(Expression<Func<T, bool>> predicate = null, params string[] includes);

        Task<Common.PaginationViewModel<T>> GetItemsPaginationAsync(Expression<Func<T, bool>> predicate, int pageNo, int pageSize, params string[] includes);

        Task<List<T>> GetItemsAsync(Expression<Func<T, bool>> predicate = null, params string[] includes);

        Task<bool> AnyItemsAsync(Expression<Func<T, bool>> predicate = null);
    }
}
