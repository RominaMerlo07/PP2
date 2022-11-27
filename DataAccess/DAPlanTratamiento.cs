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
    public class DAPlanTratamiento
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public int InsertarTratamiento(PlanTratamiento tratamiento)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"INSERT INTO T_PLAN_TRATAMIENTO (
                                    DESCRIPCION, FECHA, USUARIO_ALTA, FECHA_ALTA, ESTADO_PLAN, CONSENTIMIENTO_FIRMADO
                                    ) VALUES ( 
                                    @DESCRIPCION, @FECHA, @USUARIO_ALTA, @FECHA_ALTA, @ESTADO_PLAN, @CONSENTIMIENTO_FIRMADO
                                    )
                                    ; SELECT SCOPE_IDENTITY()";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(tratamiento.Descripcion))
                    cmd.Parameters.AddWithValue("@DESCRIPCION", tratamiento.Descripcion);
                else
                    cmd.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value);

                cmd.Parameters.AddWithValue("@FECHA", tratamiento.Fecha);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", tratamiento.FechaAlta);
                cmd.Parameters.AddWithValue("@USUARIO_ALTA", tratamiento.UsuarioAlta);
                cmd.Parameters.AddWithValue("@ESTADO_PLAN", "EN CURSO");
                cmd.Parameters.AddWithValue("@CONSENTIMIENTO_FIRMADO", false);

                int devolver = Convert.ToInt32(cmd.ExecuteScalar());
                trans.Commit();

                con.Close();

                return devolver;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TraerTratamientos(string idPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"SELECT top 20  PT.ID_TRATAMIENTO,
		                                    PT.FECHA AS FECHA_ALTA,
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
                                    (SELECT concat(os.DESCRIPCION, ' (', op.DESCRIPCION ,')') 
                                    FROM T_OBRAS_SOCIALES OS, T_OBRAS_PLANES OP
                                    WHERE os.ID_OBRA_SOCIAL = t.ID_OBRA_SOCIAL
                                    and os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL
                                    and op.ID_PLANES = t.ID_PLAN_OBRA) as OBRA_SOCIAL,
                                    t.NRO_AFILIADO,
                                    t.NRO_AUTORIZACION_OBRA,
                                    PT.CONSENTIMIENTO_FIRMADO
                                    FROM T_PLAN_TRATAMIENTO PT
                                    INNER JOIN T_TURNOS T ON PT.ID_TRATAMIENTO = T.ID_PLAN_TRATAMIENTO
                                    WHERE PT.ESTADO_PLAN != 'CANCELADO' 
                                    {0}
                                    GROUP BY ID_TRATAMIENTO, PT.FECHA, T.ID_CENTRO, T.ID_ESPECIALIDAD, T.ID_PROFESIONAL, 
	                                    T.ID_PACIENTE,T.ID_OBRA_SOCIAL, T.ID_PLAN_OBRA, T.NRO_AFILIADO, T.NRO_AUTORIZACION_OBRA, PT.CONSENTIMIENTO_FIRMADO 
                                    order by FECHA_ALTA desc";

                string data = "";
                if (!String.IsNullOrEmpty(idPaciente))
                {
                    data = "AND T.ID_PACIENTE = @ID_PACIENTE";
                    consulta = string.Format(consulta, data);
                }
                else
                {
                    consulta = string.Format(consulta, data);
                }
                cmd = new SqlCommand(consulta, con);

                if (!string.IsNullOrEmpty(idPaciente))
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", idPaciente);

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

        public void DarBajaTratamiento(PlanTratamiento tratamiento)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"update T_PLAN_TRATAMIENTO
                                        SET ESTADO_PLAN = 'CANCELADO', USUARIO_BAJA = @usrBaja, FECHA_BAJA = @fechaBaja
                                        WHERE ID_TRATAMIENTO = @idTratamiento;
                                    UPDATE T_TURNOS
                                        SET ESTADO = 'CANCELADO', USUARIO_BAJA = @usrBaja2, FECHA_BAJA = @fechaBaja2
                                        WHERE ID_PLAN_TRATAMIENTO = @idTratamiento2
                                    ;";

                cmd = new SqlCommand(consulta, con);

                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@usrBaja", tratamiento.UsuarioBaja);
                cmd.Parameters.AddWithValue("@fechaBaja", tratamiento.FechaBaja);
                cmd.Parameters.AddWithValue("@idTratamiento", tratamiento.IdTratamiento);

                cmd.Parameters.AddWithValue("@usrBaja2", tratamiento.UsuarioBaja);
                cmd.Parameters.AddWithValue("@fechaBaja2", tratamiento.FechaBaja);
                cmd.Parameters.AddWithValue("@idTratamiento2", tratamiento.IdTratamiento);

                cmd.ExecuteNonQuery();

                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }
        }

        public DataTable TraerTratamientoEditar(string idTratamiento)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"SELECT 
	                                    T.ID_TURNO,
	                                    PT.ID_TRATAMIENTO,
	                                    T.ID_PACIENTE,
	                                    T.ID_PROFESIONAL,
	                                    T.ID_OBRA_SOCIAL,
	                                    T.ID_ESPECIALIDAD,
	                                    T.ID_CENTRO,
	                                    T.ID_PLAN_OBRA,

	                                    T.FECHA_TURNO,
	                                    T.HORA_DESDE,
	                                    T.ESTADO,	
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
                                    (SELECT PA.DOCUMENTO
                                        FROM T_PACIENTES PA
                                        WHERE PA.ID_PACIENTE = T.ID_PACIENTE) as DOCUMENTO,
                                    (SELECT concat(os.DESCRIPCION, ' (', op.DESCRIPCION ,')') 
                                        FROM T_OBRAS_SOCIALES OS, T_OBRAS_PLANES OP
                                        WHERE os.ID_OBRA_SOCIAL = t.ID_OBRA_SOCIAL
                                        and os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL
                                        and op.ID_PLANES = t.ID_PLAN_OBRA) as OBRA_SOCIAL,
                                    t.NRO_AFILIADO,
                                    t.NRO_AUTORIZACION_OBRA,
                                    t.OBSERVACIONES
                                    FROM T_PLAN_TRATAMIENTO PT
                                        INNER JOIN T_TURNOS T ON PT.ID_TRATAMIENTO = T.ID_PLAN_TRATAMIENTO
                                    WHERE PT.ESTADO_PLAN != 'CANCELADO' 
                                        --AND T.ESTADO != 'CANCELADO' 
                                        AND PT.ID_TRATAMIENTO = @idTratamiento ;";

                cmd = new SqlCommand(consulta, con);

                if (!string.IsNullOrEmpty(idTratamiento))
                    cmd.Parameters.AddWithValue("@idTratamiento", idTratamiento);

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

        public void EditarTratamiento(PlanTratamiento tratamiento, Turno turno)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"update T_PLAN_TRATAMIENTO
                                        SET USUARIO_MOD = @usrModificacion, FECHA_MOD = @fechaModificacion
                                        WHERE ID_TRATAMIENTO = @idTratamiento
                                    ;";

                cmd = new SqlCommand(consulta, con);

                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@usrModificacion", tratamiento.UsuarioMod);
                cmd.Parameters.AddWithValue("@fechaModificacion", tratamiento.FechaMod);
                cmd.Parameters.AddWithValue("@idTratamiento", tratamiento.IdTratamiento);

                cmd.ExecuteNonQuery();

                trans.Commit();
                con.Close();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }
        }

        public string CancelarTurnoEditarTratamiento(string idTurno, string idTratamiento)
        {
            try
            {
                string resultado = "OK";
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"UPDATE T_PLAN_TRATAMIENTO
                                        SET USUARIO_MOD = @usrModificacion, FECHA_MOD = @fechaModificacion
                                        WHERE ID_TRATAMIENTO = @idTratamiento;
                                    UPDATE T_TURNOS
                                        SET ESTADO = 'CANCELADO', USUARIO_BAJA = @usrBaja2, FECHA_BAJA = @fechaBaja2
                                        WHERE ID_PLAN_TRATAMIENTO = @idTratamiento2
                                        AND ID_TURNO = @idTurno
                                    ;";

                cmd = new SqlCommand(consulta, con);

                cmd.Transaction = trans;

                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];

                cmd.Parameters.AddWithValue("@usrModificacion", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@fechaModificacion", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@idTratamiento", idTratamiento);

                cmd.Parameters.AddWithValue("@usrBaja2", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@fechaBaja2", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@idTurno", idTurno);
                cmd.Parameters.AddWithValue("@idTratamiento2", idTratamiento);

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

        
        public DataTable BuscarPlanTratamiento(string idPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"select * from T_PLAN_TRATAMIENTO
                                        where ID_TRATAMIENTO in (
                                        select distinct ID_PLAN_TRATAMIENTO
                                        from T_TURNOS
                                        where ID_PACIENTE = @idPaciente
                                        and ID_PLAN_TRATAMIENTO is not null)";

                
                cmd = new SqlCommand(consulta, con);

                if (!string.IsNullOrEmpty(idPaciente))
                    cmd.Parameters.AddWithValue("@idPaciente", idPaciente);

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
        
        public string EditarTratamientoSeguimiento(PlanTratamiento tratamiento)
        {
            try
            {
                string result = "OK";
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"update T_PLAN_TRATAMIENTO
                                        SET 
                                        PROFESIONAL_DERIVANTE = @profDerivante,
                                        MATRICULA = @matricula,
                                        ESPECIALIDAD = @especialidad,
                                        DIAGNOSTICO_INGRESO = @diagnIngreso,
                                        EVALUACION_INGRESO = @evaIngreso,
                                        DESCRIPCION_PLAN = @descrPlan,
                                        OBJETIVO_PLAN = @objPlan,
                                        USUARIO_MOD = @usrModificacion, FECHA_MOD = @fechaModificacion
                                        WHERE ID_TRATAMIENTO = @idTratamiento
                                    ;";

                cmd = new SqlCommand(consulta, con);

                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(tratamiento.ProfesionalDerivante))
                    cmd.Parameters.AddWithValue("@profDerivante", tratamiento.ProfesionalDerivante);
                else
                    cmd.Parameters.AddWithValue("@profDerivante", DBNull.Value);

                if (!string.IsNullOrEmpty(tratamiento.Matricula))
                    cmd.Parameters.AddWithValue("@matricula", tratamiento.Matricula);
                else
                    cmd.Parameters.AddWithValue("@matricula", DBNull.Value);

                if (!string.IsNullOrEmpty(tratamiento.Especialidad))
                    cmd.Parameters.AddWithValue("@especialidad", tratamiento.Especialidad);
                else
                    cmd.Parameters.AddWithValue("@especialidad", DBNull.Value);

                if (!string.IsNullOrEmpty(tratamiento.DiagnosticoIngreso))
                    cmd.Parameters.AddWithValue("@diagnIngreso", tratamiento.DiagnosticoIngreso);
                else
                    cmd.Parameters.AddWithValue("@diagnIngreso", DBNull.Value);

                if (!string.IsNullOrEmpty(tratamiento.EvaluacionIngreso))
                    cmd.Parameters.AddWithValue("@evaIngreso", tratamiento.EvaluacionIngreso);
                else
                    cmd.Parameters.AddWithValue("@evaIngreso", DBNull.Value);

                if (!string.IsNullOrEmpty(tratamiento.DescripcionPlan))
                    cmd.Parameters.AddWithValue("@descrPlan", tratamiento.DescripcionPlan);
                else
                    cmd.Parameters.AddWithValue("@descrPlan", DBNull.Value);

                if (!string.IsNullOrEmpty(tratamiento.ObjetivoPlan))
                    cmd.Parameters.AddWithValue("@objPlan", tratamiento.ObjetivoPlan);
                else
                    cmd.Parameters.AddWithValue("@objPlan", DBNull.Value);

                cmd.Parameters.AddWithValue("@usrModificacion", tratamiento.UsuarioMod);
                cmd.Parameters.AddWithValue("@fechaModificacion", tratamiento.FechaMod);
                cmd.Parameters.AddWithValue("@idTratamiento", tratamiento.IdTratamiento);

                cmd.ExecuteNonQuery();

                trans.Commit();
                con.Close();

                return result;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }
        }

        
        public DataTable TraerTratamientoDetalle(string idTratamiento)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"SELECT 
                                        PROFESIONAL_DERIVANTE, 
                                        MATRICULA, 
                                        ESPECIALIDAD, 
                                        DIAGNOSTICO_INGRESO, 
                                        EVALUACION_INGRESO, 
                                        DESCRIPCION_PLAN, 
                                        OBJETIVO_PLAN, 
                                        CONSENTIMIENTO_FIRMADO
                                    FROM T_PLAN_TRATAMIENTO PT
                                    WHERE PT.ID_TRATAMIENTO = @idTratamiento ;";

                cmd = new SqlCommand(consulta, con);

                if (!string.IsNullOrEmpty(idTratamiento))
                    cmd.Parameters.AddWithValue("@idTratamiento", idTratamiento);

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

        public string CambiarEstadoConsentimiento(PlanTratamiento tratamiento)
        {
            try
            {
                string result = "OK";
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"update T_PLAN_TRATAMIENTO
                                        SET 
                                        CONSENTIMIENTO_FIRMADO = @consentimiento,
                                        USUARIO_MOD = @usrModificacion, FECHA_MOD = @fechaModificacion
                                        WHERE ID_TRATAMIENTO = @idTratamiento
                                    ;";

                cmd = new SqlCommand(consulta, con);

                cmd.Transaction = trans;


                cmd.Parameters.AddWithValue("@consentimiento", tratamiento.ConsentimientoFirmado);
                cmd.Parameters.AddWithValue("@usrModificacion", tratamiento.UsuarioMod);
                cmd.Parameters.AddWithValue("@fechaModificacion", tratamiento.FechaMod);
                cmd.Parameters.AddWithValue("@idTratamiento", tratamiento.IdTratamiento);

                cmd.ExecuteNonQuery();

                trans.Commit();
                con.Close();

                return result;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                con.Close();
                throw ex;
            }
        }

        public DataTable TraerDatosHCImprimir(string idTratamiento)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"                                    
                                    SELECT DISTINCT TOP 1   
                                        PT.CONSENTIMIENTO_FIRMADO,
	                                    (select distinct C.NOMBRE_CENTRO from T_CENTROS C
	                                        where c.ID_CENTRO = t.ID_CENTRO) as CENTRO,
                                        (SELECT distinct E.DESCRIPCION FROM T_ESPECIALIDADES E
                                            WHERE E.ID_ESPECIALIDADES = t.ID_ESPECIALIDAD
                                        ) as ESPECIALIDAD,
	                                    p.APELLIDO + ' ' + p.NOMBRE as PROFESIONAL,
	                                    P.DOCUMENTO as DOCUMENTO_PROFESIONAL,
	                                    P.NRO_MATRICULA as MATRICULA_PROFESIONAL,
	                                    (SELECT concat(os.DESCRIPCION, ' (', op.DESCRIPCION ,')') 
                                            FROM T_OBRAS_SOCIALES OS, T_OBRAS_PLANES OP
                                            WHERE os.ID_OBRA_SOCIAL = t.ID_OBRA_SOCIAL
                                            and os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL
                                            and op.ID_PLANES = t.ID_PLAN_OBRA) as OBRA_SOCIAL,
	                                    T.NRO_AFILIADO,
	                                    PA.APELLIDO,
	                                    PA.NOMBRE,
	                                    PA.DOCUMENTO,
	                                    PA.LOCALIDAD,
	                                    PA.NRO_CONTACTO,
	                                    PA.FECHA_NACIMIENTO,
	                                    PA.DOMICILIO,
                                        PT.PROFESIONAL_DERIVANTE, 
                                        PT.MATRICULA AS MATRICULA_DERIVANTE, 
                                        PT.ESPECIALIDAD AS ESPECIALIDAD_DERIVANTE, 
                                        HC.TENSION,
	                                    HC.TENSION_VALORES,
	                                    HC.DIABETES,
	                                    HC.FUMADOR,
	                                    HC.CARDIACO,
	                                    HC.CIRROSIS,
	                                    HC.ARTROSIS,
	                                    HC.ARTRITIS_REUMATOIDEA,
	                                    HC.HEMIPLEJIA,
	                                    HC.ASMA,
	                                    HC.MARCAPASOS,
	                                    HC.PROTESIS,
	                                    HC.CADERA_DERECHA,
	                                    HC.CADERA_IZQUIERDA,
	                                    HC.OTROS,
	                                    HC.ANTECEDENTES,
                                        PT.DIAGNOSTICO_INGRESO, 
                                        PT.EVALUACION_INGRESO, 
                                        PT.DESCRIPCION_PLAN, 
                                        PT.OBJETIVO_PLAN
                                    FROM T_PLAN_TRATAMIENTO PT
                                    INNER JOIN T_TURNOS T ON PT.ID_TRATAMIENTO = T.ID_PLAN_TRATAMIENTO
                                    INNER JOIN T_PACIENTES PA ON T.ID_PACIENTE = PA.ID_PACIENTE
                                    INNER JOIN T_HISTORIA_CLINICA HC ON PA.ID_HISTORIA = HC.ID_HISTORIA
                                    INNER JOIN T_PROFESIONALES P ON P.ID_PROFESIONAL= T.ID_PROFESIONAL
                                    INNER JOIN T_PROFESIONALES_DETALLE PD ON PD.ID_PROFESIONAL = P.ID_PROFESIONAL
                                        WHERE PT.ESTADO_PLAN != 'CANCELADO' 
                                            AND T.ESTADO != 'CANCELADO' 
		                                    AND PT.ID_TRATAMIENTO = @idTratamiento";

                cmd = new SqlCommand(consulta, con);

                if (!string.IsNullOrEmpty(idTratamiento))
                    cmd.Parameters.AddWithValue("@idTratamiento", idTratamiento);

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
