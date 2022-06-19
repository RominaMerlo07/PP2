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


        public DataTable buscarUsuarios(int idUsuario)
        {
            try
            {
                DAUsuarios DAUsuarios = new DAUsuarios();
                return DAUsuarios.buscarUsuarios(idUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string actualizarUsuario(Usuario usuario, int rol)
        {
            try
            {
                DAUsuarios DAUsuario = new DAUsuarios();
                return DAUsuario.actualizarUsuario(usuario, rol);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string darBajaUsuario(Usuario usuario)
        {
            try
            {
                DAUsuarios DAUsuarios = new DAUsuarios();
                return DAUsuarios.darBajaUsuario(usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable validarEmail(string email)
        {
            try
            {
                DAUsuarios DAUsuarios = new DAUsuarios();
                return DAUsuarios.validarEmail(email);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int registrarResetPass(ResetPass resetPass, int idPersonal, int idProfesional)
        {
            try
            {
                DAUsuarios DaUsuarios = new DAUsuarios();
                return DaUsuarios.registrarResetPass(resetPass, idPersonal, idProfesional);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable validarResetPass(string emailContacto, string nombreUsuario)
        {
            try
            {
                DAUsuarios DAUsuarios = new DAUsuarios();
                return DAUsuarios.validarResetPass(emailContacto, nombreUsuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string bajaResetClave(ResetPass resetPass)
        {
            try
            {
                DAUsuarios DAUsuario = new DAUsuarios();
                return DAUsuario.bajaResetClave(resetPass);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable validaClaveProvisoria(string usuario, string password)
        {
            try
            {
                DAUsuarios DAUsuarios = new DAUsuarios();
                return DAUsuarios.validaClaveProvisoria(usuario, password);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string actualizarClaveUser(Usuario usuario)
        {
            try
            {
                DAUsuarios DAUsuario = new DAUsuarios();
                return DAUsuario.actualizarClaveUser(usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
