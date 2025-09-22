var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarterWithAssemplies(typeof(CatelogModule).Assembly);

var config = builder.Configuration;

builder.Services.AddBasketModule(config)
                .AddCatelogModule(config)
                .AddOrderingModule(config);

var app = builder.Build();

app.MapCarter();

app.UseBasketModule()
   .UseCatelogModule()
   .UseOrderingModule();

app.Run();
