using ASAN.Entities.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ASAN.DataLayer.Context
{
    public class ApplicationDbContext : DbContext ,IUnitOfWork
    {
        #region Constructor

        // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #endregion Constructor

        #region BaseMethods

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().AddRange(entities);
        }

        public void ExecuteSqlCommand(string query)
        {
            Database.ExecuteSqlCommand(query);
        }

        public void ExecuteSqlCommand(string query, params object[] parameters)
        {
            Database.ExecuteSqlCommand(query, parameters);
        }

        public T GetShadowPropertyValue<T>(object entity, string propertyName) where T : IConvertible
        {
            var value = this.Entry(entity).Property(propertyName).CurrentValue;
            return value != null
                ? (T)Convert.ChangeType(value, typeof(T), System.Globalization.CultureInfo.InvariantCulture)
                : default(T);
        }

        public object GetShadowPropertyValue(object entity, string propertyName)
        {
            return this.Entry(entity).Property(propertyName).CurrentValue;
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            Update(entity);
        }

        public void MarksAsChanged<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            UpdateRange(entities);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            Set<TEntity>().RemoveRange(entities);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ChangeTracker.DetectChanges();
            beforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.

            var result = base.SaveChanges(acceptAllChangesOnSuccess);

            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            beforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.

            var result = base.SaveChanges();

            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            beforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.

            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            beforeSaveTriggers();
            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.

            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken).ConfigureAwait(false);

            ChangeTracker.AutoDetectChangesEnabled = true;
            return result;
        }

        private void beforeSaveTriggers()
        {
            validateEntities();
            setShadowProperties();
        }

        private void setShadowProperties()
        {
            // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
            var httpContextAccessor = this.GetService<IHttpContextAccessor>();
            ChangeTracker.SetAuditableEntityPropertyValues(httpContextAccessor);
        }

        private void validateEntities()
        {
            var errors = this.GetValidationErrors();
            if (!string.IsNullOrWhiteSpace(errors))
            {
                // we can't use constructor injection anymore, because we are using the `AddDbContextPool<>`
                var loggerFactory = this.GetService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<ApplicationDbContext>();
                logger.LogError(errors);
                throw new InvalidOperationException(errors);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new ASAN.DataLayer.Mappings.OwnerMappings(builder.Entity<ASAN.Entities.Owner>());
            new ASAN.DataLayer.Mappings.EstateMappings(builder.Entity<ASAN.Entities.Estate>());

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(builder);

            // This should be placed here, at the end.
            builder.AddAuditableShadowProperties();
        }

        #endregion BaseMethods

        #region DbSets

        public virtual DbSet<ASAN.Entities.Owner> Owners { get; set; }
        public virtual DbSet<ASAN.Entities.Estate> Estates { get; set; }

        #endregion DbSets
    }
}
