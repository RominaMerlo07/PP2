using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;
namespace DataAccess
{
    public class DAPersonal
    {

        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public int DaRegistrarPersonal(Personal personal)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();


                string consulta = "INSERT INTO T_PERSONAL " +
                                                         "(NOMBRE, " +
                                                         "APELLIDO, " +
                                                         "DOCUMENTO, " +
                                                         "NRO_CONTACTO, " +
                                                         "EMAIL_CONTACTO, " +
                                                         "FECHA_NACIMIENTO, " +
                                                         "DOMICILIO, " +
                                                         "LOCALIDAD, " +
                                                         "USUARIO_ALTA, " +
                                                         "FECHA_ALTA) " +
                                                    " VALUES ( " +
                                                        "@NOMBRE, " +
                                                        "@APELLIDO, " +
                                                        "@DOCUMENTO, " +
                                                        "@NRO_CONTACTO, " +
                                                        "@EMAIL_CONTACTO, " +
                                                        "@FECHA_NACIMIENTO, " +
                                                        "@DOMICILIO, " +
                                                        "@LOCALIDAD, " +
                                                        "@USUARIO_ALTA, " +
                                                        "@FECHA_ALTA ); SELECT SCOPE_IDENTITY()";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(personal.Nombre))
                    cmd.Parameters.AddWithValue("@NOMBRE", personal.Nombre);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.Apellido))
                    cmd.Parameters.AddWithValue("@APELLIDO", personal.Apellido);
                else
                    cmd.Parameters.AddWithValue("@APELLIDO", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.Documento))
                    cmd.Parameters.AddWithValue("@DOCUMENTO", personal.Documento);
                else
                    cmd.Parameters.AddWithValue("@DOCUMENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.NroContacto))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", personal.NroContacto);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.EmailContacto))
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", personal.EmailContacto);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(personal.FechaNacimiento)))
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", personal.FechaNacimiento);
                else
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.Domicilio))
                    cmd.Parameters.AddWithValue("@DOMICILIO", personal.Domicilio);
                else
                    cmd.Parameters.AddWithValue("@DOMICILIO", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.Localidad))
                    cmd.Parameters.AddWithValue("@LOCALIDAD", personal.Localidad);
                else
                    cmd.Parameters.AddWithValue("@LOCALIDAD", DBNull.Value);

                cmd.Parameters.AddWithValue("@USUARIO_ALTA", personal.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", personal.FechaAlta);

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


        public List<Personal> traerPersonal()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * " +
                                    "FROM T_PERSONAL " +
                                   "WHERE FECHA_BAJA IS NULL " +
                                   "ORDER BY ID_PERSONAL;";

                cmd = new SqlCommand(consulta, con);
                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<Personal> listaPersonal = new List<Personal>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Personal personal = new Personal();
                        if (dr["ID_PERSONAL"] != DBNull.Value)
                            personal.IdPersonal = Convert.ToInt32(dr["ID_PERSONAL"]);
                        if (dr["NOMBRE"] != DBNull.Value)
                            personal.Nombre = Convert.ToString(dr["NOMBRE"]);
                        if (dr["APELLIDO"] != DBNull.Value)
                            personal.Apellido = Convert.ToString(dr["APELLIDO"]);
                        if (dr["DOCUMENTO"] != DBNull.Value)
                            personal.Documento = Convert.ToString(dr["DOCUMENTO"]);
                        if (dr["NRO_CONTACTO"] != DBNull.Value)
                            personal.NroContacto = Convert.ToString(dr["NRO_CONTACTO"]);
                        if (dr["EMAIL_CONTACTO"] != DBNull.Value)
                            personal.EmailContacto = Convert.ToString(dr["EMAIL_CONTACTO"]);
                        if (dr["FECHA_NACIMIENTO"] != DBNull.Value)
                            personal.FechaNacimiento = Convert.ToDateTime(dr["FECHA_NACIMIENTO"]);
                        if (dr["DOMICILIO"] != DBNull.Value)
                            personal.Domicilio = Convert.ToString(dr["DOMICILIO"]);
                        if (dr["LOCALIDAD"] != DBNull.Value)
                            personal.Localidad = Convert.ToString(dr["LOCALIDAD"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            personal.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            personal.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            personal.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            personal.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            personal.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            personal.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        listaPersonal.Add(personal);
                    }

                    return listaPersonal;
                }
                else
                {
                    return listaPersonal;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Personal obtenerPersonal(int idPersonal)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * " +
                                    "FROM T_PERSONAL " +
                                   "WHERE ID_PERSONAL =  @ID_PERSONAL " +
                                     "AND FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);

                if (idPersonal != 0)
                    cmd.Parameters.AddWithValue("@ID_PERSONAL", idPersonal);
                else
                    cmd.Parameters.AddWithValue("@ID_PERSONAL", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                Personal personal = new Personal();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID_PERSONAL"] != DBNull.Value)
                            personal.IdPersonal = Convert.ToInt32(dr["ID_PERSONAL"]);
                        if (dr["NOMBRE"] != DBNull.Value)
                            personal.Nombre = Convert.ToString(dr["NOMBRE"]);
                        if (dr["APELLIDO"] != DBNull.Value)
                            personal.Apellido = Convert.ToString(dr["APELLIDO"]);
                        if (dr["DOCUMENTO"] != DBNull.Value)
                            personal.Documento = Convert.ToString(dr["DOCUMENTO"]);
                        if (dr["NRO_CONTACTO"] != DBNull.Value)
                            personal.NroContacto = Convert.ToString(dr["NRO_CONTACTO"]);
                        if (dr["EMAIL_CONTACTO"] != DBNull.Value)
                            personal.EmailContacto = Convert.ToString(dr["EMAIL_CONTACTO"]);
                        if (dr["FECHA_NACIMIENTO"] != DBNull.Value)
                            personal.FechaNacimiento = Convert.ToDateTime(dr["FECHA_NACIMIENTO"]);
                        if (dr["DOMICILIO"] != DBNull.Value)
                            personal.Domicilio = Convert.ToString(dr["DOMICILIO"]);
                        if (dr["LOCALIDAD"] != DBNull.Value)
                            personal.Localidad = Convert.ToString(dr["LOCALIDAD"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            personal.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            personal.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            personal.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            personal.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            personal.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            personal.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);
                    }

                    return personal;
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


        public string ActualizarPersonal(Personal personal)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_PERSONAL " +
                                     "SET NOMBRE = @NOMBRE, " +
                                         "APELLIDO = @APELLIDO, " +
                                         "DOCUMENTO = @DOCUMENTO, " +
                                         "NRO_CONTACTO = @NRO_CONTACTO, " +
                                         "EMAIL_CONTACTO = @EMAIL_CONTACTO, " +
                                         "FECHA_NACIMIENTO = @FECHA_NACIMIENTO, " +
                                         "DOMICILIO = @DOMICILIO, " +
                                         "LOCALIDAD = @LOCALIDAD, " +
                                         "USUARIO_MOD = @USUARIO_MOD, " +
                                         "FECHA_MOD = @FECHA_MOD " +
                                   "WHERE ID_PERSONAL = @ID_PERSONAL; SELECT SCOPE_IDENTITY();";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(personal.Nombre))
                    cmd.Parameters.AddWithValue("@NOMBRE", personal.Nombre);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.Apellido))
                    cmd.Parameters.AddWithValue("@APELLIDO", personal.Apellido);
                else
                    cmd.Parameters.AddWithValue("@APELLIDO", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.Documento))
                    cmd.Parameters.AddWithValue("@DOCUMENTO", personal.Documento);
                else
                    cmd.Parameters.AddWithValue("@DOCUMENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.NroContacto))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", personal.NroContacto);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.EmailContacto))
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", personal.EmailContacto);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(personal.FechaNacimiento)))
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", personal.FechaNacimiento);
                else
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.Domicilio))
                    cmd.Parameters.AddWithValue("@DOMICILIO", personal.Domicilio);
                else
                    cmd.Parameters.AddWithValue("@DOMICILIO", DBNull.Value);

                if (!string.IsNullOrEmpty(personal.Localidad))
                    cmd.Parameters.AddWithValue("@LOCALIDAD", personal.Localidad);
                else
                    cmd.Parameters.AddWithValue("@LOCALIDAD", DBNull.Value);



                cmd.Parameters.AddWithValue("@ID_PERSONAL", personal.IdPersonal);
                cmd.Parameters.AddWithValue("@USUARIO_MOD", personal.UsuarioMod);
                cmd.Parameters.AddWithValue("@FECHA_MOD", personal.FechaMod);

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


        public string DarBajaPersonal(Personal personal)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_PERSONAL " +
                                     "SET USUARIO_BAJA = @USUARIO_BAJA, " +
                                         "FECHA_BAJA = @FECHA_BAJA " +
                                   "WHERE ID_PERSONAL = @ID_PERSONAL;";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_PERSONAL", personal.IdPersonal);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", personal.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", personal.FechaBaja);

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


        public int validarDniPersonal(string dni)
        {
            int devolver = 0;

            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "SELECT count(*) " +
                                    "FROM T_PERSONAL p " +
                                    "WHERE p.DOCUMENTO = @DNI " +
                                    "AND p.FECHA_BAJA is null; ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@DNI", dni);

                devolver = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

            }
            catch (Exception e)
            {

                con.Close();
                throw e;

            }

            return devolver;

        }


    }
}
