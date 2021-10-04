using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.ent;
using DataAccess;

namespace BusinessLogicLayer.Gestores
{
    public class GestorUsuarios
    {

        public Usuario accederUsuario(string NombreUsuario, string passwordUsuario)
        {
            try
            {
                DAUsuarios daUsuarios = new DAUsuarios();
                return daUsuarios.accederUsuario(NombreUsuario, passwordUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
