using Proyecto_Progra_II.MiDbContext;
using Proyecto_Progra_II.Services;
using Proyecto_Progra_II.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<MyAppDbContext>();
builder.Services.AddScoped<IClienteServices, ClienteServices>();
builder.Services.AddScoped<IReservaServices, ReservasServices>();    
builder.Services.AddScoped<IListaDeEsperaServices, ListaDeEsperaServices>();
builder.Services.AddScoped<IEstadoMesaServices, EstadoMesaServices>();
builder.Services.AddScoped<IMesasServices, MesasServices>();
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
