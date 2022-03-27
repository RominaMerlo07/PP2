using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;
using System.Data;

namespace BusinessLogicLayer.Gestores
{
    public class GestorPacientes
    {

        public int RegistrarPacientes(Paciente paciente, string p_obraSocial, string p_plan, string nroAfiliado)
        {
            try
            {
                DAPaciente DaPaciente = new DAPaciente();
                paciente.IdPaciente = DaPaciente.DaRegistrarPaciente(paciente);


                if (paciente.IdPaciente > 0)
                {
                    ObrasPacientes obraPaciente = new ObrasPacientes();

                    obraPaciente.IdObraSocial = Convert.ToInt32(p_obraSocial);
                    obraPaciente.IdPaciente = paciente.IdPaciente;
                    obraPaciente.IdPlan = Convert.ToInt32(p_plan);
                    obraPaciente.nroAfiliado = nroAfiliado;
                    obraPaciente.UsuarioAlta = paciente.UsuarioAlta;
                    obraPaciente.FechaAlta = paciente.FechaAlta;

                    DAObraPaciente DaObraPaciente = new DAObraPaciente();
                    int idObraPaciente = DaObraPaciente.RegistrarObraPaciente(obraPaciente);

                }
                return paciente.IdPaciente;
            }
        
            catch (Exception e)
            {
                throw e;
            }
        }

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

        public DataTable cargarPacientes()
        {
            try
            {
                DAPaciente daPaciente = new DAPaciente();
                return daPaciente.cargarPacientes();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable buscarPaciente(string idPaciente)
        {
            try
            {
                DAPaciente daPaciente = new DAPaciente();
                return daPaciente.buscarPaciente(idPaciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string actualizarPaciente(Paciente paciente)
        {
            try
            {
                DAPaciente DaPaciente = new DAPaciente();
                return DaPaciente.actualizarPaciente(paciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable obraSocialPaciente(string idPaciente)
        {
            try
            {
                DAPaciente DaPaciente = new DAPaciente();
                return DaPaciente.obraSocialPaciente(idPaciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int registrarOSPaciente(ObrasPacientes obrasPaciente)
        {
            try
            {
                DAPaciente DAPaciente = new DAPaciente();
                return DAPaciente.registrarOSPaciente(obrasPaciente);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string inactivarOSPaciente(ObrasPacientes obrasPacientes)
        {
            try
            {
                DAObraPaciente DAObrasPacientes = new DAObraPaciente();
                return DAObrasPacientes.inactivarOSPaciente(obrasPacientes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string actualizarOSPaciente(ObrasPacientes obrasPacientes)
        {
            try
            {
                DAObraPaciente DAObrasPacientes = new DAObraPaciente();
                return DAObrasPacientes.actualizarOSPaciente(obrasPacientes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
