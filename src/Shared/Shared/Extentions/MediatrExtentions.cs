namespace Shared.Extentions;

public static class MediatrExtentions
{
    public static IServiceCollection AddMediatRWithAssemplies(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(assemblies);
            cfg.AddOpenBehavior(typeof(ValidationBehaviors<,>));
            cfg.AddOpenBehavior(typeof(LoggerBehaviors<,>));
        });

        services.AddValidatorsFromAssemblies(assemblies);

        return services;
    }

}
