namespace Ordering;

public static class OrderingModule
{
    public static IServiceCollection AddOrderingModule(this IServiceCollection services,
                                                           IConfiguration configuration)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispathDomainEventInterceptor>();

        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<OrderingDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString);
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });

        return services;
    }

    public static IApplicationBuilder UseOrderingModule(this IApplicationBuilder app)
    {

        app.UseMigration<OrderingDbContext>();

        return app;
    }
}
