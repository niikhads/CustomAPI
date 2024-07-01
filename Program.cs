using Npgsql;
using WebApplication2.Repositories;
using WebApplication2.Repositories.IRepositories;
using WebApplication2.Services;
using WebApplication2.Services.ServicesInterface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryDapperRepository>();
builder.Services.AddScoped<IProductRepository, ProductDapperRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<NpgsqlConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
