using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;
using System.Data;

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


        public DataTable buscarPersonal(string idPersonal)
        {
            try
            {

                DAUsuarios DAUsuarios = new DAUsuarios();
                return DAUsuarios.buscarPersonal(idPersonal);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string generarUsuario(string nombre, string apellido)
        {

            try
            {

                DAUsuarios DAUsuarios = new DAUsuarios();
                return DAUsuarios.generarUsuario(nombre, apellido);
            }
            catch (Exception e)
            {
                throw e;
            }

        }


        public int DaRegistrarUsuario(Usuario usuario, int IdRol, int idPersonal, int IdProfesional)
        {
            try
            {
                DAUsuarios DAUsuarios = new DAUsuarios();
                return DAUsuarios.DaRegistrarUsuario(usuario, IdRol, idPersonal, IdProfesional);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable cargarUsuarios()
        {
            try
            {
                DAUsuarios daUsuarios = new DAUsuarios();
                return daUsuarios.cargarUsuarios();
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}
