using Aplicacion.ContextoMensaje.AgregadoDatosContacto;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers.ContextoMensaje
{
    [ApiController]
    [Route("api/Mensaje/[controller]")]
    public class DatosContactoController : ControllerBase
    {
        private readonly IServicioDatosContacto _servicioDatosContacto;

        public DatosContactoController(IServicioDatosContacto servicioDatosContacto)
        {
            _servicioDatosContacto = servicioDatosContacto;
        }

        [HttpPost]
        [SwaggerResponse(200, "Resultado Success de la API - Código 200", typeof(OkResult))]
        [SwaggerOperation(Summary = "Enviar mensaje con datos de contacto", Description = "Envia mensaje con datos de contacto", OperationId = "EnviarMensajeDatosContacto")]
        public IActionResult Post([FromBody, SwaggerRequestBody("Dto Enviar Mensaje Datos Contacto", Required = true)] DtoEnviarMensajeDatosContacto dtoEnviar)
        {
            _servicioDatosContacto.EnviarMensaje(dtoEnviar);

            return new OkResult();
        }
    }
}
