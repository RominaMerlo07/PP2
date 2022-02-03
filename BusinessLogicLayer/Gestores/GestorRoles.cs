using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;
using System.Data;

namespace BusinessLogicLayer.Gestores
{
    public class GestorRoles
    {
        public List<Rol> obtenerRoles()
        {
            try
            {
                DARoles daRoles = new DARoles();
                List<Rol> list = daRoles.obtenerRoles();

                if (list.Count > 0)
                {
                    return list;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
