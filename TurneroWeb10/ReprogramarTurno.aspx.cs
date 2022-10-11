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
using Newtonsoft.Json.Linq;

namespace TurneroWeb10
{
    public partial class ReprogramarTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        public static string traerTurnosReprogramar(string idCentro)
        {
            try
            {
                GestorTurno gestorTurnos = new GestorTurno();
                List<Turno> turnos = gestorTurnos.TraerTurnosReprogramar(idCentro);

                string cadena = JsonConvert.SerializeObject(turnos);
                return cadena;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string cancelarTurnoReprogramar(string idTurno)
        {
            try
            {
                GestorTurno gestorTurnos = new GestorTurno();
                return gestorTurnos.CancelarTurnoReprogramar(idTurno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [WebMethod]
        public static string cargarDatosTurnoReprogramar(string idTurno)
        {
            try
            {
                GestorTurno gestorTurnos = new GestorTurno();
                Turno turnos = gestorTurnos.CargarDatosTurnoReprogramar(idTurno);

                string cadena = JsonConvert.SerializeObject(turnos);
                return cadena;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string traerDisponibilidadHoraria(string idProfesional, string centro)
        {
            try
            {
                GestorProfesionales gestorProfesional = new GestorProfesionales();
                Profesional profesional = gestorProfesional.obtenerProfesional(Convert.ToInt32(idProfesional));

                GestorDisponibilidadHoraria gestorDisponibilidad = new GestorDisponibilidadHoraria();
                profesional.HorariosProfesional = gestorDisponibilidad.TraerHorariosProfesional(idProfesional, centro);

                string cadena = JsonConvert.SerializeObject(profesional);
                return cadena;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string reprogramarDiaTurno(string objTurnoTratamiento)
        {
            try
            {
                JObject obj = JObject.Parse(objTurnoTratamiento);

                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];

                Turno turno = new Turno();
                turno.Paciente = new Paciente();
                turno.Paciente.IdPaciente = Convert.ToInt32(obj.GetValue("p_idPaciente").ToString());
                turno.Profesional = new Profesional();
                turno.Profesional.IdProfesional = Convert.ToInt32(obj.GetValue("p_idProfesional").ToString());
                //turno.ObraSocial = new ObraSocial();
                //turno.ObraSocial.IdObraSocial = Convert.ToInt32(obj.GetValue("p_idObraSocial").ToString());
                //turno.ObraSocial.IdPlanObra = Convert.ToInt32(obj.GetValue("p_idPlanObra").ToString());
                //turno.NroAfiliado = obj.GetValue("p_nroAfiliado").ToString();
                //turno.NroAutorizacionObra = obj.GetValue("p_nroAutorizacion").ToString();
                turno.Centro = new Centro();
                turno.Centro.IdCentro = Convert.ToInt32(obj.GetValue("p_idSucursal").ToString());
                turno.Especialidad = new Especialidad();
                turno.Especialidad.IdEspecialidad = Convert.ToInt32(obj.GetValue("p_idEspecialidad").ToString());
                turno.FechaTurno = Convert.ToDateTime(obj.GetValue("p_DiaTurno").ToString());
                TimeSpan ts = TimeSpan.Parse(obj.GetValue("p_HoraTurno").ToString());
                turno.HoraDesde = ts;
                turno.IdTurno = Convert.ToInt32(obj.GetValue("p_idTurno").ToString());

                turno.UsuarioMod = usuario.IdUsuario;
                turno.FechaMod = DateTime.Now;
                
                GestorTurno gTurno = new GestorTurno();
                bool verificacion = gTurno.VerificarTurnoDisponible(turno);

                if (verificacion)
                {
                    bool resultado = gTurno.ValidacionDelDiaTurno(turno);

                    if (resultado)
                    {

                        gTurno.ReprogramarTurno(turno);

                        return "OK";
                    }
                    else
                        return "Err2"; //Dia no disponible
                }
                else
                {
                    return "Err1"; // Turno no disponible
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}