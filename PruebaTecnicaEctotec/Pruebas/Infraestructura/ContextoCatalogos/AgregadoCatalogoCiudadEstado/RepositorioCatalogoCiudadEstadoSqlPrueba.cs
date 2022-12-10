using Dominio.Comunes.UnidadDeTrabajo;
using Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using Infraestructura.Comunes.UnidadDeTrabajo;
using Infraestructura.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas.Infraestructura.ContextoCatalogos.AgregadoCatalogoCiudadEstado
{
    public class RepositorioCatalogoCiudadEstadoSqlPrueba
    {
        [Fact]
        public void ObtenerPorNombre_NombreExiste_EnumerableCatalogoCiudadEstado()
        {
            IUnidadDeTrabajo unidadDeTrabajo = new UnidadDeTrabajoSql("Data source=localhost; Initial Catalog=PruebaTecnicaEctotec; persist security info=True; Integrated Security=True; User ID=sa; Password=39080551lalo; Pooling=true");
            IRepositorioCatalogoCiudadEstado repositorio = new RepositorioCatalogoCiudadEstadoSql(unidadDeTrabajo);

            IEnumerable<CatalogoCiudadEstado> catalogo = repositorio.ObtenerPorNombre("Mont");

            Assert.True(catalogo.Any());
        }
    }
}
