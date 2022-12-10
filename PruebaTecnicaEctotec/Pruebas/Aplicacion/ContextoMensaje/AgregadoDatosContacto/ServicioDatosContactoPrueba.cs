using Aplicacion.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using Aplicacion.ContextoMensaje.AgregadoDatosContacto;
using Dominio.Comunes.Servicios;
using Dominio.Comunes.UnidadDeTrabajo;
using Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using Infraestructura.Comunes.Servicios;
using Infraestructura.Comunes.UnidadDeTrabajo;
using Infraestructura.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas.Aplicacion.ContextoMensaje.AgregadoDatosContacto
{
    public class ServicioDatosContactoPrueba
    {
        [Fact]
        public void EnviarMensaje_DatosCorrectos_void()
        {
            var configuracion = new Mock<IConfiguration>();

            var configurationSection1 = new Mock<IConfigurationSection>();
            configurationSection1.Setup(a => a.Value).Returns("nr.mail.sender@gmail.com");
            configuracion.Setup(a => a.GetSection("EmailSettings:smtp_from")).Returns(configurationSection1.Object);

            var configurationSection2 = new Mock<IConfigurationSection>();
            configurationSection2.Setup(a => a.Value).Returns("nr.mail.sender@gmail.com");
            configuracion.Setup(a => a.GetSection("EmailSettings:smtp_user")).Returns(configurationSection2.Object);

            var configurationSection3 = new Mock<IConfigurationSection>();
            configurationSection3.Setup(a => a.Value).Returns("oqooliooicwcerco");
            configuracion.Setup(a => a.GetSection("EmailSettings:smtp_pswd")).Returns(configurationSection3.Object);

            var configurationSection4 = new Mock<IConfigurationSection>();
            configurationSection4.Setup(a => a.Value).Returns("587");
            configuracion.Setup(a => a.GetSection("EmailSettings:smtp_port")).Returns(configurationSection4.Object);

            var configurationSection5 = new Mock<IConfigurationSection>();
            configurationSection5.Setup(a => a.Value).Returns("smtp.gmail.com");
            configuracion.Setup(a => a.GetSection("EmailSettings:smtp_host")).Returns(configurationSection5.Object);

            var config = configuracion.Object;

            IServicioEnvioCorreos servicioEnvioCorreos = new ServicioEnvioCorreos(config);

            IServicioDatosContacto servicioDatosContacto = new ServicioDatosContacto(servicioEnvioCorreos);

            DtoEnviarMensajeDatosContacto dtoEnviarMensaje = new()
            {
                Nombre = "Jesús Eduardo Ruvalcaba Montoya",
                CorreoElectronico = "jeduardoruv.14@gmail.com",
                Telefono = "+(553) 908-0551",
                Fecha = "09/12/2022",
                CiudadEstado = "Calvillo, Aguascalientes"
            };

            servicioDatosContacto.EnviarMensaje(dtoEnviarMensaje);
        }
    }
}
