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
        //public string RegistrarTurno(Turno turno, Paciente paciente, string p_obraSocial, string p_planObra, bool es_edicion)
        //{
        //    string mensaje = "OK";

        //    int idPaciente;

        //    try
        //    {
        //        if (es_edicion)
        //        {
        //            DAPaciente DaPaciente = new DAPaciente();
        //            paciente.UsuarioMod = 1; //hardcode
        //            paciente.FechaMod = DateTime.Now;
        //            idPaciente = DaPaciente.DaEditarPaciente(paciente);
        //        }
        //        else
        //        {
        //            DAPaciente DaPaciente = new DAPaciente();
        //            idPaciente = DaPaciente.DaRegistrarPaciente(paciente);                  

        //        }

        //        ObrasPacientes obraPaciente = new ObrasPacientes();

        //        obraPaciente.IdObraSocial = Convert.ToInt32(p_obraSocial);
        //        obraPaciente.IdPaciente = idPaciente;
        //        obraPaciente.IdPlan = Convert.ToInt32(p_planObra);
        //        obraPaciente.nroAfiliado = turno.NroAfiliado;
        //        obraPaciente.UsuarioAlta = paciente.UsuarioAlta;
        //        obraPaciente.FechaAlta = paciente.FechaAlta;

        //        DAObraPaciente DaObraPaciente = new DAObraPaciente();
        //        int idObraPaciente = DaObraPaciente.RegistrarObraPaciente(obraPaciente);

        //        turno.Paciente = paciente;
        //        turno.Paciente.IdPaciente = idPaciente;

        //        DATurno Daturno = new DATurno();
        //        Daturno.DaRegistraTurno(turno);

        //        return mensaje;
        //    } catch (Exception e)
        //    {
        //        throw e;
        //    }

        //}


        public string RegistrarTurnoNew(Turno turno, Paciente paciente, string p_obraSocial, string p_planObra, bool es_edicion)
        {
            string mensaje = "OK";

            int idObraPaciente = 0;

            try
            {
                DAPaciente DaPaciente = new DAPaciente();
                paciente.IdPaciente = DaPaciente.DaRegistrarPaciente(paciente);

                if (paciente.IdPaciente > 0)
                {
                    ObrasPacientes obraPaciente = new ObrasPacientes();

                    obraPaciente.IdObraSocial = Convert.ToInt32(p_obraSocial);
                    obraPaciente.IdPaciente = paciente.IdPaciente;
                    obraPaciente.IdPlan = Convert.ToInt32(p_planObra);
                    obraPaciente.nroAfiliado = turno.NroAfiliado;
                    obraPaciente.UsuarioAlta = paciente.UsuarioAlta;
                    obraPaciente.FechaAlta = paciente.FechaAlta;

                    DAObraPaciente DaObraPaciente = new DAObraPaciente();
                    idObraPaciente = DaObraPaciente.RegistrarObraPaciente(obraPaciente);

                }
                
                if (idObraPaciente > 0 && paciente.IdPaciente > 0)
                {
                    turno.Paciente = paciente;
                    turno.Paciente.IdPaciente = paciente.IdPaciente;

                    DATurno Daturno = new DATurno();
                    Daturno.DaRegistraTurno(turno);

                }

                return mensaje;
            }
            catch (Exception e)
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

        public DataTable TraerTurnos(string idProfesional, DateTime dia)
        {
            try
            {
                DATurno Daturno = new DATurno();
                return Daturno.TraerTurnos(idProfesional, dia);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable TraerTurnosDelDia(string idCentro, string dia)
        {
            try
            {
                DATurno Daturno = new DATurno();
                return Daturno.TraerTurnosDelDia(idCentro, dia);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable TraeEstados()
        {
            try
            {
                DATurno Daturno = new DATurno();
                return Daturno.TraeEstados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarEstadoEnTurno(string idturno, string estado)
        {
            try
            {
                DATurno Daturno = new DATurno();
                Daturno.ModificarEstadoEnTurno(idturno, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TraerTurnosInformes(string idSucursal, string idObraSocial, string fechaDesde, string fechaHasta)
        {
            try
            {
                DATurno Daturno = new DATurno();
                return Daturno.TraerTurnosInformes(idSucursal, idObraSocial, fechaDesde, fechaHasta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarNroOrden(string idturno, string autorizacion)
        {
            try
            {
                DATurno Daturno = new DATurno();
                Daturno.ModificarNroOrden(idturno, autorizacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificarTurnoDisponible(Turno turno)
        {
            try
            {
                DATurno Daturno = new DATurno();
                return Daturno.VerificarTurnoDisponible(turno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidacionDelDiaTurno(Turno turno)
        {
            try
            {
                DATurno Daturno = new DATurno();
                return Daturno.ValidacionDelDiaTurno(turno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string RegistrarSoloTurno(Turno turno)
        {
           string mensaje = "OK";

            try
            {
                DATurno Daturno = new DATurno();
                Daturno.DaRegistraTurno(turno);

                return mensaje;
            }
            catch (Exception e)
            {
                throw e;
            }
        }




    }
}
