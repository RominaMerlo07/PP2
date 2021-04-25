using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DATurno
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public string DaRegistraTurno(Turno turno)
        {
            try
            {
                string resultado = "OK";

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();                

                string consulta = "INSERT INTO T_TURNOS (" +
                                        "ID_PACIENTE, " +
                                        //"ID_PROFESIONAL_DETALLE, " +
                                        //"ID_OBRA_SOCIAL, " +
                                        "ID_ESPECIALIDAD, " +
                                        "ID_CENTRO, " +
                                        "FECHA_TURNO, " +
                                        "HORA_DESDE, " +
                                        //"HORA_HASTA, " +
                                        //"ESTADO, " +
                                        //"OBSERVACIONES, " +
                                        "USUARIO_ALTA, " +
                                        "FECHA_ALTA " +
                                    ") VALUES ( " +
                                        "@ID_PACIENTE, " +
                                        //"@ID_PROFESIONAL_DETALLE, " +
                                        //"@ID_OBRA_SOCIAL, " +
                                        "@ID_ESPECIALIDAD, " +
                                        "@ID_CENTRO, " +
                                        "@FECHA_TURNO, " +
                                        "@HORA_DESDE, " +
                                        //"@HORA_HASTA, " +
                                        //"@ESTADO, " +
                                        //"@OBSERVACIONES, " +
                                        "@USUARIO_ALTA, " +
                                        "@FECHA_ALTA " +
                                        ")";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (turno.Paciente.IdPaciente != 0)
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", turno.Paciente.IdPaciente);
                else
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", DBNull.Value);

                if (turno.Especialidad.IdEspecialidad != 0)
                    cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", turno.Especialidad.IdEspecialidad);
                else
                    cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", DBNull.Value);

                if (turno.Centro.IdCentro != 0)
                    cmd.Parameters.AddWithValue("@ID_CENTRO", turno.Centro.IdCentro);
                else
                    cmd.Parameters.AddWithValue("@ID_CENTRO", DBNull.Value);

                cmd.Parameters.AddWithValue("@FECHA_TURNO", turno.FechaTurno);
                cmd.Parameters.AddWithValue("@HORA_DESDE", turno.HoraDesde);
                cmd.Parameters.AddWithValue("@USUARIO_ALTA", turno.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", turno.FechaAlta);

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
    }
}
