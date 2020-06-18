﻿using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ASAN.Entities.Interfaces;

namespace ASAN.Entities.Infrastructure
{
    public static class AuditableShadowProperties
    {
        public static readonly Func<object, string> EFPropertyCreatedByBrowserName =
                                        entity => EF.Property<string>(entity, CreatedByBrowserName);
        public static readonly string CreatedByBrowserName = nameof(CreatedByBrowserName);

        public static readonly Func<object, string> EFPropertyModifiedByBrowserName =
                                        entity => EF.Property<string>(entity, ModifiedByBrowserName);
        public static readonly string ModifiedByBrowserName = nameof(ModifiedByBrowserName);

        public static readonly Func<object, string> EFPropertyCreatedByIp =
                                        entity => EF.Property<string>(entity, CreatedByIp);
        public static readonly string CreatedByIp = nameof(CreatedByIp);

        public static readonly Func<object, string> EFPropertyModifiedByIp =
                                        entity => EF.Property<string>(entity, ModifiedByIp);
        public static readonly string ModifiedByIp = nameof(ModifiedByIp);

        public static readonly Func<object, DateTimeOffset?> EFPropertyCreatedDateTime =
                                        entity => EF.Property<DateTimeOffset?>(entity, CreatedDateTime);
        public static readonly string CreatedDateTime = nameof(CreatedDateTime);

        public static readonly Func<object, DateTimeOffset?> EFPropertyModifiedDateTime =
                                        entity => EF.Property<DateTimeOffset?>(entity, ModifiedDateTime);
        public static readonly string ModifiedDateTime = nameof(ModifiedDateTime);


        public static void AddAuditableShadowProperties(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model
                                                   .GetEntityTypes()
                                                   .Where(e => typeof(IAuditableEntity).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                            .Property<string>(CreatedByBrowserName).HasMaxLength(1000);
                modelBuilder.Entity(entityType.ClrType)
                            .Property<string>(ModifiedByBrowserName).HasMaxLength(1000);

                modelBuilder.Entity(entityType.ClrType)
                            .Property<string>(CreatedByIp).HasMaxLength(255);
                modelBuilder.Entity(entityType.ClrType)
                            .Property<string>(ModifiedByIp).HasMaxLength(255);

                modelBuilder.Entity(entityType.ClrType)
                            .Property<DateTimeOffset?>(CreatedDateTime);
                modelBuilder.Entity(entityType.ClrType)
                            .Property<DateTimeOffset?>(ModifiedDateTime);
            }
        }

        public static void SetAuditableEntityPropertyValues(
            this ChangeTracker changeTracker,
            IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor?.HttpContext;
            var userAgent = httpContext?.Request?.Headers["User-Agent"].ToString();
            var userIp = httpContext?.Connection?.RemoteIpAddress?.ToString();
            var now = DateTimeOffset.Now;

            var modifiedEntries = changeTracker.Entries<IAuditableEntity>()
                                               .Where(x => x.State == EntityState.Modified);
            foreach (var modifiedEntry in modifiedEntries)
            {
                modifiedEntry.Property(ModifiedDateTime).CurrentValue = now;
                modifiedEntry.Property(ModifiedByBrowserName).CurrentValue = userAgent;
                modifiedEntry.Property(ModifiedByIp).CurrentValue = userIp;
            }

            var addedEntries = changeTracker.Entries<IAuditableEntity>()
                                            .Where(x => x.State == EntityState.Added);
            foreach (var addedEntry in addedEntries)
            {
                addedEntry.Property(CreatedDateTime).CurrentValue = now;
                addedEntry.Property(CreatedByBrowserName).CurrentValue = userAgent;
                addedEntry.Property(CreatedByIp).CurrentValue = userIp;
            }
        }
    }
}