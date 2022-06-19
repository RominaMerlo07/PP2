using BusinessLogicLayer.Gestores;
using Entidades.ent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurneroWeb10
{
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string validarEmail(string email)
        {
            try
            {
                GestorUsuarios gUsuarios = new GestorUsuarios();
                DataTable dt = gUsuarios.validarEmail(email);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string registrarResetPass(string p_nombreUsuario, string p_claveUsuario, string p_emailContacto, string p_idPersonal, string p_idProfesional)
        {

            ResetPass resetPass = new ResetPass();
            GestorUsuarios gestorUsuarios = new GestorUsuarios();


            try
            {
                string mensaje = "OK";

                #region Completa entidad resetPass

                if (!string.IsNullOrEmpty(p_nombreUsuario))
                {
                    resetPass.NombreUsuario = p_nombreUsuario;
                }

                if (!string.IsNullOrEmpty(p_claveUsuario))
                {
                    resetPass.ClaveUsuario = p_claveUsuario;
                }

                if (!string.IsNullOrEmpty(p_emailContacto))
                {
                    resetPass.EmailContacto = p_emailContacto;
                }


                resetPass.UsuarioAlta = 1;
                resetPass.FechaAlta = DateTime.Today;
                int idPersonal = Convert.ToInt32(p_idPersonal);
                int idProfesional = Convert.ToInt32(p_idProfesional);

                #endregion

                gestorUsuarios.registrarResetPass(resetPass, idPersonal, idProfesional);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el usuario " + e.Message;
                return error;
            }

        }

        [WebMethod]
        public static string validarResetPass(string p_email_contacto, string p_usuario)
        {
            try
            {
                GestorUsuarios gUsuarios = new GestorUsuarios();
                DataTable dt = gUsuarios.validarResetPass(p_email_contacto, p_usuario);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string bajaResetClave(string id_resetpass)
        {

            ResetPass resetPass = new ResetPass();
            GestorUsuarios gUsuarios = new GestorUsuarios();


            try
            {
                string mensaje = "OK";

                resetPass.IdResetPass = Convert.ToInt32(id_resetpass);

                resetPass.UsuarioBaja = 1;
                resetPass.FechaBaja = DateTime.Today;

                gUsuarios.bajaResetClave(resetPass);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al dar de baja la clave reseteada " + e.Message;
                return error;
            }

        }


    }
}