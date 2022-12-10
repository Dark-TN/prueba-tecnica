using Dominio.Comunes.Servicios;
using Dominio.ContextoMensaje.AgregadoDatosContacto;
using Infraestructura.Comunes.Servicios;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas.Infraestructura.Comunes.Servicios
{
    public class ServicioEnvioCorreosPrueba
    {
        [Fact]
        public void Enviar_DatosCorrectos_void()
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

            IServicioEnvioCorreos servicio = new ServicioEnvioCorreos(config);

            Guid id = Guid.NewGuid();
            Nombre nombre = Nombre.Crear("Jesús Eduardo Ruvalcaba Montoya");
            CorreoElectronico correo = CorreoElectronico.Crear("jeduardoruv.14@gmail.com");
            DateTime fecha = DateTime.Now;
            Telefono telefono = Telefono.Crear("+(553) 908-0551");
            string ciudadEstado = "Azcapotzalco, Ciudad de México";

            DatosContacto datosContacto = new(id, nombre, correo, telefono, fecha, ciudadEstado);

            servicio.Enviar(datosContacto);
        }
    }
}
