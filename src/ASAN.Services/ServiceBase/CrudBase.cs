using ASAN.Common;
using ASAN.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAN.Services.ServiceBase
{
    public abstract class CrudBase<T> : ReadBase<T>, ICrudBase<T> where T : class, IKey64
    {
        #region Fields

        private Int64 _minimumValue = default(Int64);

        #endregion Fields

        #region Constructor

        public CrudBase(ILogger<ReadBase<T>> logger,
              ASAN.DataLayer.Context.IUnitOfWork uow) : base(logger, uow)
        {
        }

        #endregion Constructor

        #region PrivateMethods

        private void RemoveRangeRecords(IEnumerable<T> entities)
        {
            base._entities.RemoveRange(entities);
        }

        private void RemoveRecord(T entity)
        {
            base._entities.Remove(entity);
        }

        private void AddRecord(T entity)
        {
            base._entities.Add(entity);
        }

        private async void AddRecordAsync(T entity)
        {
            await base._entities.AddAsync(entity).ConfigureAwait(false);
        }

        private void AddRangeRecords(IEnumerable<T> entities)
        {
            base._entities.AddRange(entities);
        }

        private async void AddRangeRecordsAsync(IEnumerable<T> entities)
        {
            await base._entities.AddRangeAsync(entities).ConfigureAwait(false);
        }

        private void UpdateRecord(T entity)
        {
            base._entities.Update(entity);
        }

        private void UpdateRangeRecords(IEnumerable<T> entities)
        {
            base._entities.UpdateRange(entities);
        }

        #endregion PrivateMethods

        #region PublicMethods

        public virtual async Task<ServiceResultInfo> CreateAsync(T entityItem, bool savechange = true)
        {
            var serviceResult = new ServiceResultInfo();

            this.AddRecordAsync(entityItem);

            if (savechange)
            {
                await this._uow.SaveChangesAsync().ConfigureAwait(false);

                if (entityItem.Id.CompareTo(_minimumValue) > 0)
                {
                    serviceResult.NewId = entityItem.Id;
                    serviceResult.Succeeded = true;
                }
                else
                {
                    serviceResult.Succeeded = false;
                }
            }
            else
            {
                serviceResult.Succeeded = true;
            }

            return serviceResult;
        }

        public virtual async Task<ServiceResultInfo> CreateAsync(IEnumerable<T> entityItems, bool savechange = true)
        {
            var serviceResult = new ServiceResultInfo();

            this.AddRangeRecordsAsync(entityItems);

            if (savechange)
            {
                await this._uow.SaveChangesAsync().ConfigureAwait(false);
            }

            serviceResult.Succeeded = true;

            return serviceResult;
        }

        public virtual async Task<ServiceResultInfo> UpdateAsync(T entityItem, bool savechange = true)
        {
            var serviceResult = new ServiceResultInfo();

            this.UpdateRecord(entityItem);

            if (savechange)
            {
                await this._uow.SaveChangesAsync().ConfigureAwait(false);                
            }

            serviceResult.Succeeded = true;

            return serviceResult;
        }

        public virtual async Task<ServiceResultInfo> UpdateAsync(IEnumerable<T> entityItems, bool savechange = true)
        {
            var serviceResult = new ServiceResultInfo();

            this.UpdateRangeRecords(entityItems);

            if (savechange)
            {
                await this._uow.SaveChangesAsync().ConfigureAwait(false);                
            }

            serviceResult.Succeeded = true;

            return serviceResult;
        }

        public virtual async Task<ServiceResultInfo> DeleteByKeysAsync(Int64 id, bool savechange = true)
        {
            var serviceResult = new ServiceResultInfo();

            var entityItem = await this._entities.FindAsync(id).ConfigureAwait(false);

            if (entityItem != null)
            {
                this.RemoveRecord(entityItem);

                if (savechange)
                {
                    await this._uow.SaveChangesAsync().ConfigureAwait(false);                    
                }

                serviceResult.Succeeded = true;
            }
            else
            {
                serviceResult.Succeeded = false;                
            }

            return serviceResult;
        }

        public virtual async Task<ServiceResultInfo> DeleteByKeysAsync(List<Int64> ids, bool savechange = true)
        {
            var serviceResult = new ServiceResultInfo();

            var entityItems = await this._entities.Where(c => ids.OrEmptyIfNull().Contains(c.Id)).ToListAsync().ConfigureAwait(false);

            if (entityItems?.Any() == true)
            {
                this.RemoveRangeRecords(entityItems);

                if (savechange)
                {
                    await this._uow.SaveChangesAsync().ConfigureAwait(false);                    
                }

                serviceResult.Succeeded = true;
            }
            else
            {
                serviceResult.Succeeded = false;                
            }

            return serviceResult;
        }

        #endregion PublicMethods
    }
}
