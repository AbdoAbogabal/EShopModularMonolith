namespace Shared.Extentions;

public static class CarterExtentions
{
    public static IServiceCollection AddCarterWithAssemplies(this IServiceCollection services, params Assembly[] assemblies)
    {
        return services.AddCarter(configurator: config =>
        {
            foreach (var assembly in assemblies)
            {
                var modules = assembly.GetTypes()
                                      .Where(t => t.IsAssignableTo(typeof(ICarterModule))).ToArray();

                config.WithModules(modules);
            }

        });
    }
}
