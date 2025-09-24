var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCarterWithAssemplies(typeof(CatelogModule).Assembly);

var config = builder.Configuration;

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
