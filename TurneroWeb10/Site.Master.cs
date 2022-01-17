using Entidades.ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurneroWeb10
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TURNERO.Usuario"] != null)
            { 
                Usuario usuario = (Usuario)Session["TURNERO.Usuario"];
                lblUsuarioMaster.InnerText = "Usuario: " + usuario.NombreUsuario;
                lblRolMaster.InnerText = usuario.Rol.NombreRol;
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Session["TURNERO.Usuario"] = null;
            Response.Redirect("Login.aspx", false);
        }
    }
}