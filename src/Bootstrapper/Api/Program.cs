
var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddBasketModule(config)
                .AddCatelogModule(config)
                .AddOrderingModule(config);

var app = builder.Build();

app.UseBasketModule()
   .UseCatelogModule()
   .UseOrderingModule();

app.Run();
