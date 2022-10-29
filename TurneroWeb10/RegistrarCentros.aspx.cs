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
        public static string registrarCentros(string p_nombre, string p_domicilio, string p_numero, string p_barrio, string p_localidad,  string p_email1, string p_email2, string p_celular, string p_telefono)
        {

           Centro centro = new Centro();
           GestorCentros gestorCentros = new GestorCentros();       
            
            try
            {
                string mensaje = "OK";

                #region Completa entidad Centro

                if (!string.IsNullOrEmpty(p_nombre))
                {
                    centro.NombreCentro = p_nombre;
                }              

                if ((!string.IsNullOrEmpty(p_domicilio)) && (!string.IsNullOrEmpty(p_numero)))
                {
                    string domicilio = p_domicilio + " " + p_numero + " Barrio: " + p_barrio;
                    centro.DomicilioCentro = domicilio;
                }

                if (!string.IsNullOrEmpty(p_localidad))
                {
                    centro.LocalidadCentro = p_localidad;
                }

                if (!string.IsNullOrEmpty(p_celular))
                {
                    centro.NroCentro2 = p_celular;
                }

                if (!string.IsNullOrEmpty(p_telefono))
                {
                    centro.NroCentro1 = p_telefono;
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
                string error = "Se produjo un error al registrar el centro " + e.Message;
                return error;
            }

        }

    

        [WebMethod]
        public static List<Centro> traerCentros()
        {
            try
            {
                GestorCentros gestorCentros = new GestorCentros();
                List<Centro> centros =  gestorCentros.obtenerCentros();//;new List<Centro>();
                return centros;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string actualizarCentros(string p_id, string p_centro, string p_domicilio, string p_barrio, string p_localidad, string p_telefono, string p_celular, string p_email1, string p_email2)
        
        {

            Centro centro = new Centro();
            GestorCentros gestorCentros = new GestorCentros();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Centro

                if (!string.IsNullOrEmpty(p_centro))
                {
                    centro.NombreCentro = p_centro;
                }

                if (!string.IsNullOrEmpty(p_domicilio))
                {
                    string domicilio = p_domicilio + " Barrio: " + p_barrio;
                    centro.DomicilioCentro = domicilio;
                }

                if (!string.IsNullOrEmpty(p_localidad))
                {
                    centro.LocalidadCentro = p_localidad;
                }

                if (!string.IsNullOrEmpty(p_celular))
                {
                    centro.NroCentro2 = p_celular;
                }

                if (!string.IsNullOrEmpty(p_telefono))
                {
                    centro.NroCentro1 = p_telefono;
                }

                if ((!string.IsNullOrEmpty(p_email1)) && (!string.IsNullOrEmpty(p_email2)))
                {
                    string email = p_email1 + "@" + p_email2;
                    centro.EmailCentro = email;
                }

                centro.IdCentro = Convert.ToInt32(p_id);

                centro.UsuarioMod = 1;
                centro.FechaMod = DateTime.Today;

                #endregion

                gestorCentros.ActualizarCentros(centro);

                return mensaje;
            }

            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del centro" + e.Message;
                return error;
            }
        }


        [WebMethod]
        public static Centro obtenerCentro( int idCentro)
        {
            try
            {
                Centro centro = new Centro();
                GestorCentros gestorCentros = new GestorCentros();
                centro = gestorCentros.obtenerCentro(idCentro);

                return centro;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string darBajaCentro(string p_id)
        {
            Centro centro = new Centro();
            GestorCentros gestorCentros = new GestorCentros();

            try
            {
                string mensaje = "OK";

                centro.IdCentro = Convert.ToInt32(p_id);

                centro.UsuarioBaja = 1;
                centro.FechaBaja= DateTime.Today;

                mensaje = gestorCentros.DarDeBajaCentro(centro);

                return mensaje;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


    }

}
