using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Gestores;
using Entidades.ent;
using Newtonsoft.Json;

namespace TurneroWeb10
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string registrarUsuario(string p_idPersonal, string p_idProfesional, string p_user, string p_password, string p_rol)
        {

            Usuario usuario = new Usuario();           
            GestorUsuarios gUsuarios = new GestorUsuarios();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Usuario

                if (!string.IsNullOrEmpty(p_user))
                {
                    usuario.NombreUsuario = p_user;
                }
                if (!string.IsNullOrEmpty(p_password))
                {
                    usuario.ClaveUsuario = p_password;
                }
                            
               
                int IdRol = Convert.ToInt32(p_rol);
                int idPersonal = Convert.ToInt32(p_idPersonal);
                int IdProfesional = Convert.ToInt32(p_idProfesional);
                usuario.UsuarioAlta = 1;
                usuario.FechaAlta = DateTime.Today;
             
                #endregion

                gUsuarios.DaRegistrarUsuario(usuario, IdRol, idPersonal, IdProfesional);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el usuario " + e.Message;               
                return error;
            }
        }


        [WebMethod]
        public static string buscarPersonal(string dniPersonal)
        {
            try
            {
                GestorUsuarios gestorUsuarios = new GestorUsuarios();
                DataTable dt = gestorUsuarios.buscarPersonal(dniPersonal);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string generarUsuario(string nombre, string apellido)
        {
            try
            {

                GestorUsuarios gestorUsuarios = new GestorUsuarios();
                string usuario = gestorUsuarios.generarUsuario(nombre, apellido);
                string col = JsonConvert.SerializeObject(usuario);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static List<Rol> cargarRoles()
        {
            try
            {
                GestorRoles gestorRoles = new GestorRoles();
                List<Rol> roles = gestorRoles.obtenerRoles();
                return roles;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string cargarUsuarios()
        {
            try
            {
                GestorUsuarios gUsuarios = new GestorUsuarios();
                DataTable dt = gUsuarios.cargarUsuarios();
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string buscarUsuarios(int idUsuario)
        {
            try
            {
                GestorUsuarios gUsuarios = new GestorUsuarios();
                DataTable dt = gUsuarios.buscarUsuarios(idUsuario);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        [WebMethod]
        public static string actualizarUsuario(string id, string user, string rol)
        {

            Usuario usuario = new Usuario();
            GestorUsuarios gUsuarios = new GestorUsuarios();


            try
            {
                string mensaje = "OK";

                #region Completa entidad usuario

                if (!string.IsNullOrEmpty(user))
                {
                    usuario.NombreUsuario = user;
                }
                             
                
                usuario.IdUsuario = Convert.ToInt32(id);
                int IdRol = Convert.ToInt32(rol);

                usuario.UsuarioMod = 1;
                usuario.FechaMod = DateTime.Today;

                #endregion

                gUsuarios.actualizarUsuario(usuario, IdRol);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del usuario " + e.Message;
                return error;
            }

        }

        [WebMethod]
        public static string darBajaUsuario(string IdUsuario)
        {

            Usuario usuario = new Usuario();
            GestorUsuarios gUsuarios = new GestorUsuarios();

            try
            {
                string mensaje = "OK";

                usuario.IdUsuario = Convert.ToInt32(IdUsuario);

                usuario.UsuarioBaja = 1;
                usuario.FechaBaja = DateTime.Today;

                mensaje = gUsuarios.darBajaUsuario(usuario);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al dar de baja el usuario " + e.Message;
                return error;
            }

        }

        [WebMethod]
        public static string buscarEmail(string idUsuario)
        {
            try
            {
                GestorUsuarios gUsuarios = new GestorUsuarios();
                DataTable dt = gUsuarios.buscarEmail(idUsuario);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}