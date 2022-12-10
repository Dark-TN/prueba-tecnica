using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ContextoMensaje.AgregadoDatosContacto
{
    public class Nombre
    {
        private Nombre(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                throw new ArgumentNullException("El nombre no puede ir vacío");

            Valor = valor;
        }

        public static Nombre Crear(string valor) => new(valor);

        public string Valor { get; private set; }
    }
}
