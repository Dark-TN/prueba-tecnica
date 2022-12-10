using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ContextoMensaje.AgregadoDatosContacto
{
    public class DtoEnviarMensajeDatosContacto
    {
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Fecha { get; set; }
        public string CiudadEstado { get; set; }
    }
}
