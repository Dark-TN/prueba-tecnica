using Aplicacion.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
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

namespace Pruebas.Aplicacion.ContextoCatalogos.AgregadoCatalogoCiudadEstado
{
    public class ServicioCatalogoCiudadEstadoPrueba
    {
        [Fact]
        public void ObtenerPorNombre_NombreExiste_EnumerableDtoObtenerCatalogoCiudadEstado()
        {
            IUnidadDeTrabajo unidadDeTrabajo = new UnidadDeTrabajoSql("Data source=localhost; Initial Catalog=PruebaTecnicaEctotec; persist security info=True; Integrated Security=True; User ID=sa; Password=39080551lalo; Pooling=true");
            IRepositorioCatalogoCiudadEstado repositorioCatalogoCiudadEstado = new RepositorioCatalogoCiudadEstadoSql(unidadDeTrabajo);

            IServicioCatalogoCiudadEstado servicioCatalogoCiudadEstado = new ServicioCatalogoCiudadEstado(repositorioCatalogoCiudadEstado);

            string nombre = "Nuevo";

             IEnumerable<string> catalogo = servicioCatalogoCiudadEstado.ObtenerPorNombre(nombre);

            Assert.True(catalogo.Any());
        }

        [Fact]
        public void ObtenerPorNombre_NombreNoExiste_EnumerableDtoObtenerCatalogoCiudadEstado()
        {
            IUnidadDeTrabajo unidadDeTrabajo = new UnidadDeTrabajoSql("Data source=localhost; Initial Catalog=PruebaTecnicaEctotec; persist security info=True; Integrated Security=True; User ID=sa; Password=39080551lalo; Pooling=true");
            IRepositorioCatalogoCiudadEstado repositorioCatalogoCiudadEstado = new RepositorioCatalogoCiudadEstadoSql(unidadDeTrabajo);

            IServicioCatalogoCiudadEstado servicioCatalogoCiudadEstado = new ServicioCatalogoCiudadEstado(repositorioCatalogoCiudadEstado);

            string nombre = "yurut";

            IEnumerable<string> catalogo = servicioCatalogoCiudadEstado.ObtenerPorNombre(nombre);

            Assert.False(catalogo.Any());
        }
    }
}
