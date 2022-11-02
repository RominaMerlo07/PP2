using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DAEspecialidades
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public List<Especialidad> traerEspecialidades()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_ESPECIALIDADES " +
                                    "WHERE FECHA_BAJA IS NULL " +
                                    "ORDER BY DESCRIPCION;";

                cmd = new SqlCommand(consulta, con);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<Especialidad> listaEspecialidades = new List<Especialidad>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Especialidad especialidad = new Especialidad();
                        if (dr["ID_ESPECIALIDADES"] != DBNull.Value)
                            especialidad.IdEspecialidad = Convert.ToInt32(dr["ID_ESPECIALIDADES"]);
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            especialidad.Descripcion = Convert.ToString(dr["DESCRIPCION"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            especialidad.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            especialidad.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            especialidad.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            especialidad.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            especialidad.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            especialidad.FechaMod = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        listaEspecialidades.Add(especialidad);

                    }

                    return listaEspecialidades;
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

        public Especialidad obtenerEspecialidad(int idEspecialidad)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_ESPECIALIDADES " +
                                    "WHERE ID_ESPECIALIDADES = @id_especialidad " +
                                    "AND FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);

                if (idEspecialidad != 0)
                    cmd.Parameters.AddWithValue("@id_especialidad", idEspecialidad);
                else
                    cmd.Parameters.AddWithValue("@id_especialidad", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                Especialidad especialidad = new Especialidad();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                       
                        if (dr["ID_ESPECIALIDADES"] != DBNull.Value)
                            especialidad.IdEspecialidad = Convert.ToInt32(dr["ID_ESPECIALIDADES"]);
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            especialidad.Descripcion = Convert.ToString(dr["DESCRIPCION"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            especialidad.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            especialidad.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            especialidad.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            especialidad.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            especialidad.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            especialidad.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);

                    }

                    return especialidad;
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

        public DataTable obtenerEspecialidadDisponible(string idCentro)
        //obtiene las Especialidades, segun el Centro, que tengan Disponibilidad Horaria cargada
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                //e.*, pd.*, dh.*
                string consulta = @"SELECT DISTINCT e.ID_ESPECIALIDADES, e.DESCRIPCION
                                      FROM t_especialidades e, t_profesionales_detalle pd, T_CENTROS c
                                     WHERE e.id_especialidades = pd.id_especialidad
                                       AND pd.ID_CENTRO = c.ID_CENTRO
                                       AND e.FECHA_BAJA is null
                                       AND pd.FECHA_BAJA is null
                                       AND c.FECHA_BAJA is null
                                       AND pd.id_centro = @id_centro;
                                    ; ";

                cmd = new SqlCommand(consulta, con);

                if (!String.IsNullOrEmpty(idCentro))
                    cmd.Parameters.AddWithValue("@id_centro", idCentro);
                else
                    cmd.Parameters.AddWithValue("@id_centro", DBNull.Value);

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

        public string DaRegistrarEspecialidades(Especialidad especialidad)
        {
            try
            {
                string resultado = "OK";

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "INSERT INTO T_ESPECIALIDADES(" +
                                                "DESCRIPCION, " +
                                                "USUARIO_ALTA, " +
                                                "FECHA_ALTA) " +
                                   "VALUES(" +
                                                "@DESCRIPCION, " +
                                                "@USUARIO_ALTA, " +
                                                "@FECHA_ALTA); SELECT SCOPE_IDENTITY()";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(especialidad.Descripcion))
                    cmd.Parameters.AddWithValue("@DESCRIPCION", especialidad.Descripcion);
                else
                    cmd.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value);

                cmd.Parameters.AddWithValue("@USUARIO_ALTA", especialidad.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", especialidad.FechaAlta);

                cmd.ExecuteNonQuery();

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

        public List<Especialidad> traerEspecialidadesNotInProfesional(string idProfesional)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT E.ID_ESPECIALIDADES, 
                                           E.DESCRIPCION 
                                      FROM T_ESPECIALIDADES E 
                                     WHERE ID_ESPECIALIDADES NOT IN (SELECT PD.ID_ESPECIALIDAD 
                                                                       FROM T_PROFESIONALES_DETALLE PD 
                                                                      WHERE PD.ID_ESPECIALIDAD = ID_ESPECIALIDADES 
                                                                        AND PD.ID_PROFESIONAL = @idProfesional)";

                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<Especialidad> listaEspecialidades = new List<Especialidad>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Especialidad especialidad = new Especialidad();
                        if (dr["ID_ESPECIALIDADES"] != DBNull.Value)
                            especialidad.IdEspecialidad = Convert.ToInt32(dr["ID_ESPECIALIDADES"]);
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            especialidad.Descripcion = Convert.ToString(dr["DESCRIPCION"]);

                        listaEspecialidades.Add(especialidad);

                    }

                    return listaEspecialidades;
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


        public string editarEspecialidad(Especialidad especialidad)
        {
            try
            {
                string resultado = "OK";

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_ESPECIALIDADES " +
                                     "SET DESCRIPCION = @DESCRIPCION, FECHA_MOD = @FECHA_MOD, USUARIO_MOD = @USUARIO_MOD " +
                                     "WHERE ID_ESPECIALIDADES = @ID_ESPECIALIDADES; ";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(especialidad.Descripcion))
                    cmd.Parameters.AddWithValue("@DESCRIPCION", especialidad.Descripcion);
                else
                    cmd.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value);


                cmd.Parameters.AddWithValue("@ID_ESPECIALIDADES", especialidad.IdEspecialidad);
                cmd.Parameters.AddWithValue("@USUARIO_MOD", especialidad.UsuarioMod);
                cmd.Parameters.AddWithValue("@FECHA_MOD", especialidad.FechaMod);

                cmd.ExecuteNonQuery();

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


        public int TurnosFuturos(int idEspecialidad)
        {

            int devolver = 0;

            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "SELECT COUNT(*) CANTIDAD " +
                                    "FROM T_TURNOS T, T_ESPECIALIDADES E " +
                                    "WHERE T.ID_ESPECIALIDAD = E.ID_ESPECIALIDADES " +
                                    "AND E.ID_ESPECIALIDADES = @ID_ESPECIALIDAD " +
                                    "AND T.ESTADO = 'OTORGADO' " +
                                    "AND T.FECHA_BAJA IS NULL " +
                                    "AND E.FECHA_BAJA IS NULL " +
                                    "AND T.FECHA_TURNO > GETDATE(); ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", idEspecialidad);

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


        public DataTable ObtenerTurnosFuturos(int idEspecialidad)
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
                                      FROM T_TURNOS T, T_ESPECIALIDADES E, T_PACIENTES P
                                     WHERE T.ID_ESPECIALIDAD = E.ID_ESPECIALIDADES
                                       AND T.ID_PACIENTE = P.ID_PACIENTE
                                       AND E.ID_ESPECIALIDADES = @idEspecialidad
                                       AND T.ESTADO = 'OTORGADO'
                                       AND T.FECHA_BAJA IS NULL
                                       AND E.FECHA_BAJA IS NULL
                                       AND T.FECHA_TURNO > GETDATE();";

                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);

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

        public string DaDarDeBajaTurnos(int idEspecialidad, int usuarioBaja)
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
                                     "WHERE ID_ESPECIALIDAD = @ID_ESPECIALIDAD " +
                                     "AND FECHA_TURNO > GETDATE(); ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", idEspecialidad);
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


        public string DaDarDeBajaEspecialidad(Especialidad especialidad)
        {


            string resultado = "OK";
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_ESPECIALIDADES " +
                                     "SET USUARIO_BAJA = @USUARIO_BAJA, FECHA_BAJA = @FECHA_BAJA " +
                                     "WHERE ID_ESPECIALIDADES = @ID_ESPECIALIDAD;";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", especialidad.IdEspecialidad);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", especialidad.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", especialidad.FechaBaja);

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


        public string darBajaEspecialidad(Especialidad especialidad)
        {


            string resultado = "OK";
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_ESPECIALIDADES " +
                                     "SET USUARIO_BAJA = @USUARIO_BAJA, FECHA_BAJA = @FECHA_BAJA " +
                                     "WHERE ID_ESPECIALIDADES = @ID_ESPECIALIDAD;";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", especialidad.IdEspecialidad);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", especialidad.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", especialidad.FechaBaja);

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
