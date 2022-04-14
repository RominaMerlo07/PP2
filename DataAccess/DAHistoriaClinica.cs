using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DAHistoriaClinica
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public HistoriaClinica completarHistClinica(int IdPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"select hc.*
                                        from t_pacientes p
                                        inner join t_historia_clinica hc on hc.id_historia = p.id_historia
                                        where p.id_paciente = @id_paciente
                                        ;";

                cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@id_paciente", IdPaciente);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                HistoriaClinica HC = new HistoriaClinica();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID_HISTORIA"] != DBNull.Value)
                            HC.IdHistoriaClinica = Convert.ToInt32(dr["ID_HISTORIA"]);
                        if (dr["TENSION"] != DBNull.Value)
                            HC.Tension = Convert.ToBoolean(dr["TENSION"]);
                        if (dr["TENSION_VALORES"] != DBNull.Value)
                            HC.TensionValores = Convert.ToString(dr["TENSION_VALORES"]);
                        if (dr["DIABETES"] != DBNull.Value)
                            HC.Diabetes = Convert.ToBoolean(dr["DIABETES"]);
                        if (dr["FUMADOR"] != DBNull.Value)
                            HC.Fumador = Convert.ToBoolean(dr["FUMADOR"]);
                        if (dr["CARDIACO"] != DBNull.Value)
                            HC.Cardiaco = Convert.ToBoolean(dr["CARDIACO"]);
                        if (dr["CIRROSIS"] != DBNull.Value)
                            HC.Cirrosis = Convert.ToBoolean(dr["CIRROSIS"]);
                        if (dr["ARTROSIS"] != DBNull.Value)
                            HC.Artrosis = Convert.ToBoolean(dr["ARTROSIS"]);
                        if (dr["ARTRITIS_REUMATOIDEA"] != DBNull.Value)
                            HC.ArtritisRematoidea = Convert.ToBoolean(dr["ARTRITIS_REUMATOIDEA"]);
                        if (dr["HEMIPLEJIA"] != DBNull.Value)
                            HC.Hemiplejia = Convert.ToBoolean(dr["HEMIPLEJIA"]);
                        if (dr["ASMA"] != DBNull.Value)
                            HC.Asma = Convert.ToBoolean(dr["ASMA"]);
                        if (dr["MARCAPASOS"] != DBNull.Value)
                            HC.Marcapasos = Convert.ToBoolean(dr["MARCAPASOS"]);
                        if (dr["PROTESIS"] != DBNull.Value)
                            HC.Protesis = Convert.ToBoolean(dr["PROTESIS"]);
                        if (dr["CADERA_DERECHA"] != DBNull.Value)
                            HC.CaderaDerecha = Convert.ToBoolean(dr["CADERA_DERECHA"]);
                        if (dr["CADERA_IZQUIERDA"] != DBNull.Value)
                            HC.CaderaIzquierda = Convert.ToBoolean(dr["CADERA_IZQUIERDA"]);
                        if (dr["OTROS"] != DBNull.Value)
                            HC.Otros = Convert.ToString(dr["OTROS"]);
                        if (dr["ANTECEDENTES"] != DBNull.Value)
                            HC.Antecedentes = Convert.ToString(dr["ANTECEDENTES"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            HC.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            HC.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            HC.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            HC.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            HC.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            HC.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);
                    }

                    return HC;
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

        public int registrarHistoriaClinica(Paciente paciente)
        {
            try
            {

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();


                string consulta = @"
                                INSERT INTO T_HISTORIA_CLINICA
                                           (TENSION
                                           ,TENSION_VALORES
                                           ,DIABETES
                                           ,FUMADOR
                                           ,CARDIACO
                                           ,CIRROSIS
                                           ,ARTROSIS
                                           ,ARTRITIS_REUMATOIDEA
                                           ,HEMIPLEJIA
                                           ,ASMA
                                           ,MARCAPASOS
                                           ,PROTESIS
                                           ,CADERA_DERECHA
                                           ,CADERA_IZQUIERDA
                                           ,OTROS
                                           ,ANTECEDENTES
                                           ,USUARIO_ALTA
                                           ,FECHA_ALTA)
                                     VALUES
                                           (@TENSION
                                           ,@TENSION_VALORES
                                           ,@DIABETES
                                           ,@FUMADOR
                                           ,@CARDIACO
                                           ,@CIRROSIS
                                           ,@ARTROSIS
                                           ,@ARTRITIS_REUMATOIDEA
                                           ,@HEMIPLEJIA
                                           ,@ASMA
                                           ,@MARCAPASOS
                                           ,@PROTESIS
                                           ,@CADERA_DERECHA
                                           ,@CADERA_IZQUIERDA
                                           ,@OTROS
                                           ,@ANTECEDENTES
                                           ,@USUARIO_ALTA
                                           ,@FECHA_ALTA
                                ); SELECT SCOPE_IDENTITY()";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@TENSION", paciente.HistoriaClinica.Tension);
                if (paciente.HistoriaClinica.TensionValores != "False")
                    cmd.Parameters.AddWithValue("@TENSION_VALORES", paciente.HistoriaClinica.TensionValores);
                else
                    cmd.Parameters.AddWithValue("@TENSION_VALORES", DBNull.Value);

                cmd.Parameters.AddWithValue("@DIABETES", paciente.HistoriaClinica.Diabetes);
                cmd.Parameters.AddWithValue("@FUMADOR", paciente.HistoriaClinica.Fumador);
                cmd.Parameters.AddWithValue("@CARDIACO", paciente.HistoriaClinica.Cardiaco);
                cmd.Parameters.AddWithValue("@CIRROSIS", paciente.HistoriaClinica.Cirrosis);
                cmd.Parameters.AddWithValue("@ARTROSIS", paciente.HistoriaClinica.Artrosis);
                cmd.Parameters.AddWithValue("@ARTRITIS_REUMATOIDEA", paciente.HistoriaClinica.ArtritisRematoidea);
                cmd.Parameters.AddWithValue("@HEMIPLEJIA", paciente.HistoriaClinica.Hemiplejia);
                cmd.Parameters.AddWithValue("@ASMA", paciente.HistoriaClinica.Asma);
                cmd.Parameters.AddWithValue("@MARCAPASOS", paciente.HistoriaClinica.Marcapasos);
                cmd.Parameters.AddWithValue("@PROTESIS", paciente.HistoriaClinica.Protesis);
                cmd.Parameters.AddWithValue("@CADERA_DERECHA", paciente.HistoriaClinica.CaderaDerecha);
                cmd.Parameters.AddWithValue("@CADERA_IZQUIERDA", paciente.HistoriaClinica.CaderaIzquierda);
                if (paciente.HistoriaClinica.Otros != "False")
                    cmd.Parameters.AddWithValue("@OTROS", paciente.HistoriaClinica.Otros);
                else
                    cmd.Parameters.AddWithValue("@OTROS", DBNull.Value);
                if (paciente.HistoriaClinica.Antecedentes != "False")
                    cmd.Parameters.AddWithValue("@ANTECEDENTES", paciente.HistoriaClinica.Antecedentes);
                else
                    cmd.Parameters.AddWithValue("@ANTECEDENTES", DBNull.Value);
                cmd.Parameters.AddWithValue("@USUARIO_ALTA", paciente.HistoriaClinica.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", paciente.HistoriaClinica.FechaAlta);


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
