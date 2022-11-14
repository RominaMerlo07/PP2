using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;
using System.Data;

namespace BusinessLogicLayer.Gestores
{
    public class GestorProfesionales
    {
        public int RegistrarProfesional(Profesional profesional, List<string> p_especialidades)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                profesional.IdProfesional = DaProfesional.DaRegistrarProfesional(profesional);

                //tomar centros
                if (profesional.IdProfesional > 0) { 
                    DACentros centros = new DACentros();
                    List<Centro> listaCentros = centros.traerCentros();

                    foreach (Centro centro in listaCentros)
                    {

                        foreach (string id_especialidad in p_especialidades)
                        {
                            ProfesionalDetalle profDetalle = new ProfesionalDetalle();
                            profDetalle.Profesional = profesional;
                            profDetalle.Centro = centro;
                            Especialidad especialidad = new Especialidad();
                            especialidad.IdEspecialidad = Convert.ToInt32(id_especialidad);
                            profDetalle.Especialidad = especialidad;
                            profDetalle.UsuarioAlta = profesional.UsuarioAlta;
                            profDetalle.FechaAlta = DateTime.Now;

                            DAProfesionalDetalle DaProfDetalle = new DAProfesionalDetalle();
                            int IdProfDetalle = DaProfDetalle.DaRegistrarProfesionalDetalle(profDetalle);
                        
                        }
                    }                    
                }
                return profesional.IdProfesional;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Profesional> obtenerProfesionales()
        {
            try
            {
                DAProfesional daProf = new DAProfesional();
                List<Profesional> list = daProf.traerProfesionales();

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Profesional obtenerProfesional(int idProfesional)
        {
            try
            { 
                DAProfesional daProf = new DAProfesional();
                return daProf.obtenerProfesional(idProfesional);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ProfesionalDetalle> obtenerDetalleProfesionalPorCentro(string idCentro, string idProfesional)
        {
            try
            {
                DAProfesionalDetalle daProfDetalle = new DAProfesionalDetalle();
                List<ProfesionalDetalle> list = daProfDetalle.traerDetallesPorCentro(idCentro, idProfesional);
                foreach (ProfesionalDetalle detalle in list)
                {
                    DACentros daCentros = new DACentros();
                    DAEspecialidades daEspecialidades = new DAEspecialidades();


                    detalle.Centro = daCentros.obtenerCentro(detalle.Centro.IdCentro);
                    detalle.Especialidad = daEspecialidades.obtenerEspecialidad(detalle.Especialidad.IdEspecialidad);
                    detalle.Profesional = obtenerProfesional(detalle.Profesional.IdProfesional);
                }


                if (list.Count > 0)
                {
                    return list;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string ActualizarProfesional(Profesional profesional)
        {
            try
            { 
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.ActualizarProfesional(profesional);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DarBajaProfesional(Profesional profesional)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.DarBajaProfesional(profesional);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable obtenerProfesionalesDisponibles(string idCentro, string idEspecialidad)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.obtenerProfesionalesDisponibles(idCentro, idEspecialidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable TraerDisponibilidadHoraria(string idProfesional, string idEspecialidad, string idCentro, string dia = null)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.TraerDisponibilidadHoraria(idProfesional, idEspecialidad, idCentro, dia);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable especialidadPorProfesional(string idProfesional)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.especialidadPorProfesional(idProfesional);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int RegistrarEspeProfesional(Profesional profesional, List<string> p_especialidadesP)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                //tomar centros
                if (profesional.IdProfesional > 0)
                {
                    
                        DACentros centros = new DACentros();
                        List<Centro> listaCentros = centros.traerCentros();

                        foreach (Centro centro in listaCentros)
                        {

                            foreach (string id_especialidad in p_especialidadesP)
                            {
                                ProfesionalDetalle profDetalle = new ProfesionalDetalle();
                                profDetalle.Profesional = profesional;
                                profDetalle.Centro = centro;
                                Especialidad especialidad = new Especialidad();
                                especialidad.IdEspecialidad = Convert.ToInt32(id_especialidad);
                                profDetalle.Especialidad = especialidad;
                                profDetalle.UsuarioAlta = profesional.UsuarioAlta;
                                profDetalle.FechaAlta = DateTime.Now;

                                DAProfesionalDetalle DaProfDetalle = new DAProfesionalDetalle();
                                int IdProfDetalle = DaProfDetalle.DaRegistrarProfesionalDetalle(profDetalle);

                            }
                        }                                        
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string DarBajaProfesionalE(string idProfesional, string idEspecialidad, int usuarioBaja, DateTime fechaBaja)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.DarBajaProfesionalE(idProfesional, idEspecialidad, usuarioBaja, fechaBaja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int validarDniProfesional(string dni)
        {

            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.validarDniProfesional(dni);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int validarMatricula(string matricula)
        {

            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.validarMatricula(matricula);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public int TurnosFuturos(int idProfesional)
        {
            try
            {
                DAProfesional dAProfesional = new DAProfesional();
                return dAProfesional.TurnosFuturos(idProfesional);

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable ObtenerTurnosFuturos(int idProf)
        {
            try
            {
                DAProfesional dAProfesional = new DAProfesional();
                return dAProfesional.ObtenerTurnosFuturos(idProf);

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string DaDarDeBajaProfDetalle(int idProf, int usuarioBaja)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.DaDarDeBajaProfDetalle(idProf, usuarioBaja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string DaDarDeBajaProfUsuario(int idProf, int usuarioBaja)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.DaDarDeBajaProfUsuario(idProf, usuarioBaja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string DaDarDeBajaTurnos(int idProf, int usuarioBaja)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.DaDarDeBajaTurnos(idProf, usuarioBaja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
