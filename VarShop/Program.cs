using Microsoft.EntityFrameworkCore;
using VarShop.Models.Context;
using VarShop.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 0, 29)))
);

builder.Services.AddScoped<CarrinhoRepository>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<VendedorRepository>();

// Configurar o uso de sessões no pipeline de middleware
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Defina o tempo limite da sessão como desejado
});

var app = builder.Build();

// Configure o HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configure o uso de sessões
app.UseSession();

app.MapControllerRoute(
    name: "EditarProduto",
    pattern: "Vendedor/EditarProduto/{id}",
    defaults: new { controller = "Vendedor", action = "EditarProduto" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();