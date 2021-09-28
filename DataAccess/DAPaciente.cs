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
                string resultado = "OK";

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
    }
}
