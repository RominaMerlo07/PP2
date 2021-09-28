using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Gestores;
using Entidades.ent;

namespace TurneroWeb10
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string accesoUser(string p_usuario, string p_password)
        {
            
            Usuario usuario = new Usuario();
            GestorUsuarios gestorUsuarios = new GestorUsuarios();

            try
            {
               // string mensaje = "OK";

  
                bool result = gestorUsuarios.accederUsuario(p_usuario, p_password);

                if (result)
                {
                    return "OK";
                }
                else {
                    return "Error";
                }

                
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al buscar los datos del usuario " + e.Message;
                return error;
            }

        }
    }
}