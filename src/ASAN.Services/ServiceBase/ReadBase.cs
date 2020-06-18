using ASAN.Common;
using ASAN.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASAN.Services.ServiceBase
{
    public abstract class ReadBase<T> : IReadBase<T> where T : class , IKey64
    {
        #region fields

        protected ASAN.DataLayer.Context.IUnitOfWork _uow;

        //protected readonly IOptionsSnapshot<ApplicationSettings> _applicationSettings;

        protected readonly ILogger<ReadBase<T>> _logger;

        //protected readonly IStringLocalizer _resourceLocalizer;

        //protected readonly AutoMapper.IMapper _mapper;

        protected readonly DbSet<T> _entities;

        protected readonly IQueryable<T> _query;

        #endregion fields

        #region Constructor

        public ReadBase(ILogger<ReadBase<T>> logger,
              //IOptionsSnapshot<ApplicationSettings> applicationSettings,
              ASAN.DataLayer.Context.IUnitOfWork uow)
        {
            _uow = uow;

            _logger = logger;

            _entities = _uow.Set<T>();
            this._query = _entities.AsQueryable();
        }

        #endregion Constructor

        #region dispose

        public void Dispose()
        {

        }

        #endregion dispose

        #region methods

        public T GetItemByKey(Int64 id, params string[] includes)
        {
            var query = this._query.AsNoTracking();

            includes = includes.OrEmptyIfNull().ToArray();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entityItem = query.Where(c => c.Id == id).SingleOrDefault();

            return entityItem;
        }

        public async Task<T> GetItemByKeyAsync(Int64 id, params string[] includes)
        {
            var query = this._query.AsNoTracking();

            includes = includes.OrEmptyIfNull().ToArray();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            var entityItem = await query.Where(c => c.Id == id).SingleOrDefaultAsync();

            return entityItem;
        }

        public List<T> GetItems(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            var query = this._query.AsNoTracking();

            includes = includes.OrEmptyIfNull().ToArray();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
                query = query.Where(predicate);

            var entityItems = query.ToList();

            return entityItems;
        }

        public async Task<Common.PaginationViewModel<T>> GetItemsPaginationAsync(Expression<Func<T, bool>> predicate ,int pageNo ,int pageSize, params string[] includes)
        {
            var result = new Common.PaginationViewModel<T>();
            var myquery = this._query.AsNoTracking();

            includes = includes.OrEmptyIfNull().ToArray();

            foreach (var include in includes)
            {
                myquery = myquery.Include(include);
            }

            if (predicate != null)
                myquery = myquery.Where(predicate);

            if (pageNo < 1)
                pageNo = 1;

            if (pageSize <= 0)
                pageSize = 10;

            result.ModelItems = await myquery.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);
            result.TotalRecord = await myquery.CountAsync().ConfigureAwait(false);

            result.PageNo = pageNo;
            result.PageSize = pageSize;

            return result;
        }

        public async Task<List<T>> GetItemsAsync(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            var query = this._query.AsNoTracking();

            includes = includes.OrEmptyIfNull().ToArray();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (predicate != null)
                query = query.Where(predicate);

            var entityItems = await query.ToListAsync().ConfigureAwait(false);
            return entityItems;
        }

        public async Task<bool> AnyItemsAsync(Expression<Func<T, bool>> predicate = null)
        {
            var myquery = this._query.AsNoTracking();

            if (predicate != null)
                myquery = myquery.Where(predicate);

            return (await myquery.AnyAsync().ConfigureAwait(false));
        }

        #endregion methods
    }
}
