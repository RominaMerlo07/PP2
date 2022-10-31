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
    public partial class RegistrarEspecialidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registrarEspecialidades(string p_descripcion)
        {
            Especialidad especialidad = new Especialidad();
            GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();

            try
            {
                string mensaje ="OK";

                #region Completa entidad Especialidad

                if (!string.IsNullOrEmpty(p_descripcion))
                {
                    especialidad.Descripcion = p_descripcion;

                }

                especialidad.UsuarioAlta = 1;
                especialidad.FechaAlta = DateTime.Today;

                #endregion

                gestorEspecialidades.RegistrarEspecialidades(especialidad);

                return mensaje;
            }

            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el profesional " + e.Message;
                return error;
            }

        }

        [WebMethod]
        public static Especialidad cargarEspecialidades(string IdEspecialidad)
        {
            try
            {
                int id = Convert.ToInt32(IdEspecialidad);

                GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();
                Especialidad especialidad = new Especialidad();
                especialidad = gestorEspecialidades.obtenerEspecialidad(id);
                       
                return especialidad;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string editarEspecialidad(string p_IdEspecialidad, string p_descripcion)
        {
            Especialidad especialidad = new Especialidad();
            GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Especialidad

                if (!string.IsNullOrEmpty(p_descripcion))
                {
                    especialidad.Descripcion = p_descripcion;
                }

                especialidad.IdEspecialidad = Convert.ToInt32(p_IdEspecialidad);

                especialidad.UsuarioMod = 1;
                especialidad.FechaMod = DateTime.Today;

                #endregion

                gestorEspecialidades.editarEspecialidad(especialidad);

                return mensaje;
            }

            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el profesional " + e.Message;
                return error;
            }

        }

    }
}