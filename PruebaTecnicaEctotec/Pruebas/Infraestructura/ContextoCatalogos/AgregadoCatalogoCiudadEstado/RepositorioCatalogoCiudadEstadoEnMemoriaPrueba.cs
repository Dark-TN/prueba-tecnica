using Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using Infraestructura.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas.Infraestructura.ContextoCatalogos.AgregadoCatalogoCiudadEstado
{
    public class RepositorioCatalogoCiudadEstadoEnMemoriaPrueba
    {
        [Fact]
        public void ObtenerPorNombre_NombreExiste_EnumerableCatalogoCiudadEstado()
        {
            IRepositorioCatalogoCiudadEstado repositorio = RepositorioCatalogoCiudadEstadoEnMemoria.Instancia;

            IEnumerable<CatalogoCiudadEstado> catalogo = repositorio.ObtenerPorNombre("Mont");

            Assert.True(catalogo.Any());
        }
    }
}
