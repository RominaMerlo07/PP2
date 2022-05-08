using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DAPaciente
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;


        public int DaRegistrarPaciente(Paciente paciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "INSERT INTO T_PACIENTES (" +
                                              "NOMBRE, " +
                                              "APELLIDO, " +
                                              "DOCUMENTO, " +
                                              "NRO_CONTACTO, " +
                                              "EMAIL_CONTACTO, " +
                                              "USUARIO_ALTA, " +
                                              "FECHA_ALTA " +
                                    ") VALUES ( " +
                                              "@NOMBRE, " +
                                              "@APELLIDO, " +
                                              "@DOCUMENTO, " +
                                              "@NRO_CONTACTO, " +
                                              "@EMAIL_CONTACTO, " +
                                              "@USUARIO_ALTA, " +
                                              "@FECHA_ALTA " +
                                              "); ; SELECT SCOPE_IDENTITY()";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(paciente.Nombre))
                    cmd.Parameters.AddWithValue("@NOMBRE", paciente.Nombre);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.Apellido))
                    cmd.Parameters.AddWithValue("@APELLIDO", paciente.Apellido);
                else
                    cmd.Parameters.AddWithValue("@APELLIDO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.Documento))
                    cmd.Parameters.AddWithValue("@DOCUMENTO", paciente.Documento);
                else
                    cmd.Parameters.AddWithValue("@DOCUMENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.NroContacto))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", paciente.NroContacto);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.EmailContacto))
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", paciente.EmailContacto);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", DBNull.Value);

                cmd.Parameters.AddWithValue("@USUARIO_ALTA", paciente.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", paciente.FechaAlta);

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

        public int DaEditarPaciente(Paciente paciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();


                string consulta = @" 
                    update T_PACIENTES
                    set NOMBRE = @NOMBRE,
                        APELLIDO = @APELLIDO, 
                        NRO_CONTACTO = @NRO_CONTACTO, 
                        EMAIL_CONTACTO = @EMAIL_CONTACTO,
                        USUARIO_MOD = @USUARIO_MOD,
                        FECHA_MOD = FECHA_MOD
                    where DOCUMENTO = @DOCUMENTO 
                    and fecha_baja is null
                    ; ";
                    //SELECT * from T_PACIENTES where DOCUMENTO = @DOCUMENTO and fecha_baja is null ;


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(paciente.Nombre))
                    cmd.Parameters.AddWithValue("@NOMBRE", paciente.Nombre);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.Apellido))
                    cmd.Parameters.AddWithValue("@APELLIDO", paciente.Apellido);
                else
                    cmd.Parameters.AddWithValue("@APELLIDO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.Documento))
                    cmd.Parameters.AddWithValue("@DOCUMENTO", paciente.Documento);
                else
                    cmd.Parameters.AddWithValue("@DOCUMENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.NroContacto))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", paciente.NroContacto);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.EmailContacto))
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", paciente.EmailContacto);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", DBNull.Value);

                cmd.Parameters.AddWithValue("@USUARIO_MOD", paciente.UsuarioMod);
                cmd.Parameters.AddWithValue("@FECHA_MOD", paciente.FechaMod);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                Paciente pacienteID = BuscarPaciente(paciente.Documento);

                return pacienteID.IdPaciente;
            }
            catch (Exception e)
            {
                trans.Rollback();
                con.Close();
                throw e;
            }
        }

        public Paciente BuscarPaciente(string dniPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @" SELECT top 1 * FROM t_pacientes 
                                        WHERE FECHA_BAJA IS NULL
                                        and documento = @documento ";

                cmd = new SqlCommand(consulta, con);

                if (!String.IsNullOrEmpty(dniPaciente))
                    cmd.Parameters.AddWithValue("@documento", dniPaciente);
                else
                    cmd.Parameters.AddWithValue("@documento", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                Paciente paciente = new Paciente();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID_PACIENTE"] != DBNull.Value)
                            paciente.IdPaciente = Convert.ToInt32(dr["ID_PACIENTE"]);
                        if (dr["NOMBRE"] != DBNull.Value)
                            paciente.Nombre = Convert.ToString(dr["NOMBRE"]);
                        if (dr["APELLIDO"] != DBNull.Value)
                            paciente.Apellido = Convert.ToString(dr["APELLIDO"]);
                        if (dr["DOCUMENTO"] != DBNull.Value)
                            paciente.Documento = Convert.ToString(dr["DOCUMENTO"]);
                        if (dr["NRO_CONTACTO"] != DBNull.Value)
                            paciente.NroContacto = Convert.ToString(dr["NRO_CONTACTO"]);
                        if (dr["EMAIL_CONTACTO"] != DBNull.Value)
                            paciente.EmailContacto = Convert.ToString(dr["EMAIL_CONTACTO"]);
                        if (dr["FECHA_NACIMIENTO"] != DBNull.Value)
                            paciente.FechaNacimiento = Convert.ToDateTime(dr["FECHA_NACIMIENTO"]);
                        if (dr["DOMICILIO"] != DBNull.Value)
                            paciente.Domicilio = Convert.ToString(dr["DOMICILIO"]);
                        if (dr["LOCALIDAD"] != DBNull.Value)
                            paciente.Localidad = Convert.ToString(dr["LOCALIDAD"]);

                    }

                    return paciente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }
        }


        public DataTable cargarPacientes()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT  P.ID_PACIENTE, 
		                                    P.NOMBRE,
		                                    P.APELLIDO, 
		                                    P.DOCUMENTO, 
		                                    P.NRO_CONTACTO,
		                                    P.EMAIL_CONTACTO
	                                   FROM T_PACIENTES P
	                                  WHERE P.FECHA_BAJA IS NULL;";

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


        public DataTable buscarPaciente(string idPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @" SELECT P.ID_PACIENTE, 
											P.NOMBRE,
											P.APELLIDO, 
											P.DOCUMENTO, 
											P.NRO_CONTACTO,
											P.EMAIL_CONTACTO,
                                            OP.ID_OBRA_SOCIAL,
											OS.DESCRIPCION, 
		                                    OP.ID_PLAN,
											OSP.COD_PLAN, 
											OSP.DESCRIPCION 'PLAN',
											OP.NRO_AFILIADO
										FROM T_PACIENTES P, 
											T_OBRAS_PACIENTES OP, 
											T_OBRAS_SOCIALES OS, 
											T_OBRAS_PLANES OSP
										WHERE P.ID_PACIENTE = OP.ID_PACIENTE
										AND OP.ID_OBRA_SOCIAL = OS.ID_OBRA_SOCIAL
										AND OP.ID_PLAN = OSP.ID_PLANES
										AND P.ID_PACIENTE = @ID_PACIENTE
										AND P.FECHA_BAJA IS NULL
										AND OP.FECHA_BAJA IS NULL
										AND OS.FECHA_BAJA IS NULL
										AND OSP.FECHA_BAJA IS NULL;";


                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@ID_PACIENTE", idPaciente);

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


        public string actualizarPaciente(Paciente paciente)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_PACIENTES " +
                                     "SET NOMBRE = @NOMBRE, " +
                                         "APELLIDO = @APELLIDO, " +
                                         "DOCUMENTO = @DOCUMENTO, " +
                                         "NRO_CONTACTO = @NRO_CONTACTO, " +
                                         "EMAIL_CONTACTO = @EMAIL_CONTACTO, " +
                                         "USUARIO_MOD = @USUARIO_MOD, " +
                                         "FECHA_MOD = @FECHA_MOD " +
                                   "WHERE ID_PACIENTE = @ID_PACIENTE; SELECT SCOPE_IDENTITY();";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(paciente.Nombre))
                    cmd.Parameters.AddWithValue("@NOMBRE", paciente.Nombre);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.Apellido))
                    cmd.Parameters.AddWithValue("@APELLIDO", paciente.Apellido);
                else
                    cmd.Parameters.AddWithValue("@APELLIDO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.Documento))
                    cmd.Parameters.AddWithValue("@DOCUMENTO", paciente.Documento);
                else
                    cmd.Parameters.AddWithValue("@DOCUMENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.NroContacto))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", paciente.NroContacto);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.EmailContacto))
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", paciente.EmailContacto);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", DBNull.Value);

                
                cmd.Parameters.AddWithValue("@ID_PACIENTE", paciente.IdPaciente);
                cmd.Parameters.AddWithValue("@USUARIO_MOD", paciente.UsuarioMod);
                cmd.Parameters.AddWithValue("@FECHA_MOD", paciente.FechaMod);

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

        public DataTable obraSocialPaciente(string idPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT op.ID_OBRA_PACIENTE,
	                                       op.ID_OBRA_SOCIAL,
	                                       op.ID_PLAN,
	                                       os.DESCRIPCION,
	                                       opl.COD_PLAN,
	                                       opl.DESCRIPCION 'PLAN',
	                                       op.NRO_AFILIADO
                                      FROM T_OBRAS_PACIENTES op, 
	                                       T_OBRAS_SOCIALES os, 
	                                       T_OBRAS_PLANES OPL
                                     WHERE op.ID_OBRA_SOCIAL = os.ID_OBRA_SOCIAL
                                       AND OP.ID_PLAN = OPL.ID_PLANES
                                       AND op.ID_PACIENTE = @ID_PACIENTE
                                       AND op.FECHA_BAJA IS NULL
	                                   AND opl.FECHA_BAJA IS NULL
	                                   AND os.FECHA_BAJA IS NULL
                                   UNION
                                    SELECT op.ID_OBRA_PACIENTE,
	                                       op.ID_OBRA_SOCIAL,
	                                       op.ID_PLAN,
	                                       os.DESCRIPCION,
	                                       NULL COD_PLAN,
	                                       NULL 'PLAN',
	                                       NULL NRO_AFILIADO
                                      FROM T_OBRAS_PACIENTES op, 
	                                       T_OBRAS_SOCIALES os
                                     WHERE op.ID_OBRA_SOCIAL = os.ID_OBRA_SOCIAL
                                       AND os.DESCRIPCION = 'PARTICULAR'
                                       AND op.ID_PACIENTE = @ID_PACIENTE
                                       AND op.FECHA_BAJA IS NULL	
	                                   AND os.FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@ID_PACIENTE", idPaciente);

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

        public int registrarOSPaciente(ObrasPacientes obrasPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();


                string consulta = "INSERT INTO T_OBRAS_PACIENTES " +
                                                         "(ID_OBRA_SOCIAL, " +
                                                         "ID_PACIENTE, " +
                                                         "ID_PLAN, " +
                                                         "NRO_AFILIADO, " +
                                                         "USUARIO_ALTA, " +
                                                         "FECHA_ALTA) " +
                                                    " VALUES ( " +
                                                        "@ID_OBRA_SOCIAL, " +
                                                        "@ID_PACIENTE, " +
                                                        "@ID_PLAN, " +
                                                        "@NRO_AFILIADO, " +
                                                        "@USUARIO_ALTA, " +
                                                        "@FECHA_ALTA ); SELECT SCOPE_IDENTITY()";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(Convert.ToString(obrasPaciente.IdObraSocial)))
                    cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", obrasPaciente.IdObraSocial);
                else
                    cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(obrasPaciente.IdPaciente)))
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", obrasPaciente.IdPaciente);
                else
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(obrasPaciente.IdPlan)))
                    cmd.Parameters.AddWithValue("@ID_PLAN", obrasPaciente.IdPlan);
                else
                    cmd.Parameters.AddWithValue("@ID_PLAN", DBNull.Value);

                if (!string.IsNullOrEmpty(obrasPaciente.nroAfiliado))
                    cmd.Parameters.AddWithValue("@NRO_AFILIADO", obrasPaciente.nroAfiliado);
                else
                    cmd.Parameters.AddWithValue("@NRO_AFILIADO", DBNull.Value);

                cmd.Parameters.AddWithValue("@USUARIO_ALTA", obrasPaciente.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", obrasPaciente.FechaAlta);

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

        public int inactivarPaciente(Paciente paciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_PACIENTES " +
                                     "SET USUARIO_BAJA = @USUARIO_BAJA, " +
                                         "FECHA_BAJA = @FECHA_BAJA " +
                                   "WHERE ID_PACIENTE = @ID_PACIENTE;";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_PACIENTE", paciente.IdPaciente);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", paciente.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", paciente.FechaBaja);

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
    }
}
