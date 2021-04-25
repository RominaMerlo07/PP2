using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;

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
    }
}
