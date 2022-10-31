using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.ent;
using DataAccess;

namespace BusinessLogicLayer.Gestores
{
    public class GestorEspecialidades
    {
        DAEspecialidades daEspecialidades = new DAEspecialidades();

        public List<Especialidad> obtenerEspecialidades()
        {
            try
            {
                List<Especialidad> list = daEspecialidades.traerEspecialidades();

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

        public DataTable obtenerEspecialidadDisponible(string idCentro)
        {
            try
            {
                return daEspecialidades.obtenerEspecialidadDisponible(idCentro);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string RegistrarEspecialidades(Especialidad especialidad)
        {
            try
            {
                DAEspecialidades DaEspecialidades = new DAEspecialidades();
                return DaEspecialidades.DaRegistrarEspecialidades(especialidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Especialidad> traerEspecialidadesNotInProfesional(string idProfesional)
        {
            try
            {
                List<Especialidad> list = daEspecialidades.traerEspecialidadesNotInProfesional(idProfesional);

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

        public Especialidad obtenerEspecialidad(int idEspecialidad)
        {
            try
            {
                DAEspecialidades DaEspecialidades = new DAEspecialidades();
                return DaEspecialidades.obtenerEspecialidad(idEspecialidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string editarEspecialidad(Especialidad especialidad)
        {
            try
            {
                DAEspecialidades DaEspecialidades = new DAEspecialidades();
                return DaEspecialidades.editarEspecialidad(especialidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int TurnosFuturos(int idEspecialidad)
        {
            try
            {
                DAEspecialidades daEspecialidades = new DAEspecialidades();
                return daEspecialidades.TurnosFuturos(idEspecialidad);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable ObtenerTurnosFuturos(int idEspecialidad)
        {
            try
            {
                DAEspecialidades daEspecialidades = new DAEspecialidades();
                return daEspecialidades.ObtenerTurnosFuturos(idEspecialidad);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DaDarDeBajaTurnos(int idEspecialidad, int usuarioBaja)
        {
            try
            {
                DAEspecialidades daEspecialidades = new DAEspecialidades();
                return daEspecialidades.DaDarDeBajaTurnos(idEspecialidad, usuarioBaja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DaDarDeBajaEspecialidad(Especialidad especialidad)
        {
            try

            {

                DAEspecialidades daEspecialidades = new DAEspecialidades();
                return daEspecialidades.DaDarDeBajaEspecialidad(especialidad);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string darBajaEspecialidad(Especialidad especialidad)
        {
            try

            {

                DAEspecialidades daEspecialidades = new DAEspecialidades();
                return daEspecialidades.darBajaEspecialidad(especialidad);

            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
