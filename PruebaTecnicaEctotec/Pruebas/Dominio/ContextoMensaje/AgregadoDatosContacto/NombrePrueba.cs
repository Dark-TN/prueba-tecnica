using Dominio.ContextoMensaje.AgregadoDatosContacto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas.Dominio.ContextoMensaje.AgregadoDatosContacto
{
    public class NombrePrueba
    {
        [Fact]
        public void Crear_ValorCorrecto_Nombre()
        {
            string valor = "Jesús Eduardo Ruvalcaba Montoya";

            Nombre nombre = Nombre.Crear(valor);

            Assert.NotNull(nombre);
        }

        [Fact]
        public void Crear_ValorVacio_ArgumentNullException()
        {
            string valor = "";

            Assert.Throws<ArgumentNullException>(() =>
            {
                Nombre nombre = Nombre.Crear(valor);
            });   
        }
    }
}
