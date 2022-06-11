using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Gestores;
using Entidades.ent;
using Newtonsoft.Json;


namespace TurneroWeb10
{
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        [WebMethod]
        public static string SendMail()
        {
            try
            {
                string mensaje = "OK";
                //MailMessage mailMessage = new MailMessage();
                //{
                //    mailMessage.From = new MailAddress("sparringkinesio@gmail.com");
                //    mailMessage.To.Add("merlog222@gmail.com");
                //    mailMessage.Subject = "Prueba Email";
                //    mailMessage.Body = "<h1>Prueba Email Recuperar</h1>";
                //    mailMessage.IsBodyHtml = true;

                //    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                //    {
                //        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //        smtpClient.UseDefaultCredentials = false;
                //        smtpClient.Credentials = new NetworkCredential("sparringkinesio@gmail.com", "agupkyzxiwboitpz");
                //        smtpClient.EnableSsl = true;
                //        smtpClient.Send(mailMessage);
                //    }

                //}
                return mensaje;
            }
            catch (Exception er)
            {
                throw er;
            }
        }
    }
}