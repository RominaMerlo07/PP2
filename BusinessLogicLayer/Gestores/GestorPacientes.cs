using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;

namespace BusinessLogicLayer.Gestores
{
    public class GestorPacientes
    {
        public string RegistrarPaciente(Paciente paciente)
        {
            try
            {
                DAPaciente2 DaPaciente = new DAPaciente2();
                return DaPaciente.DaRegistrarPaciente(paciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
