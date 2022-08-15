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

                //if (disponibilidad.ProfesionalDetalle.IdProfesionalDetalle != 0)
                //    cmd.Parameters.AddWithValue("@ID_PROFESIONALES_DETALLE", disponibilidad.ProfesionalDetalle.IdProfesionalDetalle);
                //else
                //    cmd.Parameters.AddWithValue("@ID_PROFESIONALES_DETALLE", DBNull.Value);

                cmd.Parameters.AddWithValue("@FECHA_INIC", disponibilidad.FechaInic);
                cmd.Parameters.AddWithValue("@FECHA_FIN", disponibilidad.FechaFin);
                //cmd.Parameters.AddWithValue("@HORA_DESDE", disponibilidad.HoraDesde);
                cmd.Parameters.Add("@HORA_DESDE", SqlDbType.Time).Value = disponibilidad.HoraDesde;
                //cmd.Parameters.AddWithValue("@HORA_HASTA", disponibilidad.HoraHasta);
                cmd.Parameters.Add("@HORA_HASTA", SqlDbType.Time).Value = disponibilidad.HoraHasta;
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

        public List<DisponibilidadHoraria> DaTraerHorariosProfesional(string idProfesional, string centro = null)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string preConsulta = @"SELECT * FROM T_DISPONIBILIDAD_HORARIA 
                                WHERE FECHA_BAJA IS NULL 
                                AND ID_PROFESIONAL = @ID_PROFESIONAL 
                                {0}
                                ORDER BY ID_DISPONIBILIDAD;";

                string filtroCentro = " AND ID_CENTRO = @ID_CENTRO ";
                string consulta = "";
                if (centro != null)
                {
                    consulta = String.Format(preConsulta, filtroCentro);
                } else
                {
                    consulta = String.Format(preConsulta, " ");
                }

                cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@ID_PROFESIONAL", idProfesional);
                if (centro != null) { 
                    cmd.Parameters.AddWithValue("@ID_CENTRO", centro);
                }


                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<DisponibilidadHoraria> listaDisponibilidad = new List<DisponibilidadHoraria>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        DisponibilidadHoraria disponibilidad = new DisponibilidadHoraria();

                        if (dr["ID_DISPONIBILIDAD"] != DBNull.Value)
                            disponibilidad.IdDisponibilidadHoraria = Convert.ToInt32(dr["ID_DISPONIBILIDAD"]);
                        if (dr["FECHA_INIC"] != DBNull.Value)
                            disponibilidad.FechaInic = Convert.ToDateTime(dr["FECHA_INIC"]);
                        if (dr["FECHA_FIN"] != DBNull.Value)
                            disponibilidad.FechaFin = Convert.ToDateTime(dr["FECHA_FIN"]);
                        if (dr["HORA_DESDE"] != DBNull.Value)
                            disponibilidad.HoraDesde = TimeSpan.Parse(dr["HORA_DESDE"].ToString());
                        if (dr["HORA_HASTA"] != DBNull.Value)
                            disponibilidad.HoraHasta = TimeSpan.Parse(dr["HORA_HASTA"].ToString());
                        if (dr["OBSERVACIONES"] != DBNull.Value)
                            disponibilidad.Observaciones = Convert.ToString(dr["OBSERVACIONES"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            disponibilidad.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            disponibilidad.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            disponibilidad.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            disponibilidad.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            disponibilidad.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            disponibilidad.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        if (dr["ID_CENTRO"] != DBNull.Value)
                        {
                            DACentros daCentro = new DACentros();
                            Centro centroEnt = daCentro.obtenerCentro(Convert.ToInt32(dr["ID_CENTRO"]));
                            disponibilidad.Centro = centroEnt;
                        }                          

                        if (dr["LUNES"] != DBNull.Value)
                            disponibilidad.Lunes = Convert.ToBoolean(dr["LUNES"]);
                        if (dr["MARTES"] != DBNull.Value)
                            disponibilidad.Martes = Convert.ToBoolean(dr["MARTES"]);
                        if (dr["MIERCOLES"] != DBNull.Value)
                            disponibilidad.Miercoles = Convert.ToBoolean(dr["MIERCOLES"]);
                        if (dr["JUEVES"] != DBNull.Value)
                            disponibilidad.Jueves = Convert.ToBoolean(dr["JUEVES"]);
                        if (dr["VIERNES"] != DBNull.Value)
                            disponibilidad.Viernes = Convert.ToBoolean(dr["VIERNES"]);                    

                        listaDisponibilidad.Add(disponibilidad);
                    }

                    return listaDisponibilidad;
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

        public DisponibilidadHoraria TraerHorario(string idDisponibilidad)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_DISPONIBILIDAD_HORARIA " +
                                    "WHERE FECHA_BAJA IS NULL " +
                                    "AND ID_DISPONIBILIDAD = @idDisponibilidad ;";

                cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@idDisponibilidad", idDisponibilidad);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    DisponibilidadHoraria disponibilidad = new DisponibilidadHoraria();

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID_DISPONIBILIDAD"] != DBNull.Value)
                            disponibilidad.IdDisponibilidadHoraria = Convert.ToInt32(dr["ID_DISPONIBILIDAD"]);
                        if (dr["FECHA_INIC"] != DBNull.Value)
                            disponibilidad.FechaInic = Convert.ToDateTime(dr["FECHA_INIC"]);
                        if (dr["FECHA_FIN"] != DBNull.Value)
                            disponibilidad.FechaFin = Convert.ToDateTime(dr["FECHA_FIN"]);
                        if (dr["HORA_DESDE"] != DBNull.Value)
                            disponibilidad.HoraDesde = TimeSpan.Parse(dr["HORA_DESDE"].ToString());
                        if (dr["HORA_HASTA"] != DBNull.Value)
                            disponibilidad.HoraHasta = TimeSpan.Parse(dr["HORA_HASTA"].ToString());
                        if (dr["OBSERVACIONES"] != DBNull.Value)
                            disponibilidad.Observaciones = Convert.ToString(dr["OBSERVACIONES"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            disponibilidad.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            disponibilidad.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            disponibilidad.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            disponibilidad.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            disponibilidad.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            disponibilidad.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        if (dr["ID_CENTRO"] != DBNull.Value)
                        {
                            DACentros daCentro = new DACentros();
                            Centro centro = daCentro.obtenerCentro(Convert.ToInt32(dr["ID_CENTRO"]));
                            disponibilidad.Centro = centro;
                        }

                        if (dr["LUNES"] != DBNull.Value)
                            disponibilidad.Lunes = Convert.ToBoolean(dr["LUNES"]);
                        if (dr["MARTES"] != DBNull.Value)
                            disponibilidad.Martes = Convert.ToBoolean(dr["MARTES"]);
                        if (dr["MIERCOLES"] != DBNull.Value)
                            disponibilidad.Miercoles = Convert.ToBoolean(dr["MIERCOLES"]);
                        if (dr["JUEVES"] != DBNull.Value)
                            disponibilidad.Jueves = Convert.ToBoolean(dr["JUEVES"]);
                        if (dr["VIERNES"] != DBNull.Value)
                            disponibilidad.Viernes = Convert.ToBoolean(dr["VIERNES"]);
                    }

                    return disponibilidad;
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

        public String ValidarDisponibilidad(string idProfesional, DisponibilidadHoraria horarioDisponibilidad)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                List<string> dias = new List<string>() ;

                if (horarioDisponibilidad.Lunes)
                    dias.Add("LUNES");
                if (horarioDisponibilidad.Martes)
                    dias.Add("MARTES");
                if (horarioDisponibilidad.Miercoles)
                    dias.Add("MIERCOLES");
                if (horarioDisponibilidad.Jueves)
                    dias.Add("JUEVES");
                if (horarioDisponibilidad.Viernes)
                    dias.Add("VIERNES");

                string filtroDias = "AND (";
                int contador = 0;

                foreach (string dia in dias)
                {
                    contador++;
                    string cadena = dia + " = 1 ";
                    if (contador < dias.Count)
                        cadena += " OR ";
                    else
                        cadena += ")";

                    filtroDias += cadena;
                }

                string preConsulta = @"select count(*) from T_DISPONIBILIDAD_HORARIA
                                        where FECHA_BAJA IS NULL
                                        AND ID_PROFESIONAL = @idProfesional
                                        AND ((@fechaInic between FECHA_INIC and FECHA_FIN) OR --FECHA_INIC
                                         (@fechaFin between FECHA_INIC and FECHA_FIN) OR --FECHA_FIN
                                        (FECHA_INIC between @fechaInic2 and @fechaFin2))

                                    {0}

                                    AND ((@horaDesde between HORA_DESDE and HORA_HASTA) OR  --FECHA_INIC
	                                    (@horaHasta between HORA_DESDE and HORA_HASTA)	OR	--FECHA_FIN
	                                    (HORA_DESDE between @horaDesde2 and @horaHasta2))
                                    ";
                string consulta = String.Format(preConsulta, filtroDias);

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                cmd.Parameters.AddWithValue("@fechaInic", horarioDisponibilidad.FechaInic);
                cmd.Parameters.AddWithValue("@fechaFin", horarioDisponibilidad.FechaFin);
                cmd.Parameters.AddWithValue("@fechaInic2", horarioDisponibilidad.FechaInic);
                cmd.Parameters.AddWithValue("@fechaFin2", horarioDisponibilidad.FechaFin);
                cmd.Parameters.AddWithValue("@horaDesde", horarioDisponibilidad.HoraDesde);
                cmd.Parameters.AddWithValue("@horaHasta", horarioDisponibilidad.HoraHasta);
                cmd.Parameters.AddWithValue("@horaDesde2", horarioDisponibilidad.HoraDesde);
                cmd.Parameters.AddWithValue("@horaHasta2", horarioDisponibilidad.HoraHasta);

                Int32 count = (Int32)cmd.ExecuteScalar();
                con.Close();

                if (count > 0)
                    return "ERR";
                else
                    return "OK";
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
        }

        public String RegistrarDisponibilidad(string idProfesional, DisponibilidadHoraria horarioDisponibilidad)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"
                                    insert into T_DISPONIBILIDAD_HORARIA 
                                        (
                                            FECHA_INIC,
                                            FECHA_FIN,
                                            HORA_DESDE,
                                            HORA_HASTA,
                                            USUARIO_ALTA,
                                            FECHA_ALTA,
                                            ID_PROFESIONAL,
                                            ID_CENTRO,
                                            LUNES,
                                            MARTES,
                                            MIERCOLES,
                                            JUEVES,
                                            VIERNES
                                        ) VALUES (
                                            @fechaInic,
                                            @fechaFin,
                                            @horaDesde,
                                            @horaHasta,
                                            @usuarioAlta,
                                            @fechaAlta,
                                            @idProfesional,
                                            @idCentro,
                                            @lunes,
                                            @martes,
                                            @miercoles,
                                            @jueves,
                                            @viernes
                                        ); 
                                    ";

                

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@fechaInic", horarioDisponibilidad.FechaInic);
                cmd.Parameters.AddWithValue("@fechaFin", horarioDisponibilidad.FechaFin);
                cmd.Parameters.AddWithValue("@horaDesde", horarioDisponibilidad.HoraDesde);
                cmd.Parameters.AddWithValue("@horaHasta", horarioDisponibilidad.HoraHasta);
                cmd.Parameters.AddWithValue("@usuarioAlta", horarioDisponibilidad.UsuarioAlta);
                cmd.Parameters.AddWithValue("@fechaAlta", horarioDisponibilidad.FechaAlta);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                cmd.Parameters.AddWithValue("@idCentro", horarioDisponibilidad.Centro.IdCentro);
                cmd.Parameters.AddWithValue("@lunes", horarioDisponibilidad.Lunes);
                cmd.Parameters.AddWithValue("@martes", horarioDisponibilidad.Martes);
                cmd.Parameters.AddWithValue("@miercoles", horarioDisponibilidad.Miercoles);
                cmd.Parameters.AddWithValue("@jueves", horarioDisponibilidad.Jueves);
                cmd.Parameters.AddWithValue("@viernes", horarioDisponibilidad.Viernes);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                return "OK";
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
        }

        public String ConsultarTurnosEnDisponibilidad(string idDisponibilidad, string idProfesional)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"
                                    select COUNT(*)
                                    from T_DISPONIBILIDAD_HORARIA DH, T_TURNOS T
                                    WHERE DH.ID_PROFESIONAL = T.ID_PROFESIONAL
                                    AND DH.ID_CENTRO = T.ID_CENTRO
                                    AND T.FECHA_BAJA IS NULL
                                    AND T.ESTADO NOT IN ('CANCELADO', 'REPROGRAMAR')
                                    AND DH.ID_DISPONIBILIDAD = @idDisponibilidad
                                    AND DH.ID_PROFESIONAL = @idProfesional
                                    AND T.FECHA_TURNO BETWEEN DH.FECHA_INIC AND DH.FECHA_FIN
                                    AND T.HORA_DESDE BETWEEN DH.HORA_DESDE AND DH.HORA_HASTA
                                    ;
                                    ";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                cmd.Parameters.AddWithValue("@idDisponibilidad", idDisponibilidad);

                Int32 count = (Int32)cmd.ExecuteScalar();
                con.Close();

                return Convert.ToString(count);
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
        }

        public String DarDeBajaDisponibilidad(string idDisponibilidad, string idProfesional, int idUsuarioBaja)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"
                                    UPDATE T_DISPONIBILIDAD_HORARIA
                                    SET USUARIO_BAJA = @usrBaja, FECHA_BAJA = GETDATE()
                                    WHERE ID_DISPONIBILIDAD = @idDisponibilidad
                                    AND ID_PROFESIONAL = @idProfesional
                                    ;
                                    ";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@usrBaja", idUsuarioBaja);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                cmd.Parameters.AddWithValue("@idDisponibilidad", idDisponibilidad);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                return "OK";
            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }
        }
        
    }
}
