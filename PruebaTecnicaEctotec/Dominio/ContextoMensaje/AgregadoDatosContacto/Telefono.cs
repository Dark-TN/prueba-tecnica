using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio.ContextoMensaje.AgregadoDatosContacto
{
    public class Telefono
    {
        private Telefono(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                throw new ArgumentNullException("El teléfono no puede ir vacío");

            if (!Regex.IsMatch(valor, @"^\+?\#? *\(?\d{3}\)?-? *\d{3}-? *-?\d{4}"))
                throw new ArgumentException("El formato del teléfono ingresado no es válido");

            Valor = valor;
        }

        public static Telefono Crear(string valor) => new(valor);

        public string Valor { get; private set; }
    }
}
