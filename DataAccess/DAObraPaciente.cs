using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DAObraPaciente
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public int RegistrarObraPaciente(ObrasPacientes obraPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "INSERT INTO T_OBRAS_PACIENTES " +
                                              "(ID_OBRA_SOCIAL," +
                                              "ID_PACIENTE," +
                                              "ID_PLAN," +
                                              "NRO_AFILIADO," +
                                              "USUARIO_ALTA," +
                                              "FECHA_ALTA)" +
                                      "VALUES(" +
                                            "@ID_OBRA_SOCIAL," +
                                            "@ID_PACIENTE," +
                                            "@ID_PLAN," +
                                            "@NRO_AFILIADO," +
                                            "@USUARIO_ALTA," +
                                            "@FECHA_ALTA); SELECT SCOPE_IDENTITY()";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(Convert.ToString(obraPaciente.IdObraSocial)))
                    cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", obraPaciente.IdObraSocial);
                else
                    cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(obraPaciente.IdPaciente)))
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", obraPaciente.IdPaciente);
                else
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(obraPaciente.IdPlan)))
                    cmd.Parameters.AddWithValue("@ID_PLAN", obraPaciente.IdPlan);
                else
                    cmd.Parameters.AddWithValue("@ID_PLAN", DBNull.Value);

                if (!string.IsNullOrEmpty(obraPaciente.nroAfiliado))
                    cmd.Parameters.AddWithValue("@NRO_AFILIADO", obraPaciente.nroAfiliado);
                else
                    cmd.Parameters.AddWithValue("@NRO_AFILIADO", DBNull.Value);


                cmd.Parameters.AddWithValue("@USUARIO_ALTA", obraPaciente.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", obraPaciente.FechaAlta);

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

        public string inactivarOSPaciente(ObrasPacientes obrasPacientes)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_OBRAS_PACIENTES " +
                                     "SET FECHA_BAJA = @FECHA_BAJA, " +
                                         "USUARIO_BAJA = @USUARIO_BAJA " +
                                   "WHERE ID_OBRA_PACIENTE = @ID_OBRA_PACIENTE; SELECT SCOPE_IDENTITY();";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;


                cmd.Parameters.AddWithValue("@ID_OBRA_PACIENTE", obrasPacientes.IdObraPaciente);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", obrasPacientes.FechaBaja);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", obrasPacientes.UsuarioBaja);

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


        public string actualizarOSPaciente(ObrasPacientes obrasPacientes)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_OBRAS_PACIENTES " +
                                     "SET ID_PLAN = @ID_PLAN, " +
                                         "NRO_AFILIADO = @NRO_AFILIADO, " +
                                         "FECHA_MOD = @FECHA_MOD, " +
                                         "USUARIO_MOD = @USUARIO_MOD " +
                                   "WHERE ID_OBRA_PACIENTE = @ID_OBRA_PACIENTE; SELECT SCOPE_IDENTITY();";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;


                cmd.Parameters.AddWithValue("@ID_OBRA_PACIENTE", obrasPacientes.IdObraPaciente);
                cmd.Parameters.AddWithValue("@ID_PLAN", obrasPacientes.IdPlan);
                cmd.Parameters.AddWithValue("@NRO_AFILIADO", obrasPacientes.nroAfiliado);
                cmd.Parameters.AddWithValue("@FECHA_MOD", obrasPacientes.FechaMod);
                cmd.Parameters.AddWithValue("@USUARIO_MOD", obrasPacientes.UsuarioMod);

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
