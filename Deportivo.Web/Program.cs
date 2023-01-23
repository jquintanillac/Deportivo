using Deportivo.Web.Data;
using Deportivo.Web.IServices;
using Deportivo.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IAccesorios, AccesoriosService>();
builder.Services.AddScoped<IAdicionales, AdicionalesService>();
builder.Services.AddScoped<ICliente, ClienteService>();
builder.Services.AddScoped<IDeportivoAccesorio, DeportivoAccesorioService>();
builder.Services.AddScoped<IEspacioDeportivo, EspacioDeportivoService>();
builder.Services.AddScoped<IHorario, HorarioService>();
builder.Services.AddScoped<IPagoCabecera, PagoService>();
builder.Services.AddScoped<ITipoDeportivo, TipoDeportivoService>();
builder.Services.AddScoped<ITipoDocumento, TipoDocumentoService>();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        o.JsonSerializerOptions.PropertyNamingPolicy = null;
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

app.Run();
