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
    public partial class RegistrarPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registrarPersonal(string p_dni, string p_nombre, string p_apellido, string p_fechaNac,
                                      string p_calle, string p_numero, string p_piso, string p_dpto, string p_barrio, string p_localidad, string p_celular, string p_email1, string p_email2)
        {

            string piso;
            string dpto;

            Personal personal = new Personal();
            GestorPersonal gPersonal = new GestorPersonal();


            try
            {
                string mensaje = "OK";

                #region Completa entidad Personal

                if (!string.IsNullOrEmpty(p_dni))
                {
                    personal.Documento = p_dni;
                }

                if (!string.IsNullOrEmpty(p_nombre))
                {
                    personal.Nombre = p_nombre;
                }

                if (!string.IsNullOrEmpty(p_apellido))
                {
                    personal.Apellido = p_apellido;
                }

                if (!string.IsNullOrEmpty(p_fechaNac))
                {
                    personal.FechaNacimiento = Convert.ToDateTime(p_fechaNac);
                }

                if ((!string.IsNullOrEmpty(p_calle)) && (!string.IsNullOrEmpty(p_numero)))
                {
                    if (p_piso == "")
                    {
                        piso = "-";
                    }
                    else
                    {

                        piso = p_piso;
                    }

                    if (p_dpto == "")
                    {

                        dpto = "-";
                    }
                    else
                    {
                        dpto = p_dpto;
                    }

                    string domicilio = p_calle + " " + p_numero + " Piso: " + piso + " Dpto: " + dpto + " Barrio: " + p_barrio;
                    personal.Domicilio = domicilio;
                }

                if (!string.IsNullOrEmpty(p_localidad))
                {
                    personal.Localidad = p_localidad;
                }

                if (!string.IsNullOrEmpty(p_celular))
                {
                    personal.NroContacto = p_celular;
                }

                if ((!string.IsNullOrEmpty(p_email1)) && (!string.IsNullOrEmpty(p_email2)))
                {
                    string email = p_email1 + "@" + p_email2;
                    personal.EmailContacto = email;
                }

                personal.UsuarioAlta = 1;
                personal.FechaAlta = DateTime.Today;


                #endregion

                gPersonal.DaRegistrarPersonal(personal);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el personal " + e.Message;
                return error;
            }

        }


        [WebMethod]
        public static List<Personal> cargarPersonal()
        {
            List<Personal> Personal = null;

            try
            {
                GestorPersonal gestorPersonal = new GestorPersonal();
                Personal = gestorPersonal.obtenerPersonal();
            }
            catch (Exception e)
            {
                Personal = null;
                throw e;
            }
            return Personal;
        }



        [WebMethod]
        public static Personal buscaPersonal(int idPersonal)
        {
            try
            {
                Personal personal = new Personal();
                GestorPersonal gestorPersonal = new GestorPersonal();
                personal = gestorPersonal.obtenerPersonal(idPersonal);

                return personal;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string actualizarPersonal(string id, string nombre, string apellido, string dni, string fechaNacimiento,
                                                   string localidad, string barrio, string direccion, string piso, string dpto, string celular, string email1, string email2)
        {
            string infoPiso;
            string infoDpto;

            Personal personal = new Personal();
            GestorPersonal gestorPersonal = new GestorPersonal();


            try
            {
                string mensaje = "OK";

                #region Completa entidad Personal

                if (!string.IsNullOrEmpty(dni))
                {
                    personal.Documento = dni;
                }

                if (!string.IsNullOrEmpty(nombre))
                {
                    personal.Nombre = nombre;
                }

                if (!string.IsNullOrEmpty(apellido))
                {
                    personal.Apellido = apellido;
                }

                if (!string.IsNullOrEmpty(fechaNacimiento))
                {
                    personal.FechaNacimiento = Convert.ToDateTime(fechaNacimiento);
                }

                if (!string.IsNullOrEmpty(direccion))
                {
                    if (piso == "")
                    {
                        infoPiso = "-";
                    }
                    else
                    {

                        infoPiso = piso;
                    }

                    if (dpto == "")
                    {

                        infoDpto = "-";
                    }
                    else
                    {
                        infoDpto = dpto;
                    }

                    string domicilio = direccion + " Piso: " + infoPiso + " Dpto: " + infoDpto + " Barrio: " + barrio;
                    personal.Domicilio = domicilio;
                }

                if (!string.IsNullOrEmpty(localidad))
                {
                    personal.Localidad = localidad;
                }

                if (!string.IsNullOrEmpty(celular))
                {
                    personal.NroContacto = celular;
                }

                if ((!string.IsNullOrEmpty(email1)) && (!string.IsNullOrEmpty(email2)))
                {
                    string email = email1 + "@" + email2;
                    personal.EmailContacto = email;
                }

                personal.IdPersonal = Convert.ToInt32(id);

                personal.UsuarioMod = 1;
                personal.FechaMod = DateTime.Today;

                #endregion

                gestorPersonal.ActualizarPersonal(personal);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del personal " + e.Message;
                return error;
            }

        }



        [WebMethod]
        public static string darBajaPersonal(string idPersonal)
        {

            Personal personal = new Personal();
            GestorPersonal gestorPersonal = new GestorPersonal();

            try
            {
                string mensaje = "OK";

                int id = Convert.ToInt32(idPersonal);


                string resultadoBajaProfUsuario = gestorPersonal.DarDeBajaUsuarioPersonal(id, 1);

                if (resultadoBajaProfUsuario == "OK")
                {

                    personal.IdPersonal = id;

                    personal.UsuarioBaja = 1;
                    personal.FechaBaja = DateTime.Today;

                    mensaje = gestorPersonal.DarBajaPersonal(personal);


                }               

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del personal " + e.Message;
                return error;
            }

        }


      


    }
}