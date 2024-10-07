using ecommerce_linktic.Data;
using ecommerce_linktic.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Servicio de prodcutos
builder.Services.AddScoped<IProductosService, ProductosService>();
//Servicio de categorias
builder.Services.AddScoped<ICategoriasService, CategoriasService>();
//Servicio de tiendas
builder.Services.AddScoped<ITiendasService, TiendasService>();
//Servicio de categoria productos
builder.Services.AddScoped<ICategoriaProductoService, CategoriaProductoService>();
//Servicio de tienda productos
builder.Services.AddScoped<ITiendaProductosService, TiendaProductosService>();
//Servicio de pedidos
builder.Services.AddScoped<IPedidosService, PedidosService>();
//Servicio de pedidos productos
builder.Services.AddScoped<IPedidosProductosService, PedidosProductosService>();

builder.Services.AddDbContext<AppDBContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

AppDbInitializer.Seed(app);

app.Run();
