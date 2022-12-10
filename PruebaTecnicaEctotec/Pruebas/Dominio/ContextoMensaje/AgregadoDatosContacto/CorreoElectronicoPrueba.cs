using Dominio.ContextoMensaje.AgregadoDatosContacto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas.Dominio.ContextoMensaje.AgregadoDatosContacto
{
    public class CorreoElectronicoPrueba
    {
        [Fact]
        public void Crear_ValorCorrecto_CorreoElectronico()
        {
            string valor = "jeduardoruv.14@gmail.com";

            CorreoElectronico correo = CorreoElectronico.Crear(valor);

            Assert.NotNull(correo);
        }

        [Fact]
        public void Crear_ValorVacio_ArgumentNullException()
        {
            string valor = "";

            Assert.Throws<ArgumentNullException>(() =>
            {
                CorreoElectronico correo = CorreoElectronico.Crear(valor);
            });
        }

        [Fact]
        public void Crear_ValorInvalido_ArgumentException()
        {
            string valor = "jeduardoruv";

            Assert.Throws<ArgumentException>(() =>
            {
                CorreoElectronico correo = CorreoElectronico.Crear(valor);
            });
        }
    }
}
