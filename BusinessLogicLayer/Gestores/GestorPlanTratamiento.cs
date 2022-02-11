using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;
using System.Data;

namespace BusinessLogicLayer.Gestores
{
    public class GestorPlanTratamiento
    {
        public int AgregarTratamiento(PlanTratamiento tratamiento, List<Turno> turnoLista)
        {
            try
            {
                DATurno DaTurno = new DATurno();
                DAPlanTratamiento DaPlanTratamiento = new DAPlanTratamiento();

                int idTratamiento = DaPlanTratamiento.InsertarTratamiento(tratamiento);

                foreach (Turno turno in turnoLista)
                {
                    turno.Id_PlanTratamiento = idTratamiento;
                    DaTurno.DaRegistraTurno(turno);
                }

                return idTratamiento;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable traerTratamientos(string idPaciente)
        {
            try
            {
                DAPlanTratamiento daTratamientos = new DAPlanTratamiento();
                return daTratamientos.TraerTratamientos(idPaciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void DarBajaTratamiento(PlanTratamiento tratamiento)
        {
            try
            {
                DAPlanTratamiento daTratamientos = new DAPlanTratamiento();
                daTratamientos.DarBajaTratamiento(tratamiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TraerTratamientoEditar(string idTratamiento)
        {
            try
            {
                DAPlanTratamiento daTratamientos = new DAPlanTratamiento();
                return daTratamientos.TraerTratamientoEditar(idTratamiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarTratamiento(PlanTratamiento tratamiento, Turno turno)
        {
            try
            {
                DATurno daTurno = new DATurno();
                string resultado = daTurno.DaRegistraTurno(turno);
                if (resultado == "OK")
                {
                    DAPlanTratamiento daTratamientos = new DAPlanTratamiento();
                    daTratamientos.EditarTratamiento(tratamiento, turno);
                }
                else
                    throw new Exception("Error al Insertar Turno");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CancelarTurnoEditarTratamiento(string idTurno, string idTratamiento)
        {
            try
            {
                DAPlanTratamiento daTratamientos = new DAPlanTratamiento();
                return daTratamientos.CancelarTurnoEditarTratamiento(idTurno, idTratamiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
