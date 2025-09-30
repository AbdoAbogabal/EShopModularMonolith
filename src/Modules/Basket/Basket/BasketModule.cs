namespace Basket;

public static class BasketModule
{
    public static IServiceCollection AddBasketModule(this IServiceCollection services,
                                                          IConfiguration configuration)
    {

        services.AddScoped<IBasketRepository, BasketRepository>();
        services.Decorate<IBasketRepository, CachedBasketRepository>();

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispathDomainEventInterceptor>();

        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<BasketDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString);
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });

        return services;
    }


    public static IApplicationBuilder UseBasketModule(this IApplicationBuilder app)
    {

        app.UseMigration<BasketDbContext>();

        return app;
    }
}
