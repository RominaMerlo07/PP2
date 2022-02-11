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
    public partial class RegistrarTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registrarTurno(string p_centro, string p_especialidad, string p_fechaTurno, string p_horaTurno, //string p_obra_social, string p_minTurno,
                                            string p_nombre, string p_apellido, string p_documento, string p_celular, string p_email1, string p_email2, 
                                            string p_obraSocial, string p_planObra, string p_nroAfiliado, string p_profesional, string es_edicion)
        {

            Turno turno = new Turno();
            Paciente paciente = new Paciente();
            GestorTurno gestorTurno = new GestorTurno();
            Centro centro = new Centro();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Turno

                if (!string.IsNullOrEmpty(p_centro))
                {
                    
                    centro.IdCentro = Convert.ToInt32(p_centro);
                    turno.Centro = centro;
                }

                if (!string.IsNullOrEmpty(p_profesional))
                {
                    Profesional prof = new Profesional();
                    prof.IdProfesional = Convert.ToInt32(p_profesional);
                    turno.Profesional = prof;
                }

                if (!string.IsNullOrEmpty(p_especialidad))
                {
                    Especialidad especialidad = new Especialidad();
                    especialidad.IdEspecialidad = Convert.ToInt32(p_especialidad);
                    turno.Especialidad = especialidad;
                }

                if (!string.IsNullOrEmpty(p_fechaTurno))
                {
                    turno.FechaTurno = Convert.ToDateTime(p_fechaTurno);
                }

                //Sumar Campo de Obra Social
                ObraSocial obraSocial = new ObraSocial();

                if (!string.IsNullOrEmpty(p_obraSocial))
                {
                    obraSocial.IdObraSocial = Convert.ToInt32(p_obraSocial);
                    turno.ObraSocial = obraSocial;
                }

                if (!string.IsNullOrEmpty(p_planObra))
                {
                    obraSocial.IdPlanObra = Convert.ToInt32(p_planObra);
                    turno.ObraSocial = obraSocial;
                }

                if (!string.IsNullOrEmpty(p_nroAfiliado))
                {
                    turno.NroAfiliado = p_nroAfiliado;
                }
                

                if (!string.IsNullOrEmpty(p_horaTurno))
                {
                    TimeSpan ts = TimeSpan.Parse(p_horaTurno);
                    turno.HoraDesde = ts;
                }

                turno.UsuarioAlta = 1;
                turno.FechaAlta = DateTime.Today;

                #endregion

                #region Completa entidad Paciente

                if (!string.IsNullOrEmpty(p_nombre))
                {
                    paciente.Nombre = p_nombre;
                }

                if (!string.IsNullOrEmpty(p_apellido))
                {
                    paciente.Apellido = p_apellido;
                }

                if (!string.IsNullOrEmpty(p_documento))
                {
                    paciente.Documento = p_documento;
                }

                if (!string.IsNullOrEmpty(p_celular))
                {
                    paciente.NroContacto = p_celular;
                }

                if ((!string.IsNullOrEmpty(p_email1)) && (!string.IsNullOrEmpty(p_email2)))
                {
                    string email = p_email1 + "@" + p_email2;
                    paciente.EmailContacto = email;
                }

                paciente.UsuarioAlta = 1; //hardcode
                paciente.FechaAlta = DateTime.Today;

                #endregion


                gestorTurno.RegistrarTurno(turno, paciente, Convert.ToBoolean(es_edicion));

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "error al registrar turno " + e.Message;
                return error;
            }

        }

        [WebMethod]
        public static List<Centro> cargarCentros()
        {
            try
            {
                GestorCentros gestorCentros = new GestorCentros();
                List<Centro> centros = gestorCentros.traerCentros();
                return centros;
                //string col = JsonConvert.SerializeObject(centros);
                //return col;
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
                List<Profesional> especialidades = new List<Profesional>();//gestorEspecialidades.obtenerEspecialidades();
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
        public static string cargarEspecialidades(string idCentro)
        {
            try
            {
                GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();
                List<Especialidad> especialidades = new List<Especialidad>();//gestorEspecialidades.obtenerEspecialidades();
                DataTable dt = gestorEspecialidades.obtenerEspecialidadDisponible(idCentro);
                string col = JsonConvert.SerializeObject(dt);
                //foreach (DataRow row in dt.Rows)
                //{
                //    Especialidad especialidad = new Especialidad();

                //    especialidad.IdEspecialidad = Convert.ToInt32(row["ID_PROFESIONALES_DETALLE"].ToString());
                //    especialidad.Descripcion = row["DESCRIPCION"].ToString();

                //    especialidades.Add(especialidad);
                //}

                //return especialidades;
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
    }
}