using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;

namespace BusinessLogicLayer.Gestores
{
    public class GestorPacientes
    {
        public int RegistrarPaciente(Paciente paciente)
        {
            try
            {
                DAPaciente DaPaciente = new DAPaciente();
                return DaPaciente.DaRegistrarPaciente(paciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Paciente BuscarPaciente(string dniPaciente)
        {
            try
            {
                DAPaciente DaPaciente = new DAPaciente();
                return DaPaciente.BuscarPaciente(dniPaciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
