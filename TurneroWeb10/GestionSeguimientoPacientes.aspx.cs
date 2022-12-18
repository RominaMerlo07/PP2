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
    public partial class GestionSeguimientoPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        public static string registrarHistoriaClinica(string historiaClinica)
        {
            try
            {
                JObject obj = JObject.Parse(historiaClinica);

                Paciente paciente = new Paciente();
                HistoriaClinica histClinica = new HistoriaClinica();

                paciente.IdPaciente = Convert.ToInt32(obj.GetValue("p_idPaciente").ToString());
                paciente.Nombre = obj.GetValue("p_nombrePaciente").ToString();
                paciente.Apellido = obj.GetValue("p_apellidoPaciente").ToString();
                paciente.Documento = obj.GetValue("p_documentoPaciente").ToString(); 
                paciente.NroContacto = obj.GetValue("p_nroPaciente").ToString();
                paciente.EmailContacto = obj.GetValue("p_emailPaciente").ToString();

                histClinica.Tension = Convert.ToBoolean(obj.GetValue("p_tension").ToString());
                histClinica.TensionValores = obj.GetValue("p_tension").ToString();
                histClinica.Diabetes = Convert.ToBoolean(obj.GetValue("p_diabetes").ToString());
                histClinica.Fumador = Convert.ToBoolean(obj.GetValue("p_fumador").ToString());
                histClinica.Cardiaco = Convert.ToBoolean(obj.GetValue("p_cardiaco").ToString());
                histClinica.Cirrosis = Convert.ToBoolean(obj.GetValue("p_cirrosis").ToString());
                histClinica.Artrosis = Convert.ToBoolean(obj.GetValue("p_artrosis").ToString());
                histClinica.ArtritisRematoidea = Convert.ToBoolean(obj.GetValue("p_artritis").ToString());
                histClinica.Hemiplejia = Convert.ToBoolean(obj.GetValue("p_hemiplejia").ToString());
                histClinica.Asma = Convert.ToBoolean(obj.GetValue("p_asma").ToString());
                histClinica.Marcapasos = Convert.ToBoolean(obj.GetValue("p_marcapasos").ToString());
                histClinica.Protesis = Convert.ToBoolean(obj.GetValue("p_protesis").ToString());
                histClinica.CaderaDerecha = Convert.ToBoolean(obj.GetValue("p_caderaDer").ToString());
                histClinica.CaderaIzquierda = Convert.ToBoolean(obj.GetValue("p_caderaIzq").ToString());
                histClinica.Otros = obj.GetValue("p_otros").ToString();
                histClinica.Antecedentes = obj.GetValue("p_antecedentes").ToString();

                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];
                histClinica.UsuarioAlta = usuario.IdUsuario;
                histClinica.FechaAlta = DateTime.Now;


                paciente.HistoriaClinica = histClinica;
                GestorHistoriaClinica gHistClinica = new GestorHistoriaClinica();
                gHistClinica.RegistrarHistClinica(paciente);


                return "Ok" ;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string editarHistoriaClinica(string historiaClinica)
        {
            try
            {
                JObject obj = JObject.Parse(historiaClinica);

                Paciente paciente = new Paciente();
                HistoriaClinica histClinica = new HistoriaClinica();

                paciente.IdPaciente = Convert.ToInt32(obj.GetValue("p_idPaciente").ToString());

                histClinica.Tension = Convert.ToBoolean(obj.GetValue("p_tension").ToString());
                histClinica.TensionValores = obj.GetValue("p_tension_valores").ToString();
                histClinica.Diabetes = Convert.ToBoolean(obj.GetValue("p_diabetes").ToString());
                histClinica.Fumador = Convert.ToBoolean(obj.GetValue("p_fumador").ToString());
                histClinica.Cardiaco = Convert.ToBoolean(obj.GetValue("p_cardiaco").ToString());
                histClinica.Cirrosis = Convert.ToBoolean(obj.GetValue("p_cirrosis").ToString());
                histClinica.Artrosis = Convert.ToBoolean(obj.GetValue("p_artrosis").ToString());
                histClinica.ArtritisRematoidea = Convert.ToBoolean(obj.GetValue("p_artritis").ToString());
                histClinica.Hemiplejia = Convert.ToBoolean(obj.GetValue("p_hemiplejia").ToString());
                histClinica.Asma = Convert.ToBoolean(obj.GetValue("p_asma").ToString());
                histClinica.Marcapasos = Convert.ToBoolean(obj.GetValue("p_marcapasos").ToString());
                histClinica.Protesis = Convert.ToBoolean(obj.GetValue("p_protesis").ToString());
                histClinica.CaderaDerecha = Convert.ToBoolean(obj.GetValue("p_caderaDer").ToString());
                histClinica.CaderaIzquierda = Convert.ToBoolean(obj.GetValue("p_caderaIzq").ToString());
                histClinica.Otros = obj.GetValue("p_otros").ToString();
                histClinica.Antecedentes = obj.GetValue("p_antecedentes").ToString();

                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];
                histClinica.UsuarioMod = usuario.IdUsuario;
                histClinica.FechaMod = DateTime.Now;


                paciente.HistoriaClinica = histClinica;
                GestorHistoriaClinica gHistClinica = new GestorHistoriaClinica();
                gHistClinica.EditarHistClinica(paciente);


                return "Ok";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string buscarTratamientos(string idPaciente)
        {
            try
            {
                GestorPlanTratamiento gPacientes = new GestorPlanTratamiento();
                DataTable planTratamiento = gPacientes.traerTratamientos(idPaciente);
                string col = JsonConvert.SerializeObject(planTratamiento);

                return col;
            }
            catch (Exception e)
            {
                throw e;
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
        public static string editarTratamiento(string tratamientoEdit)
        {
            try
            {
                JObject obj = JObject.Parse(tratamientoEdit);

                PlanTratamiento tratamiento = new PlanTratamiento();


                tratamiento.IdTratamiento = Convert.ToInt32(obj.GetValue("p_idTratamiento").ToString());
                tratamiento.ProfesionalDerivante = obj.GetValue("p_profDerivante").ToString();
                tratamiento.Matricula = obj.GetValue("p_matrProfDerivante").ToString();
                tratamiento.Especialidad = obj.GetValue("p_especProfDerivante").ToString();
                tratamiento.DiagnosticoIngreso = obj.GetValue("p_diagnIngreso").ToString();
                tratamiento.EvaluacionIngreso = obj.GetValue("p_evaIngreso").ToString();
                tratamiento.DescripcionPlan = obj.GetValue("p_descrPlan").ToString();
                tratamiento.ObjetivoPlan = obj.GetValue("p_objPlan").ToString();

                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];
                tratamiento.UsuarioMod = usuario.IdUsuario;
                tratamiento.FechaMod = DateTime.Now;

                GestorPlanTratamiento gPlanTratamiento = new GestorPlanTratamiento();
                gPlanTratamiento.EditarTratamientoSeguimiento(tratamiento);

                return "Ok";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string traerTratamientoDetalle(string idTratamiento)
        {
            try
            {
                GestorPlanTratamiento gTratamiento = new GestorPlanTratamiento();
                DataTable tratamiento = gTratamiento.TraerTratamientoDetalle(idTratamiento);
                string json = JsonConvert.SerializeObject(tratamiento);
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string editarObservacionTurno(string idTurno, string observacion)
        {
            try
            {
                GestorTurno gTurno = new GestorTurno();
                Turno turno = new Turno();
                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];
                turno.UsuarioMod = usuario.IdUsuario;
                turno.FechaMod = DateTime.Now;
                turno.IdTurno = Convert.ToInt32(idTurno);
                turno.Observaciones = observacion;
                gTurno.EditarObservacionTurno(turno);

                return "OK";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string estadoConsentimientoGuardar(string idTratamiento, string estadoConsentimiento)
        {
            try
            {
                PlanTratamiento tratamiento = new PlanTratamiento();
                tratamiento.IdTratamiento = Convert.ToInt32(idTratamiento);
                tratamiento.ConsentimientoFirmado = Convert.ToBoolean(estadoConsentimiento);

                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];
                tratamiento.UsuarioMod = usuario.IdUsuario;
                tratamiento.FechaMod = DateTime.Now;

                GestorPlanTratamiento gPlanTratamiento = new GestorPlanTratamiento();
                gPlanTratamiento.CambiarEstadoConsentimiento(tratamiento);

                return "OK";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string traerDatosHCImprimir(string idTratamiento)
        {
            try
            {
                GestorPlanTratamiento gPacientes = new GestorPlanTratamiento();
                DataTable planTratamientoImprimir = gPacientes.TraerDatosHCImprimir(idTratamiento);
                string col = JsonConvert.SerializeObject(planTratamientoImprimir);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}