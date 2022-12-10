using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ContextoCatalogos.AgregadoCatalogoCiudadEstado
{
    public class CatalogoCiudadEstado
    {
        public CatalogoCiudadEstado(Guid id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        
    }
}
