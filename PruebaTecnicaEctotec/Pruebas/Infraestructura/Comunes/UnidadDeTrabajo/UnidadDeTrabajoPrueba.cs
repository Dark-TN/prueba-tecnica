using Dominio.Comunes.UnidadDeTrabajo;
using Infraestructura.Comunes.UnidadDeTrabajo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pruebas.Infraestructura.Comunes.UnidadDeTrabajo
{
    public class UnidadDeTrabajoPrueba
    {
        [Fact]
        public void CrearUnidadDeTrabajo_CadenaConexionCorrecta_UnidadDeTrabajo()
        {
            IUnidadDeTrabajo unidadDeTrabajo = new UnidadDeTrabajoSql("Data source=localhost; Initial Catalog=PruebaTecnicaEctotec; persist security info=True; Integrated Security=True; User ID=sa; Password=39080551lalo; Pooling=true");

            Assert.NotNull(unidadDeTrabajo);
        }
    }
}
