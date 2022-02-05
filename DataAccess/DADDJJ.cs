
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DADDJJ
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;



        public string DaRegistrarDDJJ(CovidDDJJ covidDDJJ)
        {
            try
            {
                string resultado = "OK";

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "insert into t_covid_ddjj(id_paciente, " +
                                                            "temperatura, " +
                                                            "sintomas, " +
                                                            "contacto_estrecho, " +
                                                            "caso_sospechoso, " +
                                                            "viaje, " +
                                                            "distancia_social," +
                                                            "lugares_cerrados," +
                                                            "fecha_ddjj,usuario_alta, " +
                                                            "fecha_alta) " +
                                                            "values(" +
                                                            "@id_paciente, " +
                                                            "@temperatura, " +
                                                            "@sintomas, " +
                                                            "@contacto_estrecho, " +
                                                            "@caso_sospechoso, " +
                                                            "@viaje, " +
                                                            "@distancia_social," +
                                                            "@lugares_cerrados," +
                                                            "@fecha_ddjj," +
                                                            "@usuario_alta, " +
                                                            "@fecha_alta);";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(Convert.ToString(covidDDJJ.Temperatura)))
                    cmd.Parameters.AddWithValue("@temperatura", covidDDJJ.Temperatura);
                else
                    cmd.Parameters.AddWithValue("@temperatura", DBNull.Value);

                if (!string.IsNullOrEmpty(covidDDJJ.Sintomas))
                    cmd.Parameters.AddWithValue("@sintomas", covidDDJJ.Sintomas);
                else
                    cmd.Parameters.AddWithValue("@sintomas", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(covidDDJJ.ContactoEstrecho)))
                    cmd.Parameters.AddWithValue("@contacto_estrecho", covidDDJJ.ContactoEstrecho);
                else
                    cmd.Parameters.AddWithValue("@contacto_estrecho", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(covidDDJJ.CasoSospechoso)))
                    cmd.Parameters.AddWithValue("@caso_sospechoso", covidDDJJ.CasoSospechoso);
                else
                    cmd.Parameters.AddWithValue("@caso_sospechoso", DBNull.Value);

                //if (!string.IsNullOrEmpty(centro.NroCentro1))
                //    cmd.Parameters.AddWithValue("@NRO_CONTACTO_1", centro.NroCentro1);
                //else
                //    cmd.Parameters.AddWithValue("@NRO_CONTACTO_1", DBNull.Value);

                //if (!string.IsNullOrEmpty(centro.NroCentro2))
                //    cmd.Parameters.AddWithValue("@NRO_CONTACTO_2", centro.NroCentro2);
                //else
                //    cmd.Parameters.AddWithValue("@NRO_CONTACTO_2", DBNull.Value);


                //cmd.Parameters.AddWithValue("@USUARIO_ALTA", centro.UsuarioAlta);
                //cmd.Parameters.AddWithValue("@FECHA_ALTA", centro.FechaAlta);

                cmd.ExecuteNonQuery();
                //  int devolver = Convert.ToInt32(cmd.ExecuteScalar());
                trans.Commit();

                con.Close();

                return resultado;
            }
            catch
            {
                return "ok";
            }
        }
    }
}