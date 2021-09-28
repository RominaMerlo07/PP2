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
    }
}