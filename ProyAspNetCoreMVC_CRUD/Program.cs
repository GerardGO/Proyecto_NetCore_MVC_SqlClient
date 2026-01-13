using ProyAspNetCoreMVC_CRUD.Dao;
using ProyAspNetCoreMVC_CRUD.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DBHelper>();
builder.Services.AddScoped<IClienteDao, ClienteDao>();
builder.Services.AddScoped<IDistritoDao, DistritoDao>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cliente}/{action=IndexCliente}/{id?}");

app.Run(); 
