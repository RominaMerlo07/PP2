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
                                        "ID_PROFESIONAL_DETALLE, " +
                                        //"ID_OBRA_SOCIAL, " +
                                        //"ID_ESPECIALIDAD, " +
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
                                        "@ID_PROFESIONAL_DETALLE, " +
                                        //"@ID_OBRA_SOCIAL, " +
                                        //"@ID_ESPECIALIDAD, " +
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
                    cmd.Parameters.AddWithValue("@ID_PROFESIONAL_DETALLE", turno.Especialidad.IdEspecialidad);
                else
                    cmd.Parameters.AddWithValue("@ID_PROFESIONAL_DETALLE", DBNull.Value);

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

        public List<Turno> obtenerTurnosPendientes()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"select * from T_TURNOS t
                                    where t.FECHA_BAJA is null
                                    and FECHA_TURNO >= GETDATE()
                                    ; ";

                cmd = new SqlCommand(consulta, con);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<Turno> listaTurnos = new List<Turno>();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Turno turno = new Turno();
                        if (dr["ID_TURNO"] != DBNull.Value)
                            turno.IdTurno = Convert.ToInt32(dr["ID_TURNO"]);
                        if (dr["ID_PACIENTE"] != DBNull.Value)
                        { 
                            Paciente paciente = new Paciente();
                            turno.Paciente = paciente;
                            turno.Paciente.IdPaciente = Convert.ToInt32(dr["ID_PACIENTE"]);
                        }
                        if (dr["ID_PROFESIONAL_DETALLE"] != DBNull.Value)
                        {
                            ProfesionalDetalle profDetalle = new ProfesionalDetalle();
                            turno.ProfesionalDetalle = profDetalle;
                            turno.ProfesionalDetalle.IdProfesionalDetalle = Convert.ToInt32(dr["ID_PROFESIONAL_DETALLE"]);
                        }
                        if (dr["ID_OBRA_SOCIAL"] != DBNull.Value)
                        {
                            ObraSocial obraSoc = new ObraSocial();
                            turno.ObraSocial = obraSoc;
                            turno.ObraSocial.IdObraSocial = Convert.ToInt32(dr["ID_OBRA_SOCIAL"]);
                        }
                        if (dr["ID_ESPECIALIDAD"] != DBNull.Value)
                        {
                            Especialidad especialidad = new Especialidad();
                            turno.Especialidad = especialidad;
                            turno.Especialidad.IdEspecialidad = Convert.ToInt32(dr["ID_ESPECIALIDAD"]);
                        }
                        if (dr["ID_CENTRO"] != DBNull.Value)
                        {
                            Centro centro = new Centro();
                            turno.Centro = centro;
                            turno.Centro.IdCentro = Convert.ToInt32(dr["ID_CENTRO"]);
                        }
                        if (dr["FECHA_TURNO"] != DBNull.Value)
                            turno.FechaTurno = Convert.ToDateTime(dr["FECHA_TURNO"]);
                        if (dr["HORA_DESDE"] != DBNull.Value)
                            turno.HoraDesde = TimeSpan.Parse(dr["HORA_DESDE"].ToString());
                        if (dr["HORA_HASTA"] != DBNull.Value)
                            turno.HoraHasta = TimeSpan.Parse(dr["HORA_HASTA"].ToString());
                        if (dr["ESTADO"] != DBNull.Value)
                            turno.Estado = Convert.ToString(dr["ESTADO"]);
                        if (dr["OBSERVACIONES"] != DBNull.Value)
                            turno.Observaciones = Convert.ToString(dr["OBSERVACIONES"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            turno.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            turno.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            turno.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            turno.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            turno.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            turno.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        listaTurnos.Add(turno);
                    }

                    return listaTurnos;
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

        public DataTable TraerTurnos(string idProfesionalDetalle)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"select *
                                        from T_TURNOS t
                                        where t.ID_PROFESIONAL_DETALLE = @idProfesionalDetalle
                                        and t.FECHA_BAJA is null
                                        and t.ESTADO is null
                                        AND t.FECHA_TURNO >= CAST( GETDATE() AS Date ) ";

                cmd = new SqlCommand(consulta, con);

                if (!String.IsNullOrEmpty(idProfesionalDetalle))
                    cmd.Parameters.AddWithValue("@idProfesionalDetalle", idProfesionalDetalle);
                else
                    cmd.Parameters.AddWithValue("@idProfesionalDetalle", DBNull.Value);

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

        public DataTable TraerTurnos(string idProfesionalDetalle, DateTime dia)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"
                                    select * ,
	                                    (SELECT E.DESCRIPCION FROM T_ESPECIALIDADES E, T_PROFESIONALES_DETALLE PD
		                                    WHERE E.ID_ESPECIALIDADES = PD.ID_ESPECIALIDAD
		                                    AND PD.ID_PROFESIONALES_DETALLE = T.ID_PROFESIONAL_DETALLE
		                                    ) as ESPECIALIDAD
                                        from T_TURNOS t
                                        where t.ID_PROFESIONAL_DETALLE = @idProfesionalDetalle
                                        and t.FECHA_BAJA is null
                                        and t.ESTADO is null
                                        AND t.FECHA_TURNO = @diaTurno ";

                cmd = new SqlCommand(consulta, con);

                if (!String.IsNullOrEmpty(idProfesionalDetalle))
                    cmd.Parameters.AddWithValue("@idProfesionalDetalle", idProfesionalDetalle);
                else
                    cmd.Parameters.AddWithValue("@idProfesionalDetalle", DBNull.Value);

                cmd.Parameters.AddWithValue("@diaTurno", dia);

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
    }
}
