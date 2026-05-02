using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services;
using Proyecto_Progra_II.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MyAppDbContext>();

builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IReservaServices, ReservasServices>();
builder.Services.AddScoped<IListaDeEsperaServices, ListaDeEsperaServices>();
builder.Services.AddScoped<IEstadoMesaServices, EstadoMesaServices>();
builder.Services.AddScoped<IMesasServices, MesasServices>();
builder.Services.AddScoped<ITurnoServices, TurnoServices>();
builder.Services.AddScoped<IZonasServices, ZonasServices>(); 

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