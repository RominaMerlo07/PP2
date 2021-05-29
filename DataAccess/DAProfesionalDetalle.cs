using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DAProfesionalDetalle
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;


        public int DaRegistrarProfesionalDetalle(ProfesionalDetalle profesionalDetalle)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "INSERT INTO T_PROFESIONALES_DETALLE " +
                                       "(ID_PROFESIONAL, " +
                                        "ID_CENTRO, " +
                                        "ID_ESPECIALIDAD, " +
                                        "USUARIO_ALTA, " +
                                        "FECHA_ALTA) " +
                                    "VALUES " +
                                        "(@ID_PROFESIONAL, " +
                                        "@ID_CENTRO, " +
                                        "@ID_ESPECIALIDAD, " +
                                        "@USUARIO_ALTA, " +
                                        "@FECHA_ALTA); SELECT SCOPE_IDENTITY()";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (profesionalDetalle.Profesional.IdProfesional != 0)
                    cmd.Parameters.AddWithValue("@ID_PROFESIONAL", profesionalDetalle.Profesional.IdProfesional);
                else
                    cmd.Parameters.AddWithValue("@ID_PROFESIONAL", DBNull.Value);

                if (profesionalDetalle.Centro.IdCentro != 0)
                    cmd.Parameters.AddWithValue("@ID_CENTRO", profesionalDetalle.Centro.IdCentro);
                else
                    cmd.Parameters.AddWithValue("@ID_CENTRO", DBNull.Value);

                if (profesionalDetalle.Especialidad.IdEspecialidad != 0)
                    cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", profesionalDetalle.Especialidad.IdEspecialidad);
                else
                    cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", DBNull.Value);

                cmd.Parameters.AddWithValue("@USUARIO_ALTA", profesionalDetalle.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", profesionalDetalle.FechaAlta);

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

        public List<ProfesionalDetalle> traerDetallesPorCentro(string id_Centro, string idProfesional)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT PD.* " +
                                    "FROM T_ESPECIALIDADES E, T_PROFESIONALES_DETALLE PD " +
                                    "WHERE E.ID_ESPECIALIDADES = PD.ID_ESPECIALIDAD " +
                                    "AND PD.ID_PROFESIONAL = @ID_PROFESIONAL " +
                                    "AND PD.ID_CENTRO = @ID_CENTRO;";

                cmd = new SqlCommand(consulta, con);

                if (!string.IsNullOrEmpty(idProfesional))
                    cmd.Parameters.AddWithValue("@ID_PROFESIONAL", idProfesional);
                else
                    cmd.Parameters.AddWithValue("@ID_PROFESIONAL", DBNull.Value);

                if (!string.IsNullOrEmpty(id_Centro))
                    cmd.Parameters.AddWithValue("@ID_CENTRO", id_Centro);
                else
                    cmd.Parameters.AddWithValue("@ID_CENTRO", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<ProfesionalDetalle> listaProfDetalle = new List<ProfesionalDetalle>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ProfesionalDetalle profDetalle = new ProfesionalDetalle();

                        if (dr["ID_PROFESIONALES_DETALLE"] != DBNull.Value)
                            profDetalle.IdProfesionalDetalle = Convert.ToInt32(dr["ID_PROFESIONALES_DETALLE"]);

                        Profesional profesional = new Profesional();
                        if (dr["ID_PROFESIONAL"] != DBNull.Value)
                            profesional.IdProfesional = Convert.ToInt32(dr["ID_PROFESIONAL"]);
                        profDetalle.Profesional = profesional;

                        Centro centro = new Centro();
                        if (dr["ID_CENTRO"] != DBNull.Value)
                            centro.IdCentro = Convert.ToInt32(dr["ID_CENTRO"]);
                        profDetalle.Centro = centro;

                        Especialidad especialidad = new Especialidad();
                        if (dr["ID_ESPECIALIDAD"] != DBNull.Value)
                            especialidad.IdEspecialidad = Convert.ToInt32(dr["ID_ESPECIALIDAD"]);
                        profDetalle.Especialidad = especialidad;


                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            profDetalle.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            profDetalle.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            profDetalle.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            profDetalle.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            profDetalle.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            profDetalle.FechaMod = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        listaProfDetalle.Add(profDetalle);

                    }

                    return listaProfDetalle;
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
    }
}
