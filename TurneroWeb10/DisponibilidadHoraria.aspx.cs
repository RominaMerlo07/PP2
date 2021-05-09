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
    public partial class DisponibilidadHoraria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registrarDisponibilidad(string p_profesional, string p_sucursal, string p_especialidad, string p_fechaDesde, string p_fechaHasta,
                        string p_horaDesde, string p_minDesde, string p_horaHasta, string p_minHasta)
        {

            Entidades.ent.DisponibilidadHoraria disponibilidad = new Entidades.ent.DisponibilidadHoraria();
            ProfesionalDetalle profDetalle = new ProfesionalDetalle(); // p_profesional p_sucursal p_especialidad, para traer IdProfesionalDetalle
            GestorDisponibilidadHoraria gestorDisponibilidad = new GestorDisponibilidadHoraria();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Disponibilidad

                if (!string.IsNullOrEmpty(p_profesional)) {
                    profDetalle.IdProfesionalDetalle = 1; // hardcode, quitar
                    disponibilidad.ProfesionalDetalle = profDetalle;
                }

                if (!string.IsNullOrEmpty(p_fechaDesde))
                    disponibilidad.FechaInic = Convert.ToDateTime(p_fechaDesde);
                if (!string.IsNullOrEmpty(p_fechaHasta))
                    disponibilidad.FechaFin = Convert.ToDateTime(p_fechaHasta);

                if ((!string.IsNullOrEmpty(p_horaDesde)) && (!string.IsNullOrEmpty(p_minDesde)))
                {
                    TimeSpan ts = TimeSpan.Parse(p_horaDesde + ":" + p_minDesde);
                    disponibilidad.HoraDesde= ts;
                }

                if ((!string.IsNullOrEmpty(p_horaHasta)) && (!string.IsNullOrEmpty(p_minHasta)))
                {
                    TimeSpan ts = TimeSpan.Parse(p_horaHasta + ":" + p_minHasta);
                    disponibilidad.HoraHasta = ts;
                }

                disponibilidad.UsuarioAlta = 1;
                disponibilidad.FechaAlta = DateTime.Today;

                #endregion

                gestorDisponibilidad.RegistrarDisponibilidad(disponibilidad);

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