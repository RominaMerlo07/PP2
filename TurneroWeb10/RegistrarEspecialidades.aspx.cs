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

        [WebMethod]
        public static string ObtenerTurnosFuturos(string p_id)
        {

            string col = "sin info";

            try
            {
                GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();

                int id = Convert.ToInt32(p_id);

                int cantTurnosFuturos = gestorEspecialidades.TurnosFuturos(id);

                if (cantTurnosFuturos > 0)
                {

                    DataTable dt = gestorEspecialidades.ObtenerTurnosFuturos(id);
                    col = JsonConvert.SerializeObject(dt);
                    return col;
                }

                return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string MostrarTurnosFuturos(string p_id)
        {

            string col = "sin info";

            try
            {
                GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();

                int id = Convert.ToInt32(p_id);
                DataTable dt = gestorEspecialidades.ObtenerTurnosFuturos(id);
                col = JsonConvert.SerializeObject(dt);
                return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string DarDeBajaTurnos(string p_id)
        {

            string col = "OK";
            try
            {

                GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();
                Especialidad especialidad = new Especialidad();

                int id = Convert.ToInt32(p_id);

                int cantIdTratamiento = gestorEspecialidades.obtenerTratamientos(id);

                if (cantIdTratamiento > 0) {

                    string resultadoBajaTratamiento = gestorEspecialidades.DarBajaTratamiento(id, 1);

                    if (resultadoBajaTratamiento == "OK") { 

                    string resultado = gestorEspecialidades.DaDarDeBajaTurnos(id, 1);

                        if (resultado == "OK")
                        {
                            especialidad.IdEspecialidad = id;
                            especialidad.UsuarioBaja = 1;
                            especialidad.FechaBaja = DateTime.Today;

                            col = gestorEspecialidades.DaDarDeBajaEspecialidad(especialidad);
                        }
                    }

                }
                else {

                    string resultado = gestorEspecialidades.DaDarDeBajaTurnos(id, 1);

                    if (resultado == "OK")
                    {
                        especialidad.IdEspecialidad = id;
                        especialidad.UsuarioBaja = 1;
                        especialidad.FechaBaja = DateTime.Today;

                        col = gestorEspecialidades.DaDarDeBajaEspecialidad(especialidad);
                    }
                }
                return col;

                //return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string darBajaEspecialidad(string p_id)
        {
            Especialidad especialidad = new Especialidad();
            GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();

            try
            {
                string mensaje = "OK";

                especialidad.IdEspecialidad = Convert.ToInt32(p_id);
                especialidad.UsuarioBaja = 1;
                especialidad.FechaBaja = DateTime.Today;

                mensaje = gestorEspecialidades.darBajaEspecialidad(especialidad);

                return mensaje;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [WebMethod]
        public static string validarEspecialidad(string especialidad)
        {

            string result = "OK";
            try
            {
                GestorEspecialidades gEspecialidades = new GestorEspecialidades();

                int existeEspecialidad = gEspecialidades.validarEspecialidad(especialidad);

                if (existeEspecialidad > 0)
                {

                    result = "existe";
                    return result;
                }
                else
                {
                    return result;
                }


            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}