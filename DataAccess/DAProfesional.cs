using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DAProfesional
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;


        public string DaRegistrarProfesional(Profesional profesional)
        {
            try
            {
                string resultado = "OK";

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "INSERT INTO T_PROFESIONALES " +
                                              "(NOMBRE," +
                                              "APELLIDO," +
                                              "DOCUMENTO," +
                                              "NRO_CONTACTO," +
                                              "EMAIL_CONTACTO," +
                                              "FECHA_NACIMIENTO," +
                                              "DOMICILIO," +
                                              "LOCALIDAD," +
                                              "NRO_MATRICULA," +
                                              "USUARIO_ALTA," +
                                              "FECHA_ALTA)" +
                                      "VALUES(" +
                                            "@NOMBRE," +
                                            "@APELLIDO," +
                                            "@DOCUMENTO," +
                                            "@NRO_CONTACTO," +
                                            "@EMAIL_CONTACTO," +
                                            "@FECHA_NACIMIENTO," +
                                            "@DOMICILIO," +
                                            "@LOCALIDAD," +
                                            "@NRO_MATRICULA," +
                                            "@USUARIO_ALTA," +
                                            "@FECHA_ALTA); SELECT SCOPE_IDENTITY()";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(profesional.Nombre))
                    cmd.Parameters.AddWithValue("@NOMBRE", profesional.Nombre);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Apellido))
                    cmd.Parameters.AddWithValue("@APELLIDO", profesional.Apellido);
                else
                    cmd.Parameters.AddWithValue("@APELLIDO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Documento))
                    cmd.Parameters.AddWithValue("@DOCUMENTO", profesional.Documento);
                else
                    cmd.Parameters.AddWithValue("@DOCUMENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.NroContacto))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", profesional.NroContacto);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.EmailContacto))
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", profesional.EmailContacto);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(profesional.FechaNacimiento)))
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", profesional.FechaNacimiento);
                else
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Domicilio))
                    cmd.Parameters.AddWithValue("@DOMICILIO", profesional.Domicilio);
                else
                    cmd.Parameters.AddWithValue("@DOMICILIO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Localidad))
                    cmd.Parameters.AddWithValue("@LOCALIDAD", profesional.Localidad);
                else
                    cmd.Parameters.AddWithValue("@LOCALIDAD", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.NroMatricula))
                    cmd.Parameters.AddWithValue("@NRO_MATRICULA", profesional.NroMatricula);
                else
                    cmd.Parameters.AddWithValue("@NRO_MATRICULA", DBNull.Value);



                cmd.Parameters.AddWithValue("@USUARIO_ALTA", profesional.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", profesional.FechaAlta);

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
    }
}

