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
    public partial class RegistrarProfesional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registrarProfesional(string p_dni, string p_matricula, List<string> p_especialidades,    string p_nombre, string p_apellido, string p_fechaNac,
                                                 string p_calle, string p_numero, string p_barrio, string p_localidad, string p_celular, string p_email1, string p_email2)
        {

            Profesional profesional = new Profesional();
            GestorProfesionales gestorProfesionales = new GestorProfesionales();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Profesional

                if (!string.IsNullOrEmpty(p_dni))
                {
                    profesional.Documento = p_dni;
                }

                if (!string.IsNullOrEmpty(p_matricula))
                {
                    profesional.NroMatricula = p_matricula;
                }

                if (!string.IsNullOrEmpty(p_nombre))
                {
                    profesional.Nombre = p_nombre;
                }

                if (!string.IsNullOrEmpty(p_apellido))
                {
                    profesional.Apellido = p_apellido;
                }

                if (!string.IsNullOrEmpty(p_fechaNac))
                {
                    profesional.FechaNacimiento = Convert.ToDateTime(p_fechaNac);
                }

                if ((!string.IsNullOrEmpty(p_calle)) && (!string.IsNullOrEmpty(p_numero)))
                {
                    string domicilio = p_calle + " " + p_numero + " Barrio: " + p_barrio;
                    profesional.Domicilio = domicilio;
                }

                if (!string.IsNullOrEmpty(p_localidad))
                {
                    profesional.Localidad = p_localidad;
                }

                if (!string.IsNullOrEmpty(p_celular))
                {
                    profesional.NroContacto = p_celular;
                }

                if ((!string.IsNullOrEmpty(p_email1)) && (!string.IsNullOrEmpty(p_email2)))
                {
                    string email = p_email1 + "@" + p_email2;
                    profesional.EmailContacto = email;
                }

                profesional.UsuarioAlta = 1;
                profesional.FechaAlta = DateTime.Today;

                #endregion

                gestorProfesionales.RegistrarProfesional(profesional, p_especialidades);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el profesional " + e.Message;
                return error;
            }
        }

        [WebMethod]
        public static List<Especialidad> cargarEspecialidades()
        {
            try
            {
                GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();
                List<Especialidad> especialidades = gestorEspecialidades.obtenerEspecialidades();
                return especialidades;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static List<Profesional> cargarProfesionales()
        {
            List<Profesional> profesionales = null;

            try
            {
                GestorProfesionales gestorProfesionales = new GestorProfesionales();
                profesionales = gestorProfesionales.obtenerProfesionales();                
            }
            catch (Exception e)
            {
                profesionales = null;
                throw e;
            }
            return profesionales;
        }


        [WebMethod]
        public static string actualizarProfesional(string id, string nombre, string apellido, string dni, string matricula, string fechaNacimiento,
                                                   string localidad, string barrio, string direccion, string celular, string email1, string email2)
        {

            Profesional profesional = new Profesional();
            GestorProfesionales gestorProfesionales = new GestorProfesionales();


            try
            {
                string mensaje = "OK";

                #region Completa entidad Profesional

                if (!string.IsNullOrEmpty(dni))
                {
                    profesional.Documento = dni;
                }

                if (!string.IsNullOrEmpty(matricula))
                {
                    profesional.NroMatricula = matricula;
                }

                if (!string.IsNullOrEmpty(nombre))
                {
                    profesional.Nombre = nombre;
                }

                if (!string.IsNullOrEmpty(apellido))
                {
                    profesional.Apellido = apellido;
                }

                if (!string.IsNullOrEmpty(fechaNacimiento))
                {
                    profesional.FechaNacimiento = Convert.ToDateTime(fechaNacimiento);
                }

                if (!string.IsNullOrEmpty(direccion))
                {
                    string domicilio = direccion + " Barrio: " + barrio;
                    profesional.Domicilio = domicilio;
                }

                if (!string.IsNullOrEmpty(localidad))
                {
                    profesional.Localidad = localidad;
                }

                if (!string.IsNullOrEmpty(celular))
                {
                    profesional.NroContacto = celular;
                }

                if ((!string.IsNullOrEmpty(email1)) && (!string.IsNullOrEmpty(email2)))
                {
                    string email = email1 + "@" + email2;
                    profesional.EmailContacto = email;
                }

                profesional.IdProfesional = Convert.ToInt32(id);

                profesional.UsuarioMod = 1;
                profesional.FechaMod = DateTime.Today;

                #endregion

                gestorProfesionales.ActualizarProfesional(profesional);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del profesional " + e.Message;
                return error;
            }                                  

        }
    }
}