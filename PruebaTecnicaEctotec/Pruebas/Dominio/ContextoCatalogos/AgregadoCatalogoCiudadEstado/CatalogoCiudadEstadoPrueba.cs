using Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas.Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado
{
    public class CatalogoCiudadEstadoPrueba
    {
        [Fact]
        public void CrearAgregado_DatosCorrectos_CatalogoCiudadEstado()
        {
            Guid id = Guid.NewGuid();
            string nombre = "Azcapotzalco, Ciudad de México";

            CatalogoCiudadEstado catalogo = new(id, nombre);

            Assert.NotNull(catalogo);
        }
    }
}
