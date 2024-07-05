using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Deportivo.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentity<User, IdentityRole>(cfg =>
{
    cfg.User.RequireUniqueEmail = true;
    cfg.Password.RequireDigit = false;
    cfg.Password.RequiredUniqueChars = 0;
    cfg.Password.RequireLowercase = false;
    cfg.Password.RequireUppercase = false;
    cfg.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<DataContext>();


//builder.Services.AddTransient<SeedDb>();
builder.Services.AddScoped<IAccesorios, AccesoriosService>();
builder.Services.AddScoped<IAdicionales, AdicionalesService>();
builder.Services.AddScoped<ICliente, ClienteService>();
builder.Services.AddScoped<IDeportivoAccesorio, DeportivoAccesorioService>();
builder.Services.AddScoped<IEspacioDeportivo, EspacioDeportivoService>();
builder.Services.AddScoped<IHorario, HorarioService>();
builder.Services.AddScoped<IPagoCabecera, PagoService>();
builder.Services.AddScoped<ITipoDeportivo, TipoDeportivoService>();
builder.Services.AddScoped<ITipoDocumento, TipoDocumentoService>();
builder.Services.AddScoped<IPagoCabecera, PagoService>();
builder.Services.AddScoped<IInicial, InicialServices>();
builder.Services.AddScoped<IEgresos, EgresosServices>();
builder.Services.AddScoped<ICaja, CajaServices>();
builder.Services.AddScoped<INumeracion, NumeracionServices>();
builder.Services.AddScoped<IUsers, UserServices>();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        o.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Obtiene una instancia de SeedDb
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var seedDb = services.GetRequiredService<SeedDb>();

//    // Ejecuta el método SeedAsync para sembrar la base de datos
//    await seedDb.SeedAsync();
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Deportivo"));

app.Run();
