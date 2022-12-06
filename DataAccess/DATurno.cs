using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;
using System.Web;

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
                                        "ID_PROFESIONAL, " +
                                        "ID_OBRA_SOCIAL, " +
                                        "ID_ESPECIALIDAD, " +
                                        "ID_CENTRO, " +
                                        "FECHA_TURNO, " +
                                        "HORA_DESDE, " +
                                        //"HORA_HASTA, " +
                                        "ESTADO, " +
                                        //"OBSERVACIONES, " +
                                        "USUARIO_ALTA, " +
                                        "FECHA_ALTA, " +
                                        "ID_PLAN_OBRA, " +
                                        "NRO_AFILIADO, " +
                                        "NRO_AUTORIZACION_OBRA," +
                                        "ID_PLAN_TRATAMIENTO" +
                                    ") VALUES ( " +
                                        "@ID_PACIENTE, " +
                                        "@ID_PROFESIONAL, " +
                                        "@ID_OBRA_SOCIAL, " +
                                        "@ID_ESPECIALIDAD, " +
                                        "@ID_CENTRO, " +
                                        "@FECHA_TURNO, " +
                                        "@HORA_DESDE, " +
                                        //"@HORA_HASTA, " +
                                        "@ESTADO, " +
                                        //"@OBSERVACIONES, " +
                                        "@USUARIO_ALTA, " +
                                        "@FECHA_ALTA, " +
                                        "@ID_PLAN_OBRA, " +
                                        "@NRO_AFILIADO, " +
                                        "@NRO_AUTORIZACION_OBRA," +
                                        "@ID_PLAN_TRATAMIENTO" +
                                        ")";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;
                
                if (turno.Paciente.IdPaciente != 0)
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", turno.Paciente.IdPaciente);
                else
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", DBNull.Value);

                if (turno.Profesional.IdProfesional != 0)
                    cmd.Parameters.AddWithValue("@ID_PROFESIONAL", turno.Profesional.IdProfesional);
                else
                    cmd.Parameters.AddWithValue("@ID_PROFESIONAL", DBNull.Value);

                if (turno.Especialidad.IdEspecialidad != 0)
                    cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", turno.Especialidad.IdEspecialidad);
                else
                    cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", DBNull.Value);

                if (turno.Centro.IdCentro != 0)
                    cmd.Parameters.AddWithValue("@ID_CENTRO", turno.Centro.IdCentro);
                else
                    cmd.Parameters.AddWithValue("@ID_CENTRO", DBNull.Value);
                 
                if (turno.ObraSocial.IdObraSocial != 0)
                    cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", turno.ObraSocial.IdObraSocial);
                else
                    cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", DBNull.Value);

                if (turno.ObraSocial.IdPlanObra != 0)
                    cmd.Parameters.AddWithValue("@ID_PLAN_OBRA", turno.ObraSocial.IdPlanObra);
                else
                    cmd.Parameters.AddWithValue("@ID_PLAN_OBRA", DBNull.Value);

                if (!string.IsNullOrEmpty(turno.NroAfiliado))
                    cmd.Parameters.AddWithValue("@NRO_AFILIADO", turno.NroAfiliado);
                else
                    cmd.Parameters.AddWithValue("@NRO_AFILIADO", DBNull.Value);

                if (!string.IsNullOrEmpty(turno.NroAutorizacionObra))
                    cmd.Parameters.AddWithValue("@NRO_AUTORIZACION_OBRA", turno.NroAutorizacionObra);
                else
                    cmd.Parameters.AddWithValue("@NRO_AUTORIZACION_OBRA", DBNull.Value);

                if (turno.Id_PlanTratamiento != 0)
                    cmd.Parameters.AddWithValue("@ID_PLAN_TRATAMIENTO", turno.Id_PlanTratamiento);
                else
                    cmd.Parameters.AddWithValue("@ID_PLAN_TRATAMIENTO", DBNull.Value);

                cmd.Parameters.AddWithValue("@FECHA_TURNO", turno.FechaTurno);
                cmd.Parameters.AddWithValue("@HORA_DESDE", turno.HoraDesde);
                cmd.Parameters.AddWithValue("@ESTADO", "OTORGADO");
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
                        if (dr["ID_PROFESIONAL"] != DBNull.Value)
                        {
                            Profesional prof = new Profesional();
                            turno.Profesional = prof;
                            turno.Profesional.IdProfesional = Convert.ToInt32(dr["ID_PROFESIONAL"]);
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
                                        where t.ID_PROFESIONAL = @idProfesionalDetalle
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

        public DataTable TraerTurnos(string idProfesional, DateTime dia)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"
                                    select * ,
                                    (SELECT distinct E.DESCRIPCION FROM T_ESPECIALIDADES E
                                        WHERE E.ID_ESPECIALIDADES = t.ID_ESPECIALIDAD
                                    ) as ESPECIALIDAD,
                                    (select distinct p.APELLIDO + ' ' + p.NOMBRE from T_PROFESIONALES_DETALLE PD, T_PROFESIONALES p 
                                        where Pd.ID_PROFESIONAL = T.ID_PROFESIONAL
                                        and pd.ID_PROFESIONAL = p.ID_PROFESIONAL
                                    ) as PROFESIONAL,
                                    (SELECT CONCAT(PA.APELLIDO, ' ', PA.NOMBRE, ' - Contacto: ', PA.NRO_CONTACTO)
                                     FROM T_PACIENTES PA
                                     WHERE PA.ID_PACIENTE = T.ID_PACIENTE) as PACIENTE
                                        from T_TURNOS t
                                        where t.ID_PROFESIONAL = @idProfesional
                                        and t.FECHA_BAJA is null
                                        AND t.ESTADO NOT IN ('CANCELADO')
                                        AND t.FECHA_TURNO = @diaTurno
                                            order by hora_desde";

                cmd = new SqlCommand(consulta, con);

                if (!String.IsNullOrEmpty(idProfesional))
                    cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                else
                    cmd.Parameters.AddWithValue("@idProfesional", DBNull.Value);

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

        public DataTable TraerTurnosDelDia(string idCentro, string dia)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"select * ,
	                                (select distinct C.NOMBRE_CENTRO from T_CENTROS C
		                                where c.ID_CENTRO = t.ID_CENTRO) as CENTRO,
                                    (SELECT distinct E.DESCRIPCION FROM T_ESPECIALIDADES E
                                        WHERE E.ID_ESPECIALIDADES = t.ID_ESPECIALIDAD
                                    ) as ESPECIALIDAD,
                                    (select distinct p.APELLIDO + ' ' + p.NOMBRE from T_PROFESIONALES_DETALLE PD, T_PROFESIONALES p 
                                        where Pd.ID_PROFESIONAL = T.ID_PROFESIONAL
                                        and pd.ID_PROFESIONAL = p.ID_PROFESIONAL
                                    ) as PROFESIONAL,
                                    (SELECT CONCAT(PA.APELLIDO, ' ', PA.NOMBRE)
                                     FROM T_PACIENTES PA
                                     WHERE PA.ID_PACIENTE = T.ID_PACIENTE) as PACIENTE,
                                    (SELECT PA.NRO_CONTACTO
                                     FROM T_PACIENTES PA
                                     WHERE PA.ID_PACIENTE = T.ID_PACIENTE) as CONTACTO,
                                    (SELECT concat(os.DESCRIPCION, ' (', op.DESCRIPCION ,')') 
                                    FROM T_OBRAS_SOCIALES OS, T_OBRAS_PLANES OP
                                    WHERE os.ID_OBRA_SOCIAL = t.ID_OBRA_SOCIAL
                                    and os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL
                                    and op.ID_PLANES = t.ID_PLAN_OBRA
                                    and os.FECHA_BAJA is null
                                    and op.FECHA_BAJA is null
                                    UNION
	                                SELECT os.DESCRIPCION
	                                  FROM T_OBRAS_SOCIALES os, T_OBRAS_PACIENTES op
	                                 WHERE op.ID_OBRA_SOCIAL = os.ID_OBRA_SOCIAL
	                                   AND os.DESCRIPCION = 'PARTICULAR'
                                       AND op.FECHA_BAJA IS NULL
	                                   AND op.ID_PACIENTE = T.ID_PACIENTE) as OBRA_SOCIAL,
                                    t.NRO_AFILIADO,
                                    t.NRO_AUTORIZACION_OBRA
                                        from T_TURNOS t
                                        where t.ID_CENTRO = @idCentro                                  
                                        AND t.FECHA_TURNO = @dia
                                            order by hora_desde;";

                //string consulta = @"
                //                    select * ,
                //                 (select distinct C.NOMBRE_CENTRO from T_CENTROS C
                //                  where c.ID_CENTRO = t.ID_CENTRO) as CENTRO,
                //                    (SELECT distinct E.DESCRIPCION FROM T_ESPECIALIDADES E
                //                        WHERE E.ID_ESPECIALIDADES = t.ID_ESPECIALIDAD
                //                    ) as ESPECIALIDAD,
                //                    (select distinct p.APELLIDO + ' ' + p.NOMBRE from T_PROFESIONALES_DETALLE PD, T_PROFESIONALES p 
                //                        where Pd.ID_PROFESIONAL = T.ID_PROFESIONAL
                //                        and pd.ID_PROFESIONAL = p.ID_PROFESIONAL
                //                    ) as PROFESIONAL,
                //                    (SELECT CONCAT(PA.APELLIDO, ' ', PA.NOMBRE)
                //                     FROM T_PACIENTES PA
                //                     WHERE PA.ID_PACIENTE = T.ID_PACIENTE) as PACIENTE,
                //                    (SELECT PA.NRO_CONTACTO
                //                     FROM T_PACIENTES PA
                //                     WHERE PA.ID_PACIENTE = T.ID_PACIENTE) as CONTACTO,
                //                    (SELECT concat(os.DESCRIPCION, ' (', op.DESCRIPCION ,')') 
                //                    FROM T_OBRAS_SOCIALES OS, T_OBRAS_PLANES OP
                //                    WHERE os.ID_OBRA_SOCIAL = t.ID_OBRA_SOCIAL
                //                    and os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL
                //                    and op.ID_PLANES = t.ID_PLAN_OBRA
                //                    UNION
                //                 SELECT os.DESCRIPCION
                //                   FROM T_OBRAS_SOCIALES os, T_OBRAS_PACIENTES op
                //                  WHERE op.ID_OBRA_SOCIAL = os.ID_OBRA_SOCIAL
                //                    AND os.DESCRIPCION = 'PARTICULAR'
                //                    AND op.ID_PACIENTE = T.ID_PACIENTE) as OBRA_SOCIAL,
                //                    t.NRO_AFILIADO,
                //                    t.NRO_AUTORIZACION_OBRA
                //                        from T_TURNOS t
                //                        where t.FECHA_BAJA is null
                //                        and t.ESTADO NOT IN ('CANCELADO')
                //                        and t.ID_CENTRO = @idCentro
                //                        AND t.FECHA_TURNO = @dia
                //                            order by hora_desde";

                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@idCentro", idCentro);
                cmd.Parameters.AddWithValue("@dia", Convert.ToDateTime(dia));

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

        public DataTable TraeEstados()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"
                                    select * from T_TURNOS_ESTADOS 
                                        ";

                cmd = new SqlCommand(consulta, con);

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

        public DataTable TraeEstadosFecha()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"SELECT * 
                                      FROM T_TURNOS_ESTADOS
                                     WHERE ESTADO NOT IN ('ATENDIDO','EN ESPERA');";

                cmd = new SqlCommand(consulta, con);

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


        public void ModificarEstadoEnTurno(string idturno, string estado)
        {
            try
            {

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"
                                    update T_TURNOS
                                    set ESTADO = @estado,
                                        USUARIO_MOD = 1,
                                        FECHA_MOD = GETDATE()
                                    where ID_TURNO = @idTurnos
                                        ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@idTurnos", idturno);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CancelarTurno(string idturno, string estado)
        {
            try
            {

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"
                                    update T_TURNOS
                                    set ESTADO = @estado,
                                        USUARIO_BAJA = 1,
                                        FECHA_BAJA = GETDATE()
                                    where ID_TURNO = @idTurnos";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Parameters.AddWithValue("@idTurnos", idturno);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarNroOrden(string idturno, string autorizacion)
        {
            try
            {

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"
                                    update T_TURNOS
                                    set NRO_AUTORIZACION_OBRA = @nroAutorizacion,
                                        USUARIO_MOD = 1,
                                        FECHA_MOD = GETDATE()
                                    where ID_TURNO = @idTurnos
                                        ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@nroAutorizacion", autorizacion);
                cmd.Parameters.AddWithValue("@idTurnos", idturno);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TraerTurnosInformes(string idSucursal, string idObraSocial, string fechaDesde, string fechaHasta)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"
                                    select 
	                                    (select distinct C.NOMBRE_CENTRO from T_CENTROS C
		                                    where c.ID_CENTRO = t.ID_CENTRO) as CENTRO,
                                        (SELECT distinct E.CODIGO_ESPECIALIDAD FROM T_ESPECIALIDADES E
                                            WHERE E.ID_ESPECIALIDADES = t.ID_ESPECIALIDAD
                                        ) as CODIGO_ESPECIALIDAD,
                                        (SELECT distinct E.DESCRIPCION FROM T_ESPECIALIDADES E
                                            WHERE E.ID_ESPECIALIDADES = t.ID_ESPECIALIDAD
                                        ) as ESPECIALIDAD,
                                        (select distinct p.APELLIDO + ' ' + p.NOMBRE from T_PROFESIONALES_DETALLE PD, T_PROFESIONALES p 
                                            where Pd.ID_PROFESIONAL = T.ID_PROFESIONAL
                                            and pd.ID_PROFESIONAL = p.ID_PROFESIONAL
                                        ) as PROFESIONAL,
                                        (SELECT CONCAT(PA.APELLIDO, ' ', PA.NOMBRE)
                                            FROM T_PACIENTES PA
                                            WHERE PA.ID_PACIENTE = T.ID_PACIENTE) as PACIENTE,
                                        (SELECT PA.DOCUMENTO
                                            FROM T_PACIENTES PA
                                            WHERE PA.ID_PACIENTE = T.ID_PACIENTE) as DOCUMENTO,
                                        (SELECT os.DESCRIPCION 
                                        FROM T_OBRAS_SOCIALES OS, T_OBRAS_PLANES OP
                                        WHERE os.ID_OBRA_SOCIAL = t.ID_OBRA_SOCIAL
                                        and os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL
                                        and op.ID_PLANES = t.ID_PLAN_OBRA) as OBRA_SOCIAL,
	                                    (SELECT op.DESCRIPCION 
                                        FROM T_OBRAS_SOCIALES OS, T_OBRAS_PLANES OP
                                        WHERE os.ID_OBRA_SOCIAL = t.ID_OBRA_SOCIAL
                                        and os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL
                                        and op.ID_PLANES = t.ID_PLAN_OBRA) as DESCRIPCION,
	                                    FECHA_TURNO,
	                                    HORA_DESDE,
	                                    ESTADO,
	                                    t.NRO_AFILIADO,
                                        NRO_AUTORIZACION_OBRA
                                            from T_TURNOS t
                                            where t.FECHA_BAJA is null
		                                    AND ESTADO = 'ATENDIDO'
		                                    AND T.ID_OBRA_SOCIAL <> 1
 
                                        ";

                //idSucursal, idObraSocial, fechaDesde, fechaHasta
                cmd = new SqlCommand();

                if (!string.IsNullOrEmpty(idSucursal))
                {
                    cmd.Parameters.AddWithValue("@ID_CENTRO", idSucursal);
                    consulta += " AND T.ID_CENTRO = @ID_CENTRO ";
                }

                if (!string.IsNullOrEmpty(idObraSocial))
                {
                    cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", idObraSocial);
                    consulta += " AND T.ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL ";
                }

                if (!string.IsNullOrEmpty(fechaDesde) && !string.IsNullOrEmpty(fechaHasta))
                {
                    cmd.Parameters.AddWithValue("@FECHA_DESDE", fechaDesde);
                    cmd.Parameters.AddWithValue("@FECHA_HASTA", fechaHasta);

                    consulta += " AND FECHA_TURNO BETWEEN @FECHA_DESDE AND @FECHA_HASTA ";
                }
                cmd.CommandText = consulta;
                cmd.Connection = con;

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

        public bool VerificarTurnoDisponible(Turno turno)
        {
            try
            {
                bool validacion = false;

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"
                                    select * from T_TURNOS t
                                    where t.ID_CENTRO = @idCentro
                                    and t.ID_ESPECIALIDAD = @idEspecialidad
                                    and t.ID_PROFESIONAL = @idProfesional
                                    and t.FECHA_TURNO = @diaTurno
                                    and t.HORA_DESDE = @horaTurno 
                                    and t.ESTADO != 'CANCELADO'
                                        ";

                cmd = new SqlCommand(consulta, con);

                if (turno.Centro.IdCentro != 0)
                    cmd.Parameters.AddWithValue("@idCentro", turno.Centro.IdCentro);
                else
                    cmd.Parameters.AddWithValue("@idCentro", DBNull.Value);

                if (turno.Especialidad.IdEspecialidad != 0)
                    cmd.Parameters.AddWithValue("@idEspecialidad", turno.Especialidad.IdEspecialidad);
                else
                    cmd.Parameters.AddWithValue("@idEspecialidad", DBNull.Value);

                if (turno.Profesional.IdProfesional != 0)
                    cmd.Parameters.AddWithValue("@idProfesional", turno.Profesional.IdProfesional);
                else
                    cmd.Parameters.AddWithValue("@idProfesional", DBNull.Value);

                cmd.Parameters.AddWithValue("@diaTurno", turno.FechaTurno);
                cmd.Parameters.AddWithValue("@horaTurno", turno.HoraDesde);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    validacion = false;
                }
                else
                {
                    validacion = true;
                }
                return validacion;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidacionDelDiaTurno(Turno turno)
        {
            try
            {
                bool validacion = false;

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"
                                    select * from T_TURNOS t
                                    where t.ID_CENTRO = @idCentro
                                    and t.ID_ESPECIALIDAD = @idEspecialidad
                                    and t.ID_PROFESIONAL = @idProfesional
                                    and t.ID_PACIENTE = @idPaciente
                                    and t.FECHA_TURNO = @diaTurno
                                    and t.ESTADO != 'CANCELADO'
                                        ";

                cmd = new SqlCommand(consulta, con);

                if (turno.Centro.IdCentro != 0)
                    cmd.Parameters.AddWithValue("@idCentro", turno.Centro.IdCentro);
                else
                    cmd.Parameters.AddWithValue("@idCentro", DBNull.Value);

                if (turno.Especialidad.IdEspecialidad != 0)
                    cmd.Parameters.AddWithValue("@idEspecialidad", turno.Especialidad.IdEspecialidad);
                else
                    cmd.Parameters.AddWithValue("@idEspecialidad", DBNull.Value);

                if (turno.Profesional.IdProfesional != 0)
                    cmd.Parameters.AddWithValue("@idProfesional", turno.Profesional.IdProfesional);
                else
                    cmd.Parameters.AddWithValue("@idProfesional", DBNull.Value);

                if (turno.Paciente.IdPaciente != 0)
                    cmd.Parameters.AddWithValue("@idPaciente", turno.Paciente.IdPaciente);
                else
                    cmd.Parameters.AddWithValue("@idPaciente", DBNull.Value);

                cmd.Parameters.AddWithValue("@diaTurno", turno.FechaTurno);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    validacion = false;
                }
                else
                {
                    validacion = true;
                }
                return validacion;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EditarObservacionTurno(Turno turno)
        {
            try
            {

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"
                                    update T_TURNOS
                                    set OBSERVACIONES = @observacion,
                                        USUARIO_MOD = @usuarioMod,
                                        FECHA_MOD = @fechaMod
                                    where ID_TURNO = @idTurnos
                                        ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(turno.Observaciones))
                    cmd.Parameters.AddWithValue("@observacion", turno.Observaciones);
                else
                    cmd.Parameters.AddWithValue("@observacion", DBNull.Value);


                cmd.Parameters.AddWithValue("@usuarioMod", turno.UsuarioMod);
                cmd.Parameters.AddWithValue("@fechaMod", turno.FechaMod);

                cmd.Parameters.AddWithValue("@idTurnos", turno.IdTurno);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CambiarEstadoReprogramarTurnos(string idDisponibilidad, string idProfesional, int idUsuarioMod)
        {
            try
            {
                bool result = false;
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"
                                    update T_TURNOS
                                    set
	                                    ESTADO = 'REPROGRAMAR',
	                                    USUARIO_MOD = @usrMod, FECHA_MOD = GETDATE()
                                    where ID_TURNO in (
                                    select T.ID_TURNO
                                        from T_DISPONIBILIDAD_HORARIA DH, T_TURNOS T
                                        WHERE DH.ID_PROFESIONAL = T.ID_PROFESIONAL
                                        AND DH.ID_CENTRO = T.ID_CENTRO
                                        AND T.FECHA_BAJA IS NULL
                                        AND T.ESTADO NOT IN ('CANCELADO', 'REPROGRAMAR')
                                        AND DH.ID_DISPONIBILIDAD = @idDisponibilidad
                                        AND DH.ID_PROFESIONAL = @idProfesional
                                        AND T.FECHA_TURNO BETWEEN DH.FECHA_INIC AND DH.FECHA_FIN
                                        AND T.HORA_DESDE BETWEEN DH.HORA_DESDE AND DH.HORA_HASTA
                                    )
                                    ;
                                        ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@usrMod", idUsuarioMod);
                cmd.Parameters.AddWithValue("@idDisponibilidad", idDisponibilidad);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                result = true;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Turno> TraerTurnosReprogramar(string idCentro)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT * FROM T_TURNOS T
                                        WHERE T.FECHA_BAJA IS NULL
		                                AND T.ESTADO = 'REPROGRAMAR'
		                                AND T.ID_CENTRO = @idCentro
                                    ; ";

                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@idCentro", idCentro);

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
                            DAPaciente daPaciente = new DAPaciente();
                            Paciente paciente = daPaciente.BuscarPacientePorId(dr["ID_PACIENTE"].ToString());
                            turno.Paciente = paciente;
                        }
                        if (dr["ID_PROFESIONAL"] != DBNull.Value)
                        {
                            DAProfesional daProfesional = new DAProfesional();
                            Profesional profesional = daProfesional.obtenerProfesional(Convert.ToInt32(dr["ID_PROFESIONAL"]));
                            turno.Profesional = profesional;
                        }
                        if (dr["ID_OBRA_SOCIAL"] != DBNull.Value)
                        {
                            DAObrasSociales daObraSocial = new DAObrasSociales();
                            ObraSocial obraSoc = daObraSocial.traerObraSocialById(dr["ID_OBRA_SOCIAL"].ToString());
                            turno.ObraSocial = obraSoc;
                        }
                        if (dr["ID_PLAN_OBRA"] != DBNull.Value)
                        {
                            DAObrasSociales daObraSocial = new DAObrasSociales();
                            ObrasPlanes planObraSoc = daObraSocial.traerPlanObraById(dr["ID_PLAN_OBRA"].ToString());
                            if(turno.ObraSocial != null) { 
                            turno.ObraSocial.PlanObraSocial = planObraSoc;
                            }
                        }
                        if (dr["ID_ESPECIALIDAD"] != DBNull.Value)
                        {
                            DAEspecialidades daEspecialidad = new DAEspecialidades();
                            Especialidad especialidad = daEspecialidad.obtenerEspecialidad(Convert.ToInt32(dr["ID_ESPECIALIDAD"].ToString()));
                            turno.Especialidad = especialidad;
                        }
                        if (dr["ID_CENTRO"] != DBNull.Value)
                        {
                            DACentros daCentro = new DACentros();
                            Centro centro = daCentro.obtenerCentro(Convert.ToInt32(dr["ID_CENTRO"].ToString()));
                            turno.Centro = centro;
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
                        if (dr["NRO_AFILIADO"] != DBNull.Value)
                            turno.NroAfiliado = Convert.ToString(dr["NRO_AFILIADO"]);
                        if (dr["NRO_AUTORIZACION_OBRA"] != DBNull.Value)
                            turno.NroAutorizacionObra = Convert.ToString(dr["NRO_AUTORIZACION_OBRA"]);

                        listaTurnos.Add(turno);
                    }

                    return listaTurnos;
                }
                else
                {
                    return listaTurnos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CancelarTurnoReprogramar(string idTurno)
        {
            try
            {
                string resultado = "OK";
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"
                                    UPDATE T_TURNOS
                                        SET ESTADO = 'CANCELADO', USUARIO_BAJA = @usrBaja, FECHA_BAJA = @fechaBaja
                                        WHERE ID_TURNO = @idTurno
                                    ;";

                cmd = new SqlCommand(consulta, con);

                cmd.Transaction = trans;

                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];

                cmd.Parameters.AddWithValue("@usrBaja", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@fechaBaja", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@idTurno", idTurno);

                cmd.ExecuteNonQuery();

                trans.Commit();
                con.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }
        }

        public Turno CargarDatosTurnoReprogramar(string idTurno)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT * FROM T_TURNOS T
                                        WHERE T.FECHA_BAJA IS NULL
		                                AND T.ESTADO = 'REPROGRAMAR'
		                                AND T.ID_TURNO = @idTurno
                                    ; ";

                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@idTurno", idTurno);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                Turno turno = new Turno();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        if (dr["ID_TURNO"] != DBNull.Value)
                            turno.IdTurno = Convert.ToInt32(dr["ID_TURNO"]);
                        if (dr["ID_PACIENTE"] != DBNull.Value)
                        {
                            DAPaciente daPaciente = new DAPaciente();
                            Paciente paciente = daPaciente.BuscarPacientePorId(dr["ID_PACIENTE"].ToString());
                            turno.Paciente = paciente;
                        }
                        if (dr["ID_PROFESIONAL"] != DBNull.Value)
                        {
                            DAProfesional daProfesional = new DAProfesional();
                            Profesional profesional = daProfesional.obtenerProfesional(Convert.ToInt32(dr["ID_PROFESIONAL"]));
                            turno.Profesional = profesional;
                        }
                        if (dr["ID_OBRA_SOCIAL"] != DBNull.Value)
                        {
                            DAObrasSociales daObraSocial = new DAObrasSociales();
                            ObraSocial obraSoc = daObraSocial.traerObraSocialById(dr["ID_OBRA_SOCIAL"].ToString());
                            turno.ObraSocial = obraSoc;
                        }
                        if (dr["ID_PLAN_OBRA"] != DBNull.Value)
                        {
                            DAObrasSociales daObraSocial = new DAObrasSociales();
                            ObrasPlanes planObraSoc = daObraSocial.traerPlanObraById(dr["ID_PLAN_OBRA"].ToString());
                            turno.ObraSocial.PlanObraSocial = planObraSoc;
                        }
                        if (dr["ID_ESPECIALIDAD"] != DBNull.Value)
                        {
                            DAEspecialidades daEspecialidad = new DAEspecialidades();
                            Especialidad especialidad = daEspecialidad.obtenerEspecialidad(Convert.ToInt32(dr["ID_ESPECIALIDAD"].ToString()));
                            turno.Especialidad = especialidad;
                        }
                        if (dr["ID_CENTRO"] != DBNull.Value)
                        {
                            DACentros daCentro = new DACentros();
                            Centro centro = daCentro.obtenerCentro(Convert.ToInt32(dr["ID_CENTRO"].ToString()));
                            turno.Centro = centro;
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
                        if (dr["NRO_AFILIADO"] != DBNull.Value)
                            turno.NroAfiliado = Convert.ToString(dr["NRO_AFILIADO"]);
                        if (dr["NRO_AUTORIZACION_OBRA"] != DBNull.Value)
                            turno.NroAutorizacionObra = Convert.ToString(dr["NRO_AUTORIZACION_OBRA"]);

                    }

                    return turno;
                }
                else
                {
                    return turno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ReprogramarTurno(Turno turno)
        {
            try
            {
                string resultado = "OK";
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"
                                    UPDATE T_TURNOS
                                        SET ESTADO = 'OTORGADO', USUARIO_MOD = @usrMod, FECHA_MOD = @fechaMod,
                                            FECHA_TURNO = @fechaTurno, HORA_DESDE = @horaDesde
                                        WHERE ID_TURNO = @idTurno
                                    ;";

                cmd = new SqlCommand(consulta, con);

                cmd.Transaction = trans;

                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];

                cmd.Parameters.AddWithValue("@usrMod", turno.UsuarioMod);
                cmd.Parameters.AddWithValue("@fechaMod", turno.FechaMod);
                cmd.Parameters.AddWithValue("@idTurno", turno.IdTurno);
                cmd.Parameters.AddWithValue("@fechaTurno", turno.FechaTurno);
                cmd.Parameters.AddWithValue("@horaDesde", turno.HoraDesde);

                cmd.ExecuteNonQuery();

                trans.Commit();
                con.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }
        }

        public DataTable buscarTurnosVencidos()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT ID_TURNO 
                                      FROM T_TURNOS
                                     WHERE FECHA_BAJA IS NULL
                                       AND ESTADO NOT IN ('CANCELADO', 'ATENDIDO')
                                       AND FECHA_TURNO <= GETDATE()
                                       AND HORA_DESDE <= (SELECT CAST(DATEPART(HOUR,GETDATE()) as char(2))+':'+CAST(DATEPART(MINUTE,GETDATE()) as char(2))+':'+
                                                         CAST(DATEPART(SECOND,GETDATE()) as char(2)) as hora);";

                cmd = new SqlCommand(consulta, con);

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

        public string cancelarTurnos(string idturno)
        {

            string resultado = "OK";
            try
            {

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @" UPDATE T_TURNOS
                                        SET FECHA_BAJA = GETDATE(), USUARIO_BAJA = 1, ESTADO = 'CANCELADO'
                                        WHERE ID_TURNO = @ID_TURNO;";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_TURNO", idturno);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
