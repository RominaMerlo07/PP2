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
    }
}
