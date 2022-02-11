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
    public partial class GestionTratamientos : System.Web.UI.Page
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
        public static string cargarEspecialidades(string idCentro)
        {
            try
            {
                GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();
                List<Especialidad> especialidades = new List<Especialidad>();
                DataTable dt = gestorEspecialidades.obtenerEspecialidadDisponible(idCentro);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string cargarProfesionales(string idCentro, string idEspecialidad)
        {
            try
            {
                GestorProfesionales gestorProfesionales = new GestorProfesionales();
                List<Profesional> especialidades = new List<Profesional>();
                DataTable dt = gestorProfesionales.obtenerProfesionalesDisponibles(idCentro, idEspecialidad);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string buscarPaciente(string dniPaciente)
        {
            try
            {
                GestorPacientes gPacientes = new GestorPacientes();
                Paciente paciente = new Paciente();
                paciente = gPacientes.BuscarPaciente(dniPaciente);
                string col = JsonConvert.SerializeObject(paciente);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static List<ObraSocial> cargarObrasSociales()
        {
            try
            {
                GestorObrasSociales gestorObrasSociales = new GestorObrasSociales();
                List<ObraSocial> obrasSociales = gestorObrasSociales.obtenerObrasSociales();
                return obrasSociales;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string cargarPlanes(string idObraSocial)
        {
            try
            {
                GestorObrasSociales gObras = new GestorObrasSociales();
                DataTable obras = gObras.TraerPlanes(idObraSocial);
                string col = JsonConvert.SerializeObject(obras);

                return col;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string traerDisponibilidadHoraria(string idProfesional, string idEspecialidad, string idCentro, string dia = null)
        {
            try
            {
                GestorProfesionales gProfesionales = new GestorProfesionales();
                DataTable dt = gProfesionales.TraerDisponibilidadHoraria(idProfesional, idEspecialidad, idCentro, dia);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string traerTurnos(string idProfesional, string dia)
        {
            try
            {
                DateTime diaTurno = DateTime.Parse(dia);
                GestorTurno gTurno = new GestorTurno();
                DataTable dt = gTurno.TraerTurnos(idProfesional, diaTurno);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static bool verificarTurnoDisponible(string sucursalId, string especialidadId, string profesionalId, string diaTurno, string hora)
        {
            try
            {
                Turno turno = new Turno();
                GestorTurno gestorTurno = new GestorTurno();

                if (!string.IsNullOrEmpty(sucursalId))
                {
                    Centro centro = new Centro();
                    centro.IdCentro = Convert.ToInt32(sucursalId);
                    turno.Centro = centro;
                }

                if (!string.IsNullOrEmpty(especialidadId))
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.IdEspecialidad = Convert.ToInt32(especialidadId);
                    turno.Especialidad = especialidad;
                }

                if (!string.IsNullOrEmpty(profesionalId))
                {
                    Profesional prof = new Profesional();
                    prof.IdProfesional = Convert.ToInt32(profesionalId);
                    turno.Profesional = prof;
                }

                if (!string.IsNullOrEmpty(diaTurno))
                {
                    turno.FechaTurno = Convert.ToDateTime(diaTurno);
                }

                if (!string.IsNullOrEmpty(hora))
                {
                    TimeSpan ts = TimeSpan.Parse(hora);
                    turno.HoraDesde = ts;
                }

                bool validacion = gestorTurno.VerificarTurnoDisponible(turno);

                return validacion;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static void registrarTratamiento(string arrayTratamiento)
        {
            try
            {
                PlanTratamiento tratamiento = new PlanTratamiento();
                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];
                tratamiento.UsuarioAlta = usuario.IdUsuario;
                tratamiento.FechaAlta = DateTime.Now;
                tratamiento.Fecha = DateTime.Now;

                List<Turno> turnoLista = new List<Turno>();

                JArray array = JArray.Parse(arrayTratamiento);

                foreach (JObject obj in array.Children<JObject>())
                {
                    Turno turno = new Turno();

                    turno.Paciente = new Paciente();
                    turno.Paciente.IdPaciente = Convert.ToInt32(obj.GetValue("p_idPaciente").ToString());
                    turno.Profesional = new Profesional();
                    turno.Profesional.IdProfesional = Convert.ToInt32(obj.GetValue("p_idProfesional").ToString());
                    turno.ObraSocial = new ObraSocial();
                    turno.ObraSocial.IdObraSocial = Convert.ToInt32(obj.GetValue("p_idObraSocial").ToString());
                    turno.ObraSocial.IdPlanObra = Convert.ToInt32(obj.GetValue("p_idPlanObra").ToString());
                    turno.NroAfiliado = obj.GetValue("p_nroAfiliado").ToString();
                    turno.NroAutorizacionObra = obj.GetValue("p_nroAutorizacion").ToString();
                    turno.Centro = new Centro();
                    turno.Centro.IdCentro = Convert.ToInt32(obj.GetValue("p_idSucursal").ToString());
                    turno.Especialidad = new Especialidad();
                    turno.Especialidad.IdEspecialidad = Convert.ToInt32(obj.GetValue("p_idEspecialidad").ToString());
                    turno.FechaTurno = Convert.ToDateTime(obj.GetValue("p_DiaTurno").ToString());
                    TimeSpan ts = TimeSpan.Parse(obj.GetValue("p_HoraTurno").ToString());
                    turno.HoraDesde = ts;

                    turno.UsuarioAlta = usuario.IdUsuario;
                    turno.FechaAlta = DateTime.Now;

                    turnoLista.Add(turno);
                }

                GestorPlanTratamiento gTratamiento = new GestorPlanTratamiento();
                int idTratamiento = gTratamiento.AgregarTratamiento(tratamiento, turnoLista);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string traerTratamientos(string idPaciente)
        {
            try
            {
                GestorPlanTratamiento gTratamiento = new GestorPlanTratamiento();
                DataTable tratamientos = gTratamiento.traerTratamientos(idPaciente);
                string json = JsonConvert.SerializeObject(tratamientos);
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static void darBajaTratamiento(string idTratamiento)
        {
            try
            {
                GestorPlanTratamiento gTratamiento = new GestorPlanTratamiento();
                PlanTratamiento tratamiento = new PlanTratamiento();
                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];
                tratamiento.IdTratamiento = Convert.ToInt32(idTratamiento);
                tratamiento.UsuarioBaja = usuario.IdUsuario;
                tratamiento.FechaBaja = DateTime.Now;

                gTratamiento.DarBajaTratamiento(tratamiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string traerTratamientoEditar(string idTratamiento)
        {
            try
            {
                GestorPlanTratamiento gTratamiento = new GestorPlanTratamiento();
                DataTable tratamiento = gTratamiento.TraerTratamientoEditar(idTratamiento);
                string json = JsonConvert.SerializeObject(tratamiento);
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string agregarTurnoEditarTratamiento(string objTurnoTratamiento)
        {
            try
            {
                JObject obj = JObject.Parse(objTurnoTratamiento);

                PlanTratamiento tratamiento = new PlanTratamiento();
                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];
                tratamiento.UsuarioMod = usuario.IdUsuario;
                tratamiento.FechaMod = DateTime.Now;
                tratamiento.IdTratamiento = Convert.ToInt32(obj.GetValue("p_idTratamiento").ToString());

                Turno turno = new Turno();
                turno.Paciente = new Paciente();
                turno.Paciente.IdPaciente = Convert.ToInt32(obj.GetValue("p_idPaciente").ToString());
                turno.Profesional = new Profesional();
                turno.Profesional.IdProfesional = Convert.ToInt32(obj.GetValue("p_idProfesional").ToString());
                turno.ObraSocial = new ObraSocial();
                turno.ObraSocial.IdObraSocial = Convert.ToInt32(obj.GetValue("p_idObraSocial").ToString());
                turno.ObraSocial.IdPlanObra = Convert.ToInt32(obj.GetValue("p_idPlanObra").ToString());
                turno.NroAfiliado = obj.GetValue("p_nroAfiliado").ToString();
                turno.NroAutorizacionObra = obj.GetValue("p_nroAutorizacion").ToString();
                turno.Centro = new Centro();
                turno.Centro.IdCentro = Convert.ToInt32(obj.GetValue("p_idSucursal").ToString());
                turno.Especialidad = new Especialidad();
                turno.Especialidad.IdEspecialidad = Convert.ToInt32(obj.GetValue("p_idEspecialidad").ToString());
                turno.FechaTurno = Convert.ToDateTime(obj.GetValue("p_DiaTurno").ToString());
                TimeSpan ts = TimeSpan.Parse(obj.GetValue("p_HoraTurno").ToString());
                turno.HoraDesde = ts;
                turno.Id_PlanTratamiento = Convert.ToInt32(obj.GetValue("p_idTratamiento").ToString());

                turno.UsuarioAlta = usuario.IdUsuario;
                turno.FechaAlta = DateTime.Now;

                GestorTurno gTurno = new GestorTurno();
                bool verificacion = gTurno.VerificarTurnoDisponible(turno);

                if (verificacion)
                {
                    bool resultado = gTurno.ValidacionDelDiaTurno(turno);

                    if (resultado)
                    {
                        GestorPlanTratamiento gTratamiento = new GestorPlanTratamiento();
                        gTratamiento.EditarTratamiento(tratamiento, turno);

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

        [WebMethod]
        public static string cancelarTurnoEditarTratamiento(string idTurno, string idTratamiento)
        {
            try
            { 
                GestorPlanTratamiento gTratamiento = new GestorPlanTratamiento();
                return gTratamiento.CancelarTurnoEditarTratamiento(idTurno, idTratamiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}