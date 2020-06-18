using ASAN.Common;
using ASAN.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ASAN.Services.ServiceBase
{
    public interface ICrudBase<T> : IReadBase<T> where T : class, IKey64
    {
        Task<ServiceResultInfo> CreateAsync(T entityItem, bool savechange = true);

        Task<ServiceResultInfo> CreateAsync(IEnumerable<T> entityItems, bool savechange = true);

        Task<ServiceResultInfo> UpdateAsync(T entityItem, bool savechange = true);

        Task<ServiceResultInfo> UpdateAsync(IEnumerable<T> entityItems, bool savechange = true);

        Task<ServiceResultInfo> DeleteByKeysAsync(Int64 id, bool savechange = true);

        Task<ServiceResultInfo> DeleteByKeysAsync(List<Int64> ids, bool savechange = true);
    }
}