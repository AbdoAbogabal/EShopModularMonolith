namespace Catelog;
public static class CatelogModule
{
    public static IServiceCollection AddCatelogModule(this IServiceCollection services,
                                                           IConfiguration configuration)
    {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispathDomainEventInterceptor>();

        var connectionString = configuration.GetConnectionString("Database");
        services.AddDbContext<CatelogDbContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString);
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
        });

        services.AddScoped<IDataSeeder, CatelogDataSeeder>();

        return services;
    }

    public static IApplicationBuilder UseCatelogModule(this IApplicationBuilder app)
    {

        app.UseMigration<CatelogDbContext>();

        return app;
    }
}
