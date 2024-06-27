 using Microsoft.EntityFrameworkCore.ChangeTracking;
 using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ordering.infrastructure.Data.Interceptors
{
    public class AuditableEntityInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }


        public void UpdateEntities(DbContext? context) {
            if (context is null) return;
            foreach (var entry in context.ChangeTracker.Entries<IEntity>())
            {
                if (entry.State == EntityState.Added) {
                    entry.Entity.CreatedBy = "Mahmoud";
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
                {
                    entry.Entity.LastModifiedBy = "Mahmoud";
                    entry.Entity.LastModified = DateTime.UtcNow;
                }
            }
        }

    }

    public static class Extentions {
        public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
                entry.References.Any(r =>
                    r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified)

                );
    }

}
