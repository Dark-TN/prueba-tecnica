using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ContextoMensaje.AgregadoDatosContacto
{
    public interface IServicioDatosContacto
    {
        void EnviarMensaje(DtoEnviarMensajeDatosContacto dtoEnviarMensaje);
    }
}
