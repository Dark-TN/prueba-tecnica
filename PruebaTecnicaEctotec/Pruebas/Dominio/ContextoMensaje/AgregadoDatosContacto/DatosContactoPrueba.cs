using Dominio.ContextoMensaje.AgregadoDatosContacto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas.Dominio.ContextoMensaje.AgregadoDatosContacto
{
    public class DatosContactoPrueba
    {
        [Fact]
        public void CrearAgregado_DatosCorrectos_DatosContacto()
        {
            Guid id = Guid.NewGuid();
            Nombre nombre = Nombre.Crear("Jesús Eduardo Ruvalcaba Montoya");
            CorreoElectronico correo = CorreoElectronico.Crear("jeduardoruv.14@gmail.com");
            DateTime fecha = DateTime.Now;
            Telefono telefono = Telefono.Crear("+(553) 908-0551");
            string ciudadEstado = "Azcapotzalco, Ciudad de México";

            DatosContacto datosContacto = new(id, nombre, correo, telefono, fecha, ciudadEstado);

            Assert.NotNull(datosContacto);
        }
    }
}
