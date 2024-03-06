using Microsoft.EntityFrameworkCore;
using ProdutoExempoApiSolid.Data;
using ProdutoExempoApiSolid.Repository;
using ProdutoExempoApiSolid.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProdutoDbContext>(options =>
{
       options.UseSqlServer("Server=localhost;Database=db_produto;Trusted_Connection=True");
});

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
