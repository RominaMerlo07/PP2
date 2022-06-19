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
                string consulta = @"SELECT p.ID_PERSONAL idPersonal, p.NOMBRE nombre, p.APELLIDO apellido, 'PERSONAL' cargo, p.EMAIL_CONTACTO
                                      FROM T_PERSONAL p
                                     WHERE p.DOCUMENTO = @DNI_PERSONAL
                                       AND p.FECHA_BAJA is null
                                       AND p.ID_PERSONAL NOT IN (SELECT ID_PROFESIONAL 
							                                       FROM T_USUARIOS
							                                      WHERE ID_PERSONAL = p.ID_PERSONAL)
                                    UNION
                                    SELECT p.ID_PROFESIONAL idPersonal, p.NOMBRE nombre, p.APELLIDO apellido, 'PROFESIONAL' cargo, p.EMAIL_CONTACTO
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


        public DataTable buscarUsuarios(int idUsuario)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT u.NOMBRE_USUARIO, u.CLAVE_USUARIO, u.ID_ROL, r.NOMBRE_ROL
									  FROM T_USUARIOS u, T_ROLES r
									 WHERE u.ID_ROL = r.ID_ROL
                                       AND u.ID_USUARIO = @idUsuario
									   AND u.FECHA_BAJA is null
									   AND r.FECHA_BAJA is null;";


                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

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


        public string actualizarUsuario(Usuario usuario, int rol)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_USUARIOS " +
                                     "SET NOMBRE_USUARIO = @NOMBRE_USUARIO, " +
                                          "CLAVE_USUARIO = @CLAVE_USUARIO, " +
                                          "ID_ROL = @ID_ROL, " +
                                          "USUARIO_MOD = @USUARIO_MOD, " +
                                          "FECHA_MOD = @FECHA_MOD " +
                                   "WHERE ID_USUARIO = @ID_USUARIO; SELECT SCOPE_IDENTITY();";


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

                cmd.Parameters.AddWithValue("@ID_ROL", rol);
                cmd.Parameters.AddWithValue("@ID_USUARIO", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@USUARIO_MOD", usuario.UsuarioMod);
                cmd.Parameters.AddWithValue("@FECHA_MOD", usuario.FechaMod);

                cmd.ExecuteNonQuery();
                //int devolver = Convert.ToInt32(cmd.ExecuteScalar());
                trans.Commit();
                con.Close();

                result = "OK";

            }
            catch (Exception e)
            {
                result = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;
            }

            return result;

        }


        public string darBajaUsuario(Usuario usuario)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_USUARIOS " +
                                     "SET USUARIO_BAJA = @USUARIO_BAJA, " +
                                          "FECHA_BAJA = @FECHA_BAJA " +
                                   "WHERE ID_USUARIO = @ID_USUARIO;";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_USUARIO", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", usuario.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", usuario.FechaBaja);

                cmd.ExecuteNonQuery();
                //int devolver = Convert.ToInt32(cmd.ExecuteScalar());
                trans.Commit();
                con.Close();

                result = "OK";

            }
            catch (Exception e)
            {
                result = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;
            }

            return result;

        }

        public DataTable validarEmail(string email)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT p.EMAIL_CONTACTO, u.NOMBRE_USUARIO, p.ID_PERSONAL, null ID_PROFESIONAL
									  FROM T_USUARIOS u, T_PERSONAL p, T_ROLES r
									 WHERE u.ID_PERSONAL = p.ID_PERSONAL
									   AND u.ID_ROL = r.ID_ROL
									   AND u.FECHA_BAJA IS NULL
									   AND p.FECHA_BAJA IS NULL
									   AND r.FECHA_BAJA IS NULL 
									   AND p.EMAIL_CONTACTO = @email
									UNION
									SELECT p.EMAIL_CONTACTO, u.NOMBRE_USUARIO, null , p.ID_PROFESIONAL
									  FROM T_USUARIOS u, T_PROFESIONALES p, T_ROLES r
									 WHERE u.ID_PROFESIONAL = p.ID_PROFESIONAL
									   AND u.ID_ROL = r.ID_ROL
									   AND u.FECHA_BAJA IS NULL
									   AND p.FECHA_BAJA IS NULL
									   AND r.FECHA_BAJA IS NULL 
									   AND p.EMAIL_CONTACTO = @email;";


                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@email", email);

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

        public int registrarResetPass(ResetPass resetPass, int idPersonal, int idProfesional)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();


                string consulta = "INSERT INTO T_RESETPASS " +
                                                         "(NOMBRE_USUARIO, " +
                                                         "CLAVE_USUARIO, " +
                                                         "EMAIL_CONTACTO, " +
                                                         "ID_PERSONAL, " +
                                                         "ID_PROFESIONAL, " +
                                                         "USUARIO_ALTA, " +
                                                         "FECHA_ALTA) " +
                                                    " VALUES ( " +
                                                        "@NOMBRE_USUARIO, " +
                                                        "@CLAVE_USUARIO, " +
                                                        "@EMAIL_CONTACTO, " +
                                                        "@ID_PERSONAL, " +
                                                        "@ID_PROFESIONAL, " +
                                                        "@USUARIO_ALTA, " +
                                                        "@FECHA_ALTA ); SELECT SCOPE_IDENTITY()";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(resetPass.NombreUsuario))
                    cmd.Parameters.AddWithValue("@NOMBRE_USUARIO", resetPass.NombreUsuario);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE_USUARIO", DBNull.Value);

                if (!string.IsNullOrEmpty(resetPass.ClaveUsuario))
                    cmd.Parameters.AddWithValue("@CLAVE_USUARIO", resetPass.ClaveUsuario);
                else
                    cmd.Parameters.AddWithValue("@CLAVE_USUARIO", DBNull.Value);

                if (!string.IsNullOrEmpty(resetPass.EmailContacto))
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", resetPass.EmailContacto);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", DBNull.Value);

                cmd.Parameters.AddWithValue("@USUARIO_ALTA", resetPass.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", resetPass.FechaAlta);
                cmd.Parameters.AddWithValue("@ID_PERSONAL", idPersonal);
                cmd.Parameters.AddWithValue("@ID_PROFESIONAL", idProfesional);


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

        public DataTable validarResetPass(string emailContacto, string nombreUsuario)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT r.ID_RESETPASS, r.EMAIL_CONTACTO
                                      FROM T_RESETPASS r, 
                                           T_USUARIOS u, 
                                           T_PERSONAL p
									 WHERE r.NOMBRE_USUARIO = u.NOMBRE_USUARIO
									   AND r.ID_PERSONAL = p.ID_PERSONAL
									   AND u.ID_PERSONAL = p.ID_PERSONAL
									   AND r.NOMBRE_USUARIO = @nombreUsuario
									   AND r.EMAIL_CONTACTO = @email
									   AND r.FECHA_BAJA IS NULL
									   AND u.FECHA_BAJA IS NULL
									   AND p.FECHA_BAJA IS NULL
									UNION
									SELECT r.ID_RESETPASS, r.EMAIL_CONTACTO
                                      FROM T_RESETPASS r, 
                                           T_USUARIOS u, 
                                           T_PROFESIONALES p
									 WHERE r.NOMBRE_USUARIO = u.NOMBRE_USUARIO
									   AND r.ID_PERSONAL = p.ID_PROFESIONAL
									   AND u.ID_PERSONAL = p.ID_PROFESIONAL
									   AND r.NOMBRE_USUARIO = @nombreUsuario
									   AND r.EMAIL_CONTACTO = @email
									   AND r.FECHA_BAJA IS NULL
									   AND u.FECHA_BAJA IS NULL
									   AND p.FECHA_BAJA IS NULL;";


                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@email", emailContacto);
                cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

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


        public string bajaResetClave(ResetPass resetPass)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_RESETPASS " +
                                     "SET FECHA_BAJA = @FECHA_BAJA, " +
                                          "USUARIO_BAJA = @USUARIO_BAJA " +
                                   "WHERE ID_RESETPASS = @ID_RESETPASS; SELECT SCOPE_IDENTITY();";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;


                cmd.Parameters.AddWithValue("@ID_RESETPASS", resetPass.IdResetPass);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", resetPass.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", resetPass.FechaBaja);

                cmd.ExecuteNonQuery();
                //int devolver = Convert.ToInt32(cmd.ExecuteScalar());
                trans.Commit();
                con.Close();

                result = "OK";

            }
            catch (Exception e)
            {
                result = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;
            }

            return result;

        }

        public DataTable validaClaveProvisoria(string usuario, string password)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT r.ID_RESETPASS, 
                                           r.NOMBRE_USUARIO, 
                                           r.CLAVE_USUARIO,
	                                       p.EMAIL_CONTACTO,
	                                       p.ID_PERSONAL id_personal,
	                                       null id_profesional
                                      FROM T_RESETPASS r, 
                                           T_USUARIOS u, 
                                           T_PERSONAL p
									 WHERE r.NOMBRE_USUARIO = u.NOMBRE_USUARIO
									   AND r.ID_PERSONAL = p.ID_PERSONAL
									   AND u.ID_PERSONAL = p.ID_PERSONAL
									   AND r.NOMBRE_USUARIO = @usuario
									   AND r.CLAVE_USUARIO = @password
									   AND r.FECHA_BAJA IS NULL
									   AND u.FECHA_BAJA IS NULL
									   AND p.FECHA_BAJA IS NULL
									UNION
									SELECT r.ID_RESETPASS, 
                                           r.NOMBRE_USUARIO, 
                                           r.CLAVE_USUARIO,
	                                       p.EMAIL_CONTACTO,
	                                       null id_personal,
	                                       p.ID_PROFESIONAL id_profesional
                                      FROM T_RESETPASS r, 
                                           T_USUARIOS u, 
                                           T_PROFESIONALES p
									 WHERE r.NOMBRE_USUARIO = u.NOMBRE_USUARIO
									   AND r.ID_PERSONAL = p.ID_PROFESIONAL
									   AND u.ID_PERSONAL = p.ID_PROFESIONAL
									   AND r.NOMBRE_USUARIO = @usuario
									   AND r.CLAVE_USUARIO = @password
									   AND r.FECHA_BAJA IS NULL
									   AND u.FECHA_BAJA IS NULL
									   AND p.FECHA_BAJA IS NULL;";


                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@usuario", usuario);

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

        public string actualizarClaveUser(Usuario usuario)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_USUARIOS " +
                                     "SET CLAVE_USUARIO = @CLAVE_USUARIO, " +
                                         "USUARIO_MOD = @USUARIO_MOD, " +
                                         "FECHA_MOD = @FECHA_MOD " +
                                   "WHERE NOMBRE_USUARIO = @NOMBRE_USUARIO; SELECT SCOPE_IDENTITY();";


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

                cmd.Parameters.AddWithValue("@ID_USUARIO", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@USUARIO_MOD", usuario.UsuarioMod);
                cmd.Parameters.AddWithValue("@FECHA_MOD", usuario.FechaMod);

                cmd.ExecuteNonQuery();
                //int devolver = Convert.ToInt32(cmd.ExecuteScalar());
                trans.Commit();
                con.Close();

                result = "OK";

            }
            catch (Exception e)
            {
                result = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;
            }

            return result;

        }

    }



}
