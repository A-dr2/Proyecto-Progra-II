using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services;
using Proyecto_Progra_II.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddScoped<MyAppDbContext>();

// Servicios
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IZonasServices, ZonasServices>();
builder.Services.AddScoped<IMesaServices, MesasServices>();
builder.Services.AddScoped<IEstadoMesaServices, EstadoMesaServices>();
builder.Services.AddScoped<IReservaServices, ReservaServices>();
builder.Services.AddScoped<IListaDeEsperaServices, ListaDeEsperaServices>();
builder.Services.AddScoped<ITurnoServices, TurnoServices>();

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