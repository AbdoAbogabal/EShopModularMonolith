var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));


var basketAssembly = typeof(BasketModule).Assembly;
var catelogAssembly = typeof(CatelogModule).Assembly;

builder.Services.AddMediatRWithAssemplies(basketAssembly, catelogAssembly);

builder.Services.AddCarterWithAssemplies(basketAssembly, catelogAssembly);

var config = builder.Configuration;

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = config.GetConnectionString("Redis");
});

builder.Services.AddBasketModule(config)
                .AddCatelogModule(config)
                .AddOrderingModule(config);

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.MapCarter();
app.UseSerilogRequestLogging();
app.UseExceptionHandler(options => { });

app.UseBasketModule()
   .UseCatelogModule()
   .UseOrderingModule();


app.Run();
