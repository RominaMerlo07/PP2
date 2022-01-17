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
    public partial class RegistrarCentros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registrarCentros(string p_nombre, string p_domicilio, string p_localidad, string p_email1, string p_email2,  string p_contacto_1, string p_contacto_2)
        {

           Centro centro = new Centro();
           GestorCentros gestorCentros = new GestorCentros();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Profesional

                if (!string.IsNullOrEmpty(p_nombre))
                {
                    centro.NombreCentro = p_nombre;
                }

                if (!string.IsNullOrEmpty(p_domicilio))
                {
                    centro.DomicilioCentro = p_domicilio;
                }

                if (!string.IsNullOrEmpty(p_localidad))
                {
                    centro.LocalidadCentro = p_localidad;
                }

                if (!string.IsNullOrEmpty(p_contacto_1))
                {
                    centro.NroCentro1 = p_contacto_1;
                }

                if (!string.IsNullOrEmpty(p_contacto_2))
                {
                    centro.NroCentro2 = p_contacto_2;
                }



                if ((!string.IsNullOrEmpty(p_email1)) && (!string.IsNullOrEmpty(p_email2)))
                {
                    string email = p_email1 + "@" + p_email2;
                    centro.EmailCentro = email;
                }

               centro.UsuarioAlta = 1;
               centro.FechaAlta = DateTime.Today;

              

                #endregion

                gestorCentros.RegistrarCentros(centro);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el nuevo centro " + e.Message;
                return error;
            }

        }

        [WebMethod]
        public static List<Centro> traerCentros()
        {
            try
            {
                GestorCentros gestorCentros = new GestorCentros();
                List<Centro> centros = new List<Centro>();//gestorCentros.traerCentros();
                return centros;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]

        public static string actualizarCentros(string p_id, string p_nombre, string p_domicilio, string p_localidad, string p_email, string p_contacto_1, string p_contacto_2)
        
        {

            Centro centro = new Centro();
            GestorCentros gestorCentros = new GestorCentros();

            try
            {
                string mensaje = "OK";

                gestorCentros.ActualizarCentros(centro);

                return mensaje;
            }

            catch (Exception e)
            {
                throw e;            
            }
        }


    }

}
