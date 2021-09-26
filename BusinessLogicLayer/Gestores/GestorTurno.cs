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
        public string RegistrarTurno(Turno turno, Paciente paciente, bool es_edicion)
        {
            string mensaje = "OK";

            int idPaciente;

            try
            {
                if (es_edicion)
                {
                    DAPaciente DaPaciente = new DAPaciente();
                    paciente.UsuarioMod = 1; //hardcode
                    paciente.FechaMod = DateTime.Now;
                    idPaciente = DaPaciente.DaEditarPaciente(paciente);
                }
                else
                {
                    DAPaciente DaPaciente = new DAPaciente();
                    idPaciente = DaPaciente.DaRegistrarPaciente(paciente);                    
                }

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
