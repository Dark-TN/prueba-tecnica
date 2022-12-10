using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ContextoCatalogos.AgregadoCatalogoCiudadEstado
{
    public interface IServicioCatalogoCiudadEstado
    {
        IEnumerable<string> ObtenerPorNombre(string nombre);
    }
}
