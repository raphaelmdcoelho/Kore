using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Restaurant.Products;
using Restaurant.Infra.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(sg => 
{
    sg.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "Restaurant API", 
        Version = "v1", 
        Description = "A simple API to manage a restaurant"
    });
});

builder.Services.AddDbContext<RestaurantDbContext>(options => 
{
    options.UseInMemoryDatabase("RestaurantDb");
});

builder.Services.AddProducts();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => 
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizza Store API");
});

//app.UseEndpoints(endpoints =>  endpoints.MapControllers());
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
