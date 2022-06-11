using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Gestores;
using BusinessLogicLayer.EnviadorMail;
using Entidades.ent;
using Newtonsoft.Json;

namespace TurneroWeb10
{
    public partial class zzEjemploEnviadorMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string enviarMail (string destinatario, string mensaje, bool esHtml)
        {
           
            try
            {
                string exito = "OK";
                EnviadorMail enviador = new EnviadorMail();
                enviador.EnviarCorreo(destinatario, "Asunto Hardcodeado", mensaje, esHtml);

                return exito;
            }
            catch (Exception e)
            {
                string error = e.Message;
                return error;
            }
        }
    }
}