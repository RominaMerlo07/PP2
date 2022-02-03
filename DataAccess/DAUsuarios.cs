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

        public Usuario accederUsuario(string NombreUsuario, string passwordUsuario)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT * FROM T_USUARIOS U, T_ROLES R
                                    WHERE U.ID_ROL = R.ID_ROL
                                   AND U.NOMBRE_USUARIO = @USUARIO 
                                   AND U.CLAVE_USUARIO = @PASSWORD 
                                   AND U.FECHA_BAJA IS NULL; ";

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

                        Rol rol = new Rol();

                        if (dr["ID_ROL"] != DBNull.Value)
                            rol.IdRol = Convert.ToInt32(dr["ID_ROL"]);
                        if (dr["NOMBRE_ROL"] != DBNull.Value)
                            rol.NombreRol = Convert.ToString(dr["NOMBRE_ROL"]);

                        usuario.Rol = rol;
                    }

                    return usuario;
                }
                else
                {
                    return usuario;
                }

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
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                //e.*, pd.*, dh.*
                string consulta = @"SELECT p.ID_PERSONAL idPersonal, p.NOMBRE nombre, p.APELLIDO apellido, 'PERSONAL' cargo
                                      FROM T_PERSONAL p
                                     WHERE p.DOCUMENTO = @DNI_PERSONAL
                                       AND p.FECHA_BAJA is null
                                       AND p.ID_PERSONAL NOT IN (SELECT ID_PROFESIONAL 
							                                       FROM T_USUARIOS
							                                      WHERE ID_PERSONAL = p.ID_PERSONAL)
                                    UNION
                                    SELECT p.ID_PROFESIONAL idPersonal, p.NOMBRE nombre, p.APELLIDO apellido, 'PROFESIONAL' cargo
                                      FROM T_PROFESIONALES p
                                     WHERE p.DOCUMENTO = @DNI_PERSONAL
                                       AND p.FECHA_BAJA is null
                                       AND p.ID_PROFESIONAL NOT IN (SELECT ID_PROFESIONAL 
							                                          FROM T_USUARIOS
                                                                     WHERE ID_PROFESIONAL = p.ID_PROFESIONAL); ";

                cmd = new SqlCommand(consulta, con);

                if (!String.IsNullOrEmpty(idPersonal))
                    cmd.Parameters.AddWithValue("@DNI_PERSONAL", idPersonal);
                else
                    cmd.Parameters.AddWithValue("@DNI_PERSONAL", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else {

                    return null;
                }
               
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public string generarUsuario(string nombre, string apellido)
        {

            string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
            con = new SqlConnection(cadenaDeConexion);
            con.Open();


            string[] extraccionN = nombre.Split(' ');
            string name = extraccionN[0];
            name = name.ToUpper();

            string[] extraccionA = apellido.Split(' ');
            string lastname = extraccionA[0];
            lastname = lastname.ToUpper();


            string letra_nombre = name.Substring(0, 1); //saco la letra del nomnbre
            string usuario = string.Concat(letra_nombre, lastname);//concateno, pero me queda un espacio
            usuario = usuario.Replace(" ", string.Empty);//saco el espacio de la concatenación Y LISTO!! =)

            

            string consulta = "SELECT COUNT (NOMBRE_USUARIO) as 'CANTIDAD' " +
                                "FROM T_USUARIOS " +
                               "WHERE NOMBRE_USUARIO LIKE '%" + usuario + "%';";

            cmd = new SqlCommand(consulta, con);
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                int contador = Convert.ToInt32(dr["CANTIDAD"]);

                int acumulador = contador;
                if (contador != 0)
                {
                    usuario = usuario + acumulador;
                }

            }
            dr.Close();

            return usuario;

        }


        public int DaRegistrarUsuario(Usuario usuario, int IdRol, int idPersonal, int IdProfesional)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();


                string consulta = "INSERT INTO T_USUARIOS " +
                                                         "(NOMBRE_USUARIO, " +
                                                         "CLAVE_USUARIO, " +
                                                         "ID_ROL, " +
                                                         "USUARIO_ALTA, " +
                                                         "FECHA_ALTA, " +
                                                         "ID_PERSONAL, " +
                                                         "ID_PROFESIONAL) "+
                                                 " VALUES ( " +
                                                         "@NOMBRE_USUARIO, " +
                                                         "@CLAVE_USUARIO, " +
                                                         "@ID_ROL, " +
                                                         "@USUARIO_ALTA, " +
                                                         "@FECHA_ALTA, " +
                                                         "@ID_PERSONAL, " +
                                                         "@ID_PROFESIONAL); SELECT SCOPE_IDENTITY()";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(usuario.NombreUsuario))
                    cmd.Parameters.AddWithValue("@NOMBRE_USUARIO", usuario.NombreUsuario);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE_USUARIO", DBNull.Value);

                if (!string.IsNullOrEmpty(usuario.ClaveUsuario))
                    cmd.Parameters.AddWithValue("@CLAVE_USUARIO", usuario.ClaveUsuario);
                else
                    cmd.Parameters.AddWithValue("@CLAVE_USUARIO", DBNull.Value);

                //if (!string.IsNullOrEmpty(Convert.ToString(usuario.Rol.IdRol)))
                //    cmd.Parameters.AddWithValue("@ID_ROL", usuario.Rol.IdRol);
                //else
                //    cmd.Parameters.AddWithValue("@ID_ROL", DBNull.Value);

                //if (!string.IsNullOrEmpty(Convert.ToString(usuario.Personal.IdPersonal)))
                //    cmd.Parameters.AddWithValue("@ID_PERSONAL", usuario.Personal.IdPersonal);
                //else
                //    cmd.Parameters.AddWithValue("@ID_PERSONAL", DBNull.Value);

                //if (!string.IsNullOrEmpty(Convert.ToString(usuario.Profesional.IdProfesional)))
                //    cmd.Parameters.AddWithValue("@ID_PROFESIONAL", usuario.Profesional.IdProfesional);
                //else
                //    cmd.Parameters.AddWithValue("@ID_PROFESIONAL", DBNull.Value);

                cmd.Parameters.AddWithValue("@ID_ROL", IdRol);
                cmd.Parameters.AddWithValue("@ID_PERSONAL", idPersonal);
                cmd.Parameters.AddWithValue("@ID_PROFESIONAL", IdProfesional);
                cmd.Parameters.AddWithValue("@USUARIO_ALTA", usuario.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", usuario.FechaAlta);

                //cmd.ExecuteNonQuery();
                int devolver = Convert.ToInt32(cmd.ExecuteScalar());
                trans.Commit();

                con.Close();

                return devolver;
            }
            catch (Exception e)
            {
                trans.Rollback();
                con.Close();
                throw e;
            }
        }


        public DataTable cargarUsuarios()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT ID_USUARIO, P.DOCUMENTO Documento, P.NOMBRE, P.APELLIDO, NOMBRE_USUARIO,  R.NOMBRE_ROL Rol
									  FROM T_USUARIOS u, T_PROFESIONALES p, T_ROLES r
									 WHERE u.ID_PROFESIONAL = p.ID_PROFESIONAL
									   AND u.ID_ROL = r.ID_ROL
									   AND u.FECHA_BAJA IS NULL
									   AND p.FECHA_BAJA IS NULL
								   UNION
									SELECT ID_USUARIO, P.DOCUMENTO Documento, P.NOMBRE, P.APELLIDO, NOMBRE_USUARIO,  R.NOMBRE_ROL Rol
									  FROM T_USUARIOS u, T_PERSONAL p, T_ROLES r
									 WHERE u.ID_PERSONAL = p.ID_PERSONAL
									   AND u.ID_ROL = r.ID_ROL
									   AND u.FECHA_BAJA IS NULL
									   AND p.FECHA_BAJA IS NULL
								  ORDER BY NOMBRE_USUARIO; ";


                cmd = new SqlCommand(consulta, con);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }


    
}
