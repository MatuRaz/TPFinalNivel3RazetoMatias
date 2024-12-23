using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailServices
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailServices()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("d494e2c2b27cc7", "5f631cf6e160bd");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("NoResponder@TecnoStoreWeb.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            //Se puede poner html plano para generar una platilla
            email.IsBodyHtml = true;
            //email.Body = "<h1>Reporte de materias a las que se a inscripto</h1> <br>Hola te inscribiste";
            email.Body = cuerpo;
        }

        public void inviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
