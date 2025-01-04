using Core.Interfaces;
using InfraStructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddControllers();

builder.Services.AddDbContext<StoreContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionStr"));
});
builder.Services.AddScoped<IProductRepositry,ProductRepositry>();

var app = builder.Build();




app.MapControllers();

app.Run();
