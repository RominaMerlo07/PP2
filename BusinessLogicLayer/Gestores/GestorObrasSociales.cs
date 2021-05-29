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
    public class GestorObrasSociales
    {
        public List<ObraSocial> obtenerObrasSociales(string id_Centro)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                List<ObraSocial> list = daObrasSociales.traerObrasSociales(id_Centro);

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
    }
}
