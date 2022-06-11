using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.EnviadorMail
{
    public class EnviadorMail
    {
        private SmtpClient cliente;
        private MailMessage email;

        public EnviadorMail()
        {

            cliente = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("sparringkinesio@gmail.com", "agupkyzxiwboitpz")
                //"sparring4321")
            };
        }

        public void EnviarCorreo(string destinatario, string asunto, string mensaje, bool esHtlm = true)
        {
            //email = new MailMessage("sparringkinesio@gmail.com", "asnotragico@gmail.com", asunto, mensaje);
            email = new MailMessage("sparringkinesio@gmail.com", destinatario, asunto, mensaje);

            email.IsBodyHtml = esHtlm;
            cliente.Send(email);
        }
    }
}
