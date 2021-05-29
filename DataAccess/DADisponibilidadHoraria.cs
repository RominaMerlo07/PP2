using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DADisponibilidadHoraria
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public string DaRegistrarDisponibilidad(DisponibilidadHoraria disponibilidad)
        {
            try
            {
                string resultado = "OK";

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "INSERT INTO T_DISPONIBILIDAD_HORARIA (" +
                                        "ID_PROFESIONALES_DETALLE, " +
                                        "FECHA_INIC, " +
                                        "FECHA_FIN, " +
                                        "HORA_DESDE, " +
                                        "HORA_HASTA, " +
                                        //"OBSERVACIONES, " +
                                        "USUARIO_ALTA, " +
                                        "FECHA_ALTA " +
                                    ") VALUES ( " +
                                        "@ID_PROFESIONALES_DETALLE, " +
                                        "@FECHA_INIC, " +
                                        "@FECHA_FIN, " +
                                        "@HORA_DESDE, " +
                                        "@HORA_HASTA, " +
                                        //"@OBSERVACIONES, " +
                                        "@USUARIO_ALTA, " +
                                        "@FECHA_ALTA " +
                                        ")";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (disponibilidad.ProfesionalDetalle.IdProfesionalDetalle != 0)
                    cmd.Parameters.AddWithValue("@ID_PROFESIONALES_DETALLE", disponibilidad.ProfesionalDetalle.IdProfesionalDetalle);
                else
                    cmd.Parameters.AddWithValue("@ID_PROFESIONALES_DETALLE", DBNull.Value);

                cmd.Parameters.AddWithValue("@FECHA_INIC", disponibilidad.FechaInic);
                cmd.Parameters.AddWithValue("@FECHA_FIN", disponibilidad.FechaFin);
                cmd.Parameters.AddWithValue("@HORA_DESDE", disponibilidad.HoraDesde);
                cmd.Parameters.AddWithValue("@HORA_HASTA", disponibilidad.HoraHasta);
                cmd.Parameters.AddWithValue("@USUARIO_ALTA", disponibilidad.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", disponibilidad.FechaAlta);

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
