using Aplicacion.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers.ContextoCatalogos
{
    [ApiController]
    [Route("api/Catalogos/[controller]")]
    public class CatalogoCiudadEstadoController : ControllerBase
    {
        private readonly IServicioCatalogoCiudadEstado _servicioCatalogoCiudadEstado;

        public CatalogoCiudadEstadoController(IServicioCatalogoCiudadEstado servicioCatalogoCiudadEstado)
        {
            _servicioCatalogoCiudadEstado = servicioCatalogoCiudadEstado;
        }

        [HttpGet("{nombre}")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Resultado Success de la API - Código 200", typeof(IEnumerable<string>))]
        [SwaggerOperation(Summary = "Obtener cátalogo ciudad y estado por nombre", Description = "Obtiene el catálogo catalogo ciudad y estado por nombre", OperationId = "ObtenerCatalogoCiudadEstadoPorNombre")]
        public IActionResult Get(string nombre)
        {
            IEnumerable<string> resultado = _servicioCatalogoCiudadEstado.ObtenerPorNombre(nombre);

            return new JsonResult(resultado);
        }

        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(200, "Resultado Success de la API - Código 200", typeof(IEnumerable<string>))]
        [SwaggerOperation(Summary = "Obtener cátalogo ciudad y estado", Description = "Obtiene el catálogo catalogo ciudad y estado", OperationId = "ObtenerCatalogoCiudadEstado")]
        public IActionResult Get()
        {
            IEnumerable<string> resultado = _servicioCatalogoCiudadEstado.ObtenerPorNombre("");

            return new JsonResult(resultado);
        }
    }
}
