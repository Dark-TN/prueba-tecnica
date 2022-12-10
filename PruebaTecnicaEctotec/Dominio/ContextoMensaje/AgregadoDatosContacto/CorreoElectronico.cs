using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio.ContextoMensaje.AgregadoDatosContacto
{
    public class CorreoElectronico
    {
        private CorreoElectronico(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                throw new ArgumentNullException("El correo electrónico no puede ir vacío");

            if (!Regex.IsMatch(valor, @"^[a-zA-Z0-9\._-]+@[a-zA-Z0-9\.-]+(\.[a-zA-Z]{2,6})+$"))
                throw new ArgumentException("El formato del correo electrónico ingresado no es válido");

            Valor = valor;
        }

        public static CorreoElectronico Crear(string valor) => new(valor);

        public string Valor { get; private set; }
    }
}
