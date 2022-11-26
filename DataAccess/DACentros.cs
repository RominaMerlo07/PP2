using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DACentros
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public List<Centro> traerCentros()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_CENTROS " +
                                    "WHERE FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);
                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<Centro> listaCentros = new List<Centro>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Centro centro = new Centro();
                        if (dr["ID_CENTRO"] != DBNull.Value)
                            centro.IdCentro = Convert.ToInt32(dr["ID_CENTRO"]);
                        if (dr["NOMBRE_CENTRO"] != DBNull.Value)
                            centro.NombreCentro = Convert.ToString(dr["NOMBRE_CENTRO"]);
                        if (dr["DOMICILIO_CENTRO"] != DBNull.Value)
                            centro.DomicilioCentro = Convert.ToString(dr["DOMICILIO_CENTRO"]);
                        if (dr["LOCALIDAD_CENTRO"] != DBNull.Value)
                            centro.LocalidadCentro = Convert.ToString(dr["LOCALIDAD_CENTRO"]);
                        if (dr["EMAIL_CENTRO"] != DBNull.Value)
                            centro.EmailCentro = Convert.ToString(dr["EMAIL_CENTRO"]);
                        if (dr["NRO_CONTACTO_1"] != DBNull.Value)
                            centro.NroCentro1 = Convert.ToString(dr["NRO_CONTACTO_1"]);
                        if (dr["NRO_CONTACTO_2"] != DBNull.Value)
                            centro.NroCentro2 = Convert.ToString(dr["NRO_CONTACTO_2"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            centro.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            centro.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            centro.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            centro.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            centro.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            centro.FechaMod = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        listaCentros.Add(centro);

                    }

                    return listaCentros;
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

        public Centro obtenerCentro(int idCentro)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_CENTROS " +
                                    "WHERE ID_CENTRO = @ID_CENTRO " +
                                    "AND FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);

                if (idCentro != 0)
                    cmd.Parameters.AddWithValue("@ID_CENTRO", idCentro);
                else
                    cmd.Parameters.AddWithValue("@ID_CENTRO", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                Centro centro = new Centro();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        if (dr["ID_CENTRO"] != DBNull.Value)
                            centro.IdCentro = Convert.ToInt32(dr["ID_CENTRO"]);
                        if (dr["NOMBRE_CENTRO"] != DBNull.Value)
                            centro.NombreCentro = Convert.ToString(dr["NOMBRE_CENTRO"]);
                        if (dr["DOMICILIO_CENTRO"] != DBNull.Value)
                            centro.DomicilioCentro = Convert.ToString(dr["DOMICILIO_CENTRO"]);
                        if (dr["LOCALIDAD_CENTRO"] != DBNull.Value)
                            centro.LocalidadCentro = Convert.ToString(dr["LOCALIDAD_CENTRO"]);
                        if (dr["EMAIL_CENTRO"] != DBNull.Value)
                            centro.EmailCentro = Convert.ToString(dr["EMAIL_CENTRO"]);
                        if (dr["NRO_CONTACTO_1"] != DBNull.Value)
                            centro.NroCentro1 = Convert.ToString(dr["NRO_CONTACTO_1"]);
                        if (dr["NRO_CONTACTO_2"] != DBNull.Value)
                            centro.NroCentro2 = Convert.ToString(dr["NRO_CONTACTO_2"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            centro.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            centro.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            centro.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            centro.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            centro.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            centro.FechaMod = Convert.ToDateTime(dr["FECHA_BAJA"]);

                    }

                    return centro;
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

        public string DaRegistrarCentros(Centro centro)
        {
            try
            {
                string resultado = "OK";

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "INSERT INTO T_CENTROS (NOMBRE_CENTRO," +
                                                        "DOMICILIO_CENTRO, " +
                                                        "LOCALIDAD_CENTRO," +
                                                        "EMAIL_CENTRO, " +
                                                        "NRO_CONTACTO_1, " +
                                                        "NRO_CONTACTO_2, " +
                                                        "USUARIO_ALTA," +
                                                        "FECHA_ALTA) " +
                                                        "VALUES (" +
                                                        "@NOMBRE_CENTRO," +
                                                        "@DOMICILIO_CENTRO, " +
                                                        "@LOCALIDAD_CENTRO," +
                                                        "@EMAIL_CENTRO, " +
                                                        "@NRO_CONTACTO_1, " +
                                                        "@NRO_CONTACTO_2, " +
                                                        "@USUARIO_ALTA," +
                                                        "@FECHA_ALTA); SELECT SCOPE_IDENTITY()";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(centro.NombreCentro))
                    cmd.Parameters.AddWithValue("@NOMBRE_CENTRO", centro.NombreCentro);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE_CENTRO", DBNull.Value);

                if (!string.IsNullOrEmpty(centro.DomicilioCentro))
                    cmd.Parameters.AddWithValue("@DOMICILIO_CENTRO", centro.DomicilioCentro);
                else
                    cmd.Parameters.AddWithValue("@DOMICILIO_CENTRO", DBNull.Value);

                if (!string.IsNullOrEmpty(centro.LocalidadCentro))
                    cmd.Parameters.AddWithValue("@LOCALIDAD_CENTRO", centro.LocalidadCentro);
                else
                    cmd.Parameters.AddWithValue("@LOCALIDAD_CENTRO", DBNull.Value);

                if (!string.IsNullOrEmpty(centro.EmailCentro))
                    cmd.Parameters.AddWithValue("@EMAIL_CENTRO", centro.EmailCentro);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CENTRO", DBNull.Value);

                if (!string.IsNullOrEmpty(centro.NroCentro1))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO_1", centro.NroCentro1);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO_1", DBNull.Value);

                if (!string.IsNullOrEmpty(centro.NroCentro2))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO_2", centro.NroCentro2);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO_2", DBNull.Value);


                cmd.Parameters.AddWithValue("@USUARIO_ALTA", centro.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", centro.FechaAlta);

                cmd.ExecuteNonQuery();
                //  int devolver = Convert.ToInt32(cmd.ExecuteScalar());
                trans.Commit();

                con.Close();

                return resultado;
            }
            catch (Exception e)
            {
                trans.Rollback();
                con.Close();
                throw e;
            }

        }

        public string DaActualizarCentro(Centro centro)
        {

            string resultado = "OK";
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_CENTROS SET NOMBRE_CENTRO = @NOMBRE_CENTRO," +
                                                        "DOMICILIO_CENTRO = @DOMICILIO_CENTRO," +
                                                        "LOCALIDAD_CENTRO = @LOCALIDAD_CENTRO," +
                                                        "EMAIL_CENTRO = @EMAIL_CENTRO, " +
                                                        "NRO_CONTACTO_1 = @NRO_CONTACTO1, " +
                                                        "NRO_CONTACTO_2 = @NRO_CONTACTO2, " +
                                                        "USUARIO_MOD = @USUARIO_MOD, " +
                                                        "FECHA_MOD = @FECHA_MOD " +
                                                  "WHERE ID_CENTRO = @ID_CENTRO; SELECT SCOPE_IDENTITY()";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(centro.NombreCentro))
                    cmd.Parameters.AddWithValue("@NOMBRE_CENTRO", centro.NombreCentro);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE_CENTRO", DBNull.Value);

                if (!string.IsNullOrEmpty(centro.DomicilioCentro))
                    cmd.Parameters.AddWithValue("@DOMICILIO_CENTRO", centro.DomicilioCentro);
                else
                    cmd.Parameters.AddWithValue("@DOMICILIO_CENTRO", DBNull.Value);

                if (!string.IsNullOrEmpty(centro.LocalidadCentro))
                    cmd.Parameters.AddWithValue("@LOCALIDAD_CENTRO", centro.LocalidadCentro);
                else
                    cmd.Parameters.AddWithValue("@LOCALIDAD_CENTRO", DBNull.Value);

                if (!string.IsNullOrEmpty(centro.EmailCentro))
                    cmd.Parameters.AddWithValue("@EMAIL_CENTRO", centro.EmailCentro);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CENTRO", DBNull.Value);

                if (!string.IsNullOrEmpty(centro.NroCentro1))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO1", centro.NroCentro1);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO1", DBNull.Value);

                if (!string.IsNullOrEmpty(centro.NroCentro2))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO2", centro.NroCentro2);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO2", DBNull.Value);

                cmd.Parameters.AddWithValue("@ID_CENTRO", centro.IdCentro);
                cmd.Parameters.AddWithValue("@USUARIO_MOD", centro.UsuarioMod);
                cmd.Parameters.AddWithValue("@FECHA_MOD", centro.FechaMod);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                resultado = "OK";

            }

            catch (Exception e)
            {
                resultado = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;
            }

            return resultado;

        }

        public string DaDarDeBajaCentro(Centro centro)
        {


            string resultado = "OK";
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_CENTROS SET USUARIO_BAJA = @USUARIO_BAJA," +
                                                        "FECHA_BAJA = @FECHA_BAJA " +
                                                        "WHERE ID_CENTRO = @ID_CENTRO;";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_CENTRO", centro.IdCentro);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", centro.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", centro.FechaBaja);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                resultado = "OK";

            }
            catch (Exception e)
            {

                resultado = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;

            }

            return resultado;

        }


        public int TurnosFuturos(int idCentro)
        {

            int devolver = 0;

            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "SELECT COUNT(*) CANTIDAD " +
                                    "FROM T_TURNOS " +
                                    "WHERE ID_CENTRO = @ID_CENTRO " +
                                    "AND ESTADO = 'OTORGADO' " +
                                    "AND FECHA_BAJA IS NULL " +
                                    "AND FECHA_TURNO > GETDATE(); ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_CENTRO", idCentro);

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


        public DataTable ObtenerTurnosFuturos(int idCentro)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT CONVERT(varchar,T.FECHA_TURNO,103) TURNO, 
								           SUBSTRING ((CONVERT(varchar,T.HORA_DESDE,8)),0,6) as HORA, 
										   CONCAT (P.NOMBRE, ' ', P.APELLIDO) PACIENTE, 
										   P.NRO_CONTACTO,
										   P.EMAIL_CONTACTO
									  FROM T_TURNOS T, T_PACIENTES P
									 WHERE T.ID_PACIENTE = P.ID_PACIENTE
									   AND ID_CENTRO = @idCentro
									   AND ESTADO = 'OTORGADO'
									   AND T.FECHA_BAJA IS NULL
									   AND P.FECHA_BAJA IS NULL
									   AND T.FECHA_TURNO > GETDATE();";

                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@idCentro", idCentro);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string DaDarDeBajaTurnos(int idCentro, int usuarioBaja)
        {

            string resultado = "OK";
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_TURNOS " +
                                     "SET FECHA_BAJA = GETDATE(), ESTADO = 'CANCELADO', USUARIO_BAJA = @USUARIO_BAJA " +
                                     "WHERE ID_CENTRO = @ID_CENTRO " +
                                     "AND FECHA_TURNO > GETDATE();";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_CENTRO", idCentro);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", usuarioBaja);               

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                resultado = "OK";

            }
            catch (Exception e)
            {

                resultado = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;

            }

            return resultado;

        }

        public int validarCentro(string centro)
        {
            int devolver = 0;

            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "SELECT count(*) " +
                                    "FROM T_CENTROS p " +
                                    "WHERE NOMBRE_CENTRO = @CENTRO " +
                                    "AND FECHA_BAJA is null; ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@CENTRO", centro);

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

        public int obtenerTratamientos(int idCentro)
        {
            int devolver = 0;

            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"SELECT COUNT(DISTINCT ID_PLAN_TRATAMIENTO) CANTIDAD
                                      FROM T_TURNOS T, T_PLAN_TRATAMIENTO P
                                     WHERE T.ID_PLAN_TRATAMIENTO = P.ID_TRATAMIENTO
                                       AND ESTADO_PLAN = 'EN CURSO'
                                       AND ID_PLAN_TRATAMIENTO IS NOT NULL
                                       AND T.FECHA_BAJA IS NULL
                                       AND P.FECHA_BAJA IS NULL
                                       AND T.FECHA_TURNO >= GETDATE()
                                       AND T.ID_CENTRO = @ID_CENTRO;";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_CENTRO", idCentro);

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


        public string DarBajaTratamiento(int idCentro, int usuarioBaja)
        {

            string resultado = "OK";
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_PLAN_TRATAMIENTO " +
                                     "SET FECHA_BAJA = GETDATE(), ESTADO_PLAN = 'CANCELADO', USUARIO_BAJA = @USUARIO_BAJA " +
                                     "WHERE ESTADO_PLAN = 'EN CURSO' " +
                                     "AND FECHA_BAJA IS NULL " +
                                     "AND ID_TRATAMIENTO = (SELECT DISTINCT(ID_PLAN_TRATAMIENTO) " +
                                                             "FROM T_TURNOS " +
                                                             "WHERE ID_TRATAMIENTO = ID_PLAN_TRATAMIENTO " +
                                                             "AND ID_CENTRO = @ID_CENTRO " +
                                                             "AND FECHA_BAJA IS NULL " +
                                                             "AND FECHA_TURNO >= GETDATE()); ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_CENTRO", idCentro);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", usuarioBaja);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                resultado = "OK";

            }
            catch (Exception e)
            {

                resultado = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;

            }

            return resultado;

        }


    }
}
