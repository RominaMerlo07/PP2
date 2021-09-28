using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DAUsuarios
    {

        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public bool accederUsuario(string NombreUsuario, string passwordUsuario)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_USUARIOS " +
                                   "WHERE NOMBRE_USUARIO = @USUARIO " +
                                   "AND CLAVE_USUARIO = @PASSWORD " +
                                   "AND FECHA_BAJA IS NULL; ";

                cmd = new SqlCommand(consulta, con);

                if (NombreUsuario != "" && passwordUsuario != "")
                {
                    cmd.Parameters.AddWithValue("@USUARIO", NombreUsuario);
                    cmd.Parameters.AddWithValue("@PASSWORD", passwordUsuario);
                }

                else
                {
                    cmd.Parameters.AddWithValue("@USUARIO", DBNull.Value);
                    cmd.Parameters.AddWithValue("@PASSWORD", DBNull.Value);
                }

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                Usuario usuario = new Usuario();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID_USUARIO"] != DBNull.Value)
                            usuario.IdUsuario = Convert.ToInt32(dr["ID_USUARIO"]);
                        if (dr["NOMBRE_USUARIO"] != DBNull.Value)
                            usuario.NombreUsuario = Convert.ToString(dr["NOMBRE_USUARIO"]);
                        if (dr["CLAVE_USUARIO"] != DBNull.Value)
                            usuario.ClaveUsuario = Convert.ToString(dr["CLAVE_USUARIO"]);                        
                    }

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
