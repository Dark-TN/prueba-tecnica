using Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.ContextoCatalogos.AgregadoCatalogoCiudadEstado
{
    public class RepositorioCatalogoCiudadEstadoEnMemoria : IRepositorioCatalogoCiudadEstado
    {
        private static readonly List<CatalogoCiudadEstado> _catalogoCiudadEstado = new();
        private static RepositorioCatalogoCiudadEstadoEnMemoria _instancia = null;

        private RepositorioCatalogoCiudadEstadoEnMemoria()
        {
            _catalogoCiudadEstado.Add(new CatalogoCiudadEstado(Guid.Parse("C6723455-DDB3-494B-88B5-6A582F6823E7"), "Jesús María, Aguascalientes"));
            _catalogoCiudadEstado.Add(new CatalogoCiudadEstado(Guid.Parse("4E1AECFD-80DB-4E25-A705-02E7AED82D4E"), "Calvillo, Aguascalientes"));
            _catalogoCiudadEstado.Add(new CatalogoCiudadEstado(Guid.Parse("4974CDB2-5DB5-49D2-9345-4C11676A1604"), "Tlalnepantla de Baz, Estado de México"));
            _catalogoCiudadEstado.Add(new CatalogoCiudadEstado(Guid.Parse("C808AB02-93AA-40A4-B081-528EA8E5C7BD"), "Naucalpan de Juárez, Estado de México"));
            _catalogoCiudadEstado.Add(new CatalogoCiudadEstado(Guid.Parse("9C376CC8-FC67-43CE-A3C4-8D926C02398C"), "Tepotzotlán, Estado de México"));
            _catalogoCiudadEstado.Add(new CatalogoCiudadEstado(Guid.Parse("8E77B732-A932-4C69-9685-9B0EA5BBDDD6"), "Ixtapan de la Sal, Estado de México"));
            _catalogoCiudadEstado.Add(new CatalogoCiudadEstado(Guid.Parse("53D913DE-BB64-4A5A-9A02-9EEA3FAF30D3"), "Monterrey, Nuevo León"));
            _catalogoCiudadEstado.Add(new CatalogoCiudadEstado(Guid.Parse("5F2D6A3A-038F-4A97-8D01-6CB0C48DB9B3"), "San Pero Garza García, Nuevo León"));
            _catalogoCiudadEstado.Add(new CatalogoCiudadEstado(Guid.Parse("4C2BB0F1-382C-4F36-8528-DAB62941FBB9"), "Apodaca, Nuevo León"));
            _catalogoCiudadEstado.Add(new CatalogoCiudadEstado(Guid.Parse("64D22B34-E308-44B3-B117-CE8929635413"), "Cancún, Quintana Roo"));
        }

        public static RepositorioCatalogoCiudadEstadoEnMemoria Instancia
        {
            get
            {
                if (null == _instancia)
                    _instancia = new();
                return _instancia;
            }
        }

        public IEnumerable<CatalogoCiudadEstado> ObtenerPorNombre(string nombre) => _catalogoCiudadEstado.Where(c => c.Nombre.Contains(nombre));
    }
}
