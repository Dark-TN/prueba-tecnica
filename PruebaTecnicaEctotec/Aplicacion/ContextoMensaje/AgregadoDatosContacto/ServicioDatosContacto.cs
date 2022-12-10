using Aplicacion.ContextoCatalogos.AgregadoCatalogoCiudadEstado;
using Dominio.Comunes.Servicios;
using Dominio.ContextoMensaje.AgregadoDatosContacto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.ContextoMensaje.AgregadoDatosContacto
{
    public class ServicioDatosContacto : IServicioDatosContacto
    {
        private readonly IServicioEnvioCorreos _servicioEnvioCorreos;

        public ServicioDatosContacto(IServicioEnvioCorreos servicioEnvioCorreos)
        {
            _servicioEnvioCorreos = servicioEnvioCorreos;
        }

        public void EnviarMensaje(DtoEnviarMensajeDatosContacto dtoEnviarMensaje)
        {
            try
            {
                Guid id = Guid.NewGuid();
                Nombre nombre = Nombre.Crear(dtoEnviarMensaje.Nombre);
                CorreoElectronico correo = CorreoElectronico.Crear(dtoEnviarMensaje.CorreoElectronico);
                DateTime fecha = DateTime.ParseExact(dtoEnviarMensaje.Fecha, "dd/MM/yyyy", new CultureInfo("es-MX"));
                Telefono telefono = Telefono.Crear(dtoEnviarMensaje.Telefono);

                DatosContacto datosContacto = new(id, nombre, correo, telefono, fecha, dtoEnviarMensaje.CiudadEstado);

                _servicioEnvioCorreos.Enviar(datosContacto);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
