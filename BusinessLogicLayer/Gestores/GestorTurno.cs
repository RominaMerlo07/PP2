using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;
using System.Data;

namespace BusinessLogicLayer.Gestores
{
    public class GestorTurno
    {
        public string RegistrarTurno(Turno turno, Paciente paciente)
        {
            string mensaje = "OK";

            try
            {
                DAPaciente DaPaciente = new DAPaciente();
                int idPaciente = DaPaciente.DaRegistrarPaciente(paciente);

                turno.Paciente = paciente;
                turno.Paciente.IdPaciente = idPaciente;

                DATurno Daturno = new DATurno();
                Daturno.DaRegistraTurno(turno);

                return mensaje;
            } catch (Exception e)
            {
                throw e;
            }
            
        }

        public DataTable TraerTurnos(string idProfesionalDetalle)
        {
            try
            {
                DATurno Daturno = new DATurno();
                return Daturno.TraerTurnos(idProfesionalDetalle);           
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable TraerTurnos(string idProfesionalDetalle, DateTime dia)
        {
            try
            {
                DATurno Daturno = new DATurno();
                return Daturno.TraerTurnos(idProfesionalDetalle, dia);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
