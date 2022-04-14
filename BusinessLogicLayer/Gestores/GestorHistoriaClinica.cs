using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;
using System.Data;

namespace BusinessLogicLayer.Gestores
{
    public class GestorHistoriaClinica
    {
        public void RegistrarHistClinica(Paciente paciente)
        {
            try
            {
                //registra histClinica
                DAHistoriaClinica daHC = new DAHistoriaClinica();
                //traeID
                paciente.HistoriaClinica.IdHistoriaClinica = daHC.registrarHistoriaClinica(paciente);
                paciente.UsuarioMod = paciente.HistoriaClinica.UsuarioAlta;
                paciente.FechaMod = paciente.HistoriaClinica.FechaAlta;

                DAPaciente daPaciente = new DAPaciente();
                daPaciente.DaEditarPaciente(paciente);
                //modifica Paciente con idHistoriaClinica
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
