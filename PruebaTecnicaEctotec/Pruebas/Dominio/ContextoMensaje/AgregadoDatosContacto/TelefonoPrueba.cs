using Dominio.ContextoMensaje.AgregadoDatosContacto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas.Dominio.ContextoMensaje.AgregadoDatosContacto
{
    public class TelefonoPrueba
    {
        [Fact]
        public void Crear_ValorCorrecto_Telefono()
        {
            string valor = "#(553) 908-0551";

            Telefono telefono = Telefono.Crear(valor);

            Assert.NotNull(telefono);
        }

        [Fact]
        public void Crear_ValorVacio_ArgumentNullException()
        {
            string valor = "";

            Assert.Throws<ArgumentNullException>(() =>
            {
                Telefono telefono = Telefono.Crear(valor);
            });
        }

        [Fact]
        public void Crear_ValorInvalido_ArgumentException()
        {
            string valor = "55555";

            Assert.Throws<ArgumentException>(() =>
            {
                Telefono telefono = Telefono.Crear(valor);
            });
        }
    }
}
