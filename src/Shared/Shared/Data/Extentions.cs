namespace Shared.Data;

public static class Extentions
{
    public static IApplicationBuilder UseMigration<TContext>(this IApplicationBuilder app)
                  where TContext : DbContext
    {
        MigrateDatabaseAsync<TContext>(app.ApplicationServices).GetAwaiter().GetResult();

        SeedDataAsync(app.ApplicationServices).GetAwaiter().GetResult();

        return app;
    }

    private static async Task SeedDataAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var seeders = scope.ServiceProvider.GetServices<IDataSeeder>();

        foreach (var seed in seeders)
        {
            await seed.SeedAllAsync();
        }
    }

    public static async Task MigrateDatabaseAsync<TContext>(IServiceProvider services)
                  where TContext : DbContext
    {
        using var scope = services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<TContext>();

        await context.Database.MigrateAsync();

    }
}
