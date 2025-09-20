namespace Shared.Interceptor;

public static class Extentions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
           entry.References.Any(r =>
                    r.TargetEntry is not null &&
                    r.TargetEntry.Metadata.IsOwned() &&
                    (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}