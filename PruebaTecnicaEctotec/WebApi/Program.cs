using Aplicacion.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using Aplicacion.ContextoMensaje.AgregadoDatosContacto;
using Dominio.Comunes.Servicios;
using Dominio.Comunes.UnidadDeTrabajo;
using Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using Infraestructura.Comunes.Servicios;
using Infraestructura.Comunes.UnidadDeTrabajo;
using Infraestructura.ContextoCatalogos.AgregadoCatalogoCiudadEstado;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Comunes
builder.Services.AddTransient<IUnidadDeTrabajo>(s => new UnidadDeTrabajoSql(builder.Configuration.GetConnectionString("Db")));
builder.Services.AddTransient<IServicioEnvioCorreos, ServicioEnvioCorreos>();
#endregion

#region Agregado Catalogo Ciudad y Estado
builder.Services.AddTransient<IRepositorioCatalogoCiudadEstado, RepositorioCatalogoCiudadEstadoSql>();
builder.Services.AddTransient<IServicioCatalogoCiudadEstado, ServicioCatalogoCiudadEstado>();
#endregion

#region Agregado Catalogo Datos de Contacto
builder.Services.AddTransient<IServicioDatosContacto, ServicioDatosContacto>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
