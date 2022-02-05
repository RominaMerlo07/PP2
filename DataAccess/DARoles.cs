using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DARoles
    {

        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;


        public List<Rol> obtenerRoles()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * " +
                                    "FROM T_ROLES " +
                                   "WHERE FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);
                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<Rol> listaRoles = new List<Rol>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Rol rol = new Rol();
                        if (dr["ID_ROL"] != DBNull.Value)
                            rol.IdRol = Convert.ToInt32(dr["ID_ROL"]);
                        if (dr["NOMBRE_ROL"] != DBNull.Value)
                            rol.NombreRol = Convert.ToString(dr["NOMBRE_ROL"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            rol.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            rol.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            rol.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            rol.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            rol.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            rol.FechaMod = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        listaRoles.Add(rol);

                    }

                    return listaRoles;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
