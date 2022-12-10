using Dominio.Comunes.Servicios;
using Dominio.ContextoMensaje.AgregadoDatosContacto;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Infraestructura.Comunes.Servicios
{
    public class ServicioEnvioCorreos : IServicioEnvioCorreos
    {
        IConfiguration _configuration;

        public ServicioEnvioCorreos(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Enviar(DatosContacto datosContacto)
        {
            string from = _configuration.GetSection("EmailSettings:smtp_from").Value;
            string user = _configuration.GetSection("EmailSettings:smtp_user").Value;
            string password = _configuration.GetSection("EmailSettings:smtp_pswd").Value;
            int port = Convert.ToInt32(_configuration.GetSection("EmailSettings:smtp_port").Value);
            string host = _configuration.GetSection("EmailSettings:smtp_host").Value;
            string subject = "Prueba Datos Contacto";

            string path = AppDomain.CurrentDomain.BaseDirectory + "MailTemplates/template.html";

            string cuerpo = File.ReadAllText(path);
            cuerpo = cuerpo.Replace("[Nombre]", datosContacto.Nombre.Valor)
            .Replace("[Email]", datosContacto.CorreoElectronico.Valor)
            .Replace("[CiudadEstado]", datosContacto.CiudadEstado)
            .Replace("[Fecha]", datosContacto.Fecha.ToString("dd-MMMM_yyyy", new CultureInfo("es-MX")).Replace("-"," de ").Replace("_", " del "));

            MailMessage sendMail = new MailMessage();
            sendMail.From = new MailAddress(from, subject);
            sendMail.To.Add(datosContacto.CorreoElectronico.Valor);
            sendMail.Subject = subject;
            sendMail.IsBodyHtml = true;
            sendMail.Body = cuerpo;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Credentials = new NetworkCredential(user, password);
            smtpClient.Port = port;
            smtpClient.Host = host;
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(sendMail);
            }
            catch (SmtpException ex)
            {
                throw;
            }
        }
    }
}
