using BusinessLogicLayer.Gestores;
using Entidades.ent;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurneroWeb10
{
    public partial class HorariosProfesionales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Select2Prof()
        {
            try
            {
                GestorProfesionales gestorProfesionales = new GestorProfesionales();
                List<Profesional> profesionales = gestorProfesionales.obtenerProfesionales();

                List<Dictionary<string, string>> lista = new List<System.Collections.Generic.Dictionary<string, string>>();

                foreach (Profesional profesional in profesionales) {
                    var columns = new Dictionary<string, string>
                    {
                        { "id", profesional.IdProfesional.ToString()},
                        { "text", profesional.Apellido + ", "+ profesional.Nombre},
                        { "selected", "false" }
                    };

                    lista.Add(columns);
                }
                string cadena = JsonConvert.SerializeObject(lista);
                return cadena;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string traerHorariosProfesional(string idProfesional)
        {
            try
            {
                GestorProfesionales gestorProfesional = new GestorProfesionales();
                Profesional profesional = gestorProfesional.obtenerProfesional(Convert.ToInt32(idProfesional));

                GestorDisponibilidadHoraria gestorDisponibilidad = new GestorDisponibilidadHoraria();
                profesional.HorariosProfesional = gestorDisponibilidad.TraerHorariosProfesional(idProfesional);

                string cadena = JsonConvert.SerializeObject(profesional);
                return cadena;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string traerHorario(string idDisponibilidad)
        {
            try
            {

                GestorDisponibilidadHoraria gestorDisponibilidad = new GestorDisponibilidadHoraria();
                Entidades.ent.DisponibilidadHoraria HorariosProfesional = gestorDisponibilidad.TraerHorario(idDisponibilidad);

                string cadena = JsonConvert.SerializeObject(HorariosProfesional);
                return cadena;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static List<Centro> cargarCentros()
        {
            try
            {
                GestorCentros gestorCentros = new GestorCentros();
                List<Centro> centros = gestorCentros.obtenerCentros();
                return centros;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
        [WebMethod]
        public static String validarDisponibilidad(string disponibilidad)
        {
            try
            {
                JObject obj = JObject.Parse(disponibilidad);

                Entidades.ent.DisponibilidadHoraria horarioDisponibilidad = new Entidades.ent.DisponibilidadHoraria();

                horarioDisponibilidad.FechaInic = Convert.ToDateTime(obj.GetValue("p_fechaDesde").ToString());
                horarioDisponibilidad.FechaFin = Convert.ToDateTime(obj.GetValue("p_fechaHasta").ToString());
                string horaD = obj.GetValue("p_horaDesde").ToString();
                string minD = obj.GetValue("p_minDesde").ToString();
                horarioDisponibilidad.HoraDesde = TimeSpan.Parse(horaD + ":" + minD);

                string horaH = obj.GetValue("p_horaHasta").ToString();
                string minH = obj.GetValue("p_minHasta").ToString();
                horarioDisponibilidad.HoraHasta = TimeSpan.Parse(horaH + ":" + minH);

                Centro centro = new Centro();
                centro.IdCentro = Convert.ToInt32(obj.GetValue("p_sucursal").ToString());
                horarioDisponibilidad.Centro = centro;

                horarioDisponibilidad.Lunes = Convert.ToBoolean(obj.GetValue("p_lunes").ToString());
                horarioDisponibilidad.Martes = Convert.ToBoolean(obj.GetValue("p_martes").ToString());
                horarioDisponibilidad.Miercoles = Convert.ToBoolean(obj.GetValue("p_miercoles").ToString());
                horarioDisponibilidad.Jueves = Convert.ToBoolean(obj.GetValue("p_jueves").ToString());
                horarioDisponibilidad.Viernes = Convert.ToBoolean(obj.GetValue("p_viernes").ToString());

                string idProfesional = obj.GetValue("p_idProfesional").ToString();

                GestorDisponibilidadHoraria gestorDisponibilidad = new GestorDisponibilidadHoraria();
                string result = gestorDisponibilidad.ValidarDisponibilidad(idProfesional, horarioDisponibilidad);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static String registrarDisponibilidad(string disponibilidad)
        {
            try
            {
                JObject obj = JObject.Parse(disponibilidad);

                Entidades.ent.DisponibilidadHoraria horarioDisponibilidad = new Entidades.ent.DisponibilidadHoraria();

                horarioDisponibilidad.FechaInic = Convert.ToDateTime(obj.GetValue("p_fechaDesde").ToString());
                horarioDisponibilidad.FechaFin = Convert.ToDateTime(obj.GetValue("p_fechaHasta").ToString());
                string horaD = obj.GetValue("p_horaDesde").ToString();
                string minD = obj.GetValue("p_minDesde").ToString();
                horarioDisponibilidad.HoraDesde = TimeSpan.Parse(horaD + ":" + minD);

                string horaH = obj.GetValue("p_horaHasta").ToString();
                string minH = obj.GetValue("p_minHasta").ToString();
                horarioDisponibilidad.HoraHasta = TimeSpan.Parse(horaH + ":" + minH);

                Centro centro = new Centro();
                centro.IdCentro = Convert.ToInt32(obj.GetValue("p_sucursal").ToString());
                horarioDisponibilidad.Centro = centro;

                horarioDisponibilidad.Lunes = Convert.ToBoolean(obj.GetValue("p_lunes").ToString());
                horarioDisponibilidad.Martes = Convert.ToBoolean(obj.GetValue("p_martes").ToString());
                horarioDisponibilidad.Miercoles = Convert.ToBoolean(obj.GetValue("p_miercoles").ToString());
                horarioDisponibilidad.Jueves = Convert.ToBoolean(obj.GetValue("p_jueves").ToString());
                horarioDisponibilidad.Viernes = Convert.ToBoolean(obj.GetValue("p_viernes").ToString());

                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];

                horarioDisponibilidad.FechaAlta = DateTime.Now;
                horarioDisponibilidad.UsuarioAlta = usuario.IdUsuario;

                string idProfesional = obj.GetValue("p_idProfesional").ToString();

                GestorDisponibilidadHoraria gestorDisponibilidad = new GestorDisponibilidadHoraria();

                string result = gestorDisponibilidad.ValidarDisponibilidad(idProfesional, horarioDisponibilidad);
                if (result == "OK")
                    result = gestorDisponibilidad.RegistrarDisponibilidad(idProfesional, horarioDisponibilidad);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static String consultarTurnosEnDisponibilidad(string idDisponibilidad, string idProfesional)
        {
            try
            {
                GestorDisponibilidadHoraria gestorDisponibilidad = new GestorDisponibilidadHoraria();
                string result = gestorDisponibilidad.ConsultarTurnosEnDisponibilidad(idDisponibilidad, idProfesional);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static String darDeBajaDisponibilidad(string idDisponibilidad, string idProfesional)
        {
            try
            {
                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];

                GestorDisponibilidadHoraria gestorDisponibilidad = new GestorDisponibilidadHoraria();
                string result = gestorDisponibilidad.DarDeBajaDisponibilidad(idDisponibilidad, idProfesional, usuario.IdUsuario);

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}