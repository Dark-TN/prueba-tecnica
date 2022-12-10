using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ContextoMensaje.AgregadoDatosContacto
{
    public class DatosContacto
    {
        public DatosContacto(Guid id, Nombre nombre, CorreoElectronico correoElectronico, Telefono telefono, DateTime fecha, string ciudadEstado)
        {
            Id = id;
            Nombre = nombre;
            CorreoElectronico = correoElectronico;
            Telefono = telefono;
            Fecha = fecha;
            CiudadEstado = ciudadEstado;
        }

        public Guid Id { get; private set; }
        public Nombre Nombre { get; private set; }
        public CorreoElectronico CorreoElectronico { get; private set; }
        public Telefono Telefono { get; private set; }
        public DateTime Fecha { get; private set; }
        public string CiudadEstado { get; private set; }
    }
}
