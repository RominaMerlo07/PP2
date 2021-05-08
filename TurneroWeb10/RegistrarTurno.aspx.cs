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
    public partial class RegistrarTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registrarTurno(string p_centro, string p_especialidad, string p_fechaTurno, string p_horaTurno, string p_obra_social, string p_minTurno,
                                            string p_nombre, string p_apellido, string p_documento, string p_celular, string p_email1, string p_email2)
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

                //if (!string.IsNullOrEmpty(p_obra_social))   
                //{
                //    ObraSocial obraSocial = new ObraSocial(p_obra_social, centro.IdCentro);
                //    turno.ObraSocial = obraSocial;
                //}                

                if ((!string.IsNullOrEmpty(p_horaTurno)) && (!string.IsNullOrEmpty(p_minTurno)))
                {
                    TimeSpan ts = TimeSpan.Parse(p_horaTurno + ":" + p_minTurno);
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


                gestorTurno.RegistrarTurno(turno, paciente);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "error al registrar turno " + e.Message;
                return error;
            }

        }

    }
}