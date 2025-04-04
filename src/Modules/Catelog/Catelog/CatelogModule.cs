namespace Catelog;

public static class CatelogModule
{
    public static IServiceCollection AddCatelogModule(this IServiceCollection services,
                                                           IConfiguration configuration)
    {


        return services;
    }

    public static IApplicationBuilder UseCatelogModule(this IApplicationBuilder app)
    {

        return app;
    }
}
