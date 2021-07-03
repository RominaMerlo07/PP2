using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;

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
        

    }
}
