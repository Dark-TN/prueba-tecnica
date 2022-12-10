using Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ContextoCatalogos.AgregadoCatalogoCiudadEstado
{
    public class ServicioCatalogoCiudadEstado : IServicioCatalogoCiudadEstado
    {
        private readonly IRepositorioCatalogoCiudadEstado _repositorioCatalogoCiudadEstado;

        public ServicioCatalogoCiudadEstado(IRepositorioCatalogoCiudadEstado repositorioCatalogoCiudadEstado)
        {
            _repositorioCatalogoCiudadEstado = repositorioCatalogoCiudadEstado;
        }

        public IEnumerable<string> ObtenerPorNombre(string nombre)
        {
            try
            {
                IEnumerable<CatalogoCiudadEstado> catalogo = _repositorioCatalogoCiudadEstado.ObtenerPorNombre(nombre);

                if (catalogo == null)
                    throw new InvalidOperationException("No existe el catálogo");

                return catalogo.Select(c => c.Nombre);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
