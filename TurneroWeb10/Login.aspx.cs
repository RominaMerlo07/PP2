using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Services;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Gestores;
using Entidades.ent;
using System.Data;
using Newtonsoft.Json;

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

                usuario = gestorUsuarios.accederUsuario(p_usuario, p_password);

                if (!String.IsNullOrEmpty(usuario.NombreUsuario))
                {
                    HttpContext.Current.Session["TURNERO.Usuario"] = usuario;

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

        [WebMethod]
        public static string validaClaveProvisoria(string p_usuario, string p_password)
        {
            try
            {
                GestorUsuarios gUsuarios = new GestorUsuarios();
                DataTable dt = gUsuarios.validaClaveProvisoria(p_usuario, p_password);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string actualizarClaveUser(string p_user, string p_password)
        {

            Usuario usuario = new Usuario();
            GestorUsuarios gUsuarios = new GestorUsuarios();


            try
            {
                string mensaje = "OK";

                #region Completa entidad usuario

                if (!string.IsNullOrEmpty(p_user))
                {
                    usuario.NombreUsuario = p_user;
                }

                if (!string.IsNullOrEmpty(p_password))
                {
                    usuario.ClaveUsuario = p_password;
                }


                usuario.UsuarioMod = 1;
                usuario.FechaMod = DateTime.Today;

                #endregion

                gUsuarios.actualizarClaveUser(usuario);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del usuario " + e.Message;
                return error;
            }

        }
    }
}