using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado
{
    public interface IRepositorioCatalogoCiudadEstado
    {
        IEnumerable<CatalogoCiudadEstado> ObtenerPorNombre(string nombre);
    }
}
