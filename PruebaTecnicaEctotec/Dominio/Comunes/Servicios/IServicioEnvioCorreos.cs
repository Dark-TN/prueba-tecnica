using Dominio.ContextoMensaje.AgregadoDatosContacto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Comunes.Servicios
{
    public interface IServicioEnvioCorreos
    {
        void Enviar(DatosContacto datosContacto);
    }
}
