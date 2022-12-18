using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DADashboard
    {

        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;



        public List<object> traerCantidadTiposTurnosTotales(DateTime fecha_desde, DateTime fecha_hasta)
        {


            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT 'CANCELADO' AS 'ESTADO', ISNULL(COUNT (*),0) AS 'N_TURNOS', ISNULL(CAST((SELECT COUNT(*) FROM T_TURNOS WHERE " +
                    "FECHA_TURNO " +
                    "BETWEEN " +
                    "@fecha_desde AND @fecha_hasta AND ESTADO = 'CANCELADO') * 100 * 1.0 / NULLIF((SELECT COUNT(*)FROM T_TURNOS t WHERE FECHA_TURNO " +
                    " BETWEEN " +
                    "@fecha_desde AND @fecha_hasta),0) AS decimal(10, 2)),0) as 'PORCENTAJE' " +
                    "FROM T_TURNOS WHERE FECHA_TURNO BETWEEN @fecha_desde AND @fecha_hasta AND ESTADO = 'CANCELADO' " +
                    "union " +
                    "SELECT 'OTORGADO' AS 'ESTADO', ISNULL(count(*),0) AS 'N_TURNOS',ISNULL(CAST((SELECT COUNT(*)FROM T_TURNOS WHERE FECHA_TURNO " +
                    " BETWEEN @fecha_desde AND " +
                    "@fecha_hasta)*100*1.0 / NULLIF((SELECT COUNT(*)FROM T_TURNOS t WHERE FECHA_TURNO " +
                    "BETWEEN @fecha_desde AND @fecha_hasta),0 ) AS decimal(10, 2)),0) AS 'PORCENTAJE' " +
                    "FROM T_TURNOS WHERE FECHA_TURNO BETWEEN @fecha_desde AND @fecha_hasta " +
                    "UNION " +
                    "SELECT 'ATENDIDO' AS 'ESTADO', ISNULL(COUNT(*),0) AS 'N_TURNOS', ISNULL( CAST((SELECT COUNT(*)FROM T_TURNOS WHERE FECHA_TURNO " +
                    "BETWEEN @fecha_desde AND " +
                    "@fecha_hasta AND ESTADO = 'ATENDIDO')*100*1.0 / NULLIF((SELECT COUNT(*)FROM T_TURNOS t WHERE FECHA_TURNO BETWEEN @fecha_desde AND " +
                    "@fecha_hasta),0 )AS decimal(10, 2)),0) AS 'PORCENTAJE' " +
                    "FROM T_TURNOS WHERE FECHA_TURNO BETWEEN @fecha_desde AND @fecha_hasta AND ESTADO = 'ATENDIDO' ";



                //string consulta = "SELECT t.ESTADO as 'ESTADO', COUNT(*) AS 'N_TURNOS' " +
                //    "FROM T_TURNOS t WHERE FECHA_TURNO BETWEEN @fecha_desde AND @fecha_hasta group by t.ESTADO";

                cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<object> listaTurnosTotales = new List<object>();

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {

                        string estado = dr[0].ToString();
                        int n_turnos = Convert.ToInt32(dr[1]);
                        decimal porcentaje = Convert.ToDecimal(dr[2]);

                      

                        listaTurnosTotales.Add(estado);
                        listaTurnosTotales.Add(n_turnos);
                        listaTurnosTotales.Add(porcentaje);


                    }

                    return listaTurnosTotales;
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




        //public int obtenerCantTurnosSucursal(DateTime fecha_desde, DateTime fecha_hasta, int sucursal)
        //{
        //    try {


        //        string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
        //        con = new SqlConnection(cadenaDeConexion);
        //        con.Open();

        //        string consulta = "select count(*) as 'turno_sucursal' from t_turnos where " +
        //            "id_centro = @id_centro and fecha_turno between @fecha_desde and @fecha_hasta;";

        //        cmd = new SqlCommand(consulta, con);

        //        cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
        //        cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);
        //        cmd.Parameters.AddWithValue("@id_centro", sucursal);


        //        return Convert.ToInt32(cmd.ExecuteScalar());

        //    }
        //    catch(Exception e) {

        //       throw e;

        //    }
        //}

        public List<object> traerEspecialidadesMasDemandadas(DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();

                string consulta = "Select top 5 t.DESCRIPCION, t.cantidad, t.porcentaje from (select  r.DESCRIPCION, r.cantidad, r.cantidad*100*1.0/(select sum(r.cantidad)from (select  e.descripcion AS 'DESCRIPCION', count(*) as 'cantidad' from T_TURNOS t, T_ESPECIALIDADES e where t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and t.FECHA_TURNO between @fecha_desde and @fecha_hasta group by e.DESCRIPCION)r) as 'porcentaje' from(select  e.descripcion AS 'DESCRIPCION', count(*) as 'cantidad' from T_TURNOS t, T_ESPECIALIDADES e where t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and t.FECHA_TURNO between @fecha_desde and @fecha_hasta group by e.DESCRIPCION)r )T order by t.porcentaje desc;";


                cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<object> especialidadesMasDemandadas = new List<object>();

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {

                        string descripcion = dr[0].ToString();
                        int cantidad = Convert.ToInt32(dr[1]);
                        decimal porcentaje = Convert.ToDecimal(dr[2]);

                        especialidadesMasDemandadas.Add(descripcion);
                        especialidadesMasDemandadas.Add(cantidad);
                        especialidadesMasDemandadas.Add(porcentaje);

                    }


                    return especialidadesMasDemandadas;
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

        public List<object> traerEspecialidadesMenosDemandadas(DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();

                string consulta = "Select top 5 t.DESCRIPCION, t.cantidad, t.porcentaje from (select  r.DESCRIPCION, r.cantidad, r.cantidad*100*1.0/(select sum(r.cantidad)from (select  e.descripcion AS 'DESCRIPCION', count(*) as 'cantidad' from T_TURNOS t, T_ESPECIALIDADES e where t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and t.FECHA_TURNO between @fecha_desde and @fecha_hasta group by e.DESCRIPCION)r) as 'porcentaje' from(select  e.descripcion AS 'DESCRIPCION', count(*) as 'cantidad' from T_TURNOS t, T_ESPECIALIDADES e where t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and t.FECHA_TURNO between @fecha_desde and @fecha_hasta group by e.DESCRIPCION)r )T order by t.porcentaje asc;";


                cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<object> especialidadesMenosDemandadas = new List<object>();

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {

                        string descripcion = dr[0].ToString();
                        int cantidad = Convert.ToInt32(dr[1]);
                        decimal porcentaje = Convert.ToDecimal(dr[2]);

                        especialidadesMenosDemandadas.Add(descripcion);
                        especialidadesMenosDemandadas.Add(cantidad);
                        especialidadesMenosDemandadas.Add(porcentaje);

                    }


                    return especialidadesMenosDemandadas;
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


        public List<object> obtenerTiposObrasSocialesSparring(DateTime fecha_desde, DateTime fecha_hasta)

        {
            try
            {

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();

                string consulta = " select t.OBRA_SOCIAL, ISNULL(t.CANTIDAD,0), ISNULL(CAST( t.CANTIDAD*100*1.0/(select sum(t.CANTIDAD) " +
                    "from " +
                    "((SELECT 'PARTICULAR' AS[OBRA_SOCIAL], SUM(P.CANTIDAD) AS[CANTIDAD]FROM(SELECT os.DESCRIPCION, count(*) AS 'CANTIDAD' " +
                    "FROM " +
                    "T_OBRAS_PACIENTES op, T_OBRAS_SOCIALES os, T_TURNOS t where " +
                    "op.ID_PACIENTE = (SELECT t.ID_PACIENTE WHERE t.FECHA_TURNO between @fecha_desde and @fecha_hasta and estado = 'ATENDIDO') and " +
                    " os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL AND OS.DESCRIPCION = 'PARTICULAR' " +
                    "group by os.DESCRIPCION)P) " +
                    "UNION " +
                    "(SELECT 'OTRAS', SUM(X.CANTIDAD) as [cantidad] FROM(SELECT os.DESCRIPCION, count(*) AS 'CANTIDAD' FROM T_OBRAS_PACIENTES op," +
                    "T_OBRAS_SOCIALES os, T_TURNOS t where " +
                    "op.ID_PACIENTE = (SELECT t.ID_PACIENTE WHERE t.FECHA_TURNO between @fecha_desde and @fecha_hasta and estado = 'ATENDIDO') " +
                    "and os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL AND OS.DESCRIPCION != 'PARTICULAR' " +
                    "group by os.DESCRIPCION) X))T) AS DECIMAL(10,2)),0) as 'PORCENTAJE' " +
                    "from((SELECT 'PARTICULAR' AS[OBRA_SOCIAL], SUM(P.CANTIDAD) AS[CANTIDAD]FROM(SELECT os.DESCRIPCION, count(*) AS 'CANTIDAD' FROM " +
                    "T_OBRAS_PACIENTES op, T_OBRAS_SOCIALES os, T_TURNOS t where " +
                    "op.ID_PACIENTE = (SELECT t.ID_PACIENTE WHERE t.FECHA_TURNO between @fecha_desde and @fecha_hasta and estado = 'ATENDIDO') " +
                    "and os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL AND OS.DESCRIPCION = 'PARTICULAR' " +
                    "group by os.DESCRIPCION)P) " +
                    "UNION " +
                    "(SELECT 'OTRAS', SUM(X.CANTIDAD) as [cantidad] FROM(SELECT os.DESCRIPCION, count(*) AS 'CANTIDAD' FROM T_OBRAS_PACIENTES op, " +
                    "T_OBRAS_SOCIALES os, T_TURNOS t where " +
                    "op.ID_PACIENTE = (SELECT t.ID_PACIENTE WHERE t.FECHA_TURNO between @fecha_desde and @fecha_hasta and estado = 'ATENDIDO') " +
                    "and os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL AND OS.DESCRIPCION != 'PARTICULAR' " +
                    "group by os.DESCRIPCION) X))T";


                cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<object> tiposObraSocialSparring = new List<object>();

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {

                        string obra_social = dr[0].ToString();
                        int cantidad = Convert.ToInt32(dr[1]);
                        decimal porcentaje = Convert.ToDecimal(dr[2]);

                        //decimal porcentaje;
                        //if (dr[2] != DBNull.Value)
                        //{

                        //    porcentaje = Convert.ToDecimal(dr[2]);
                        //}
                        //else
                        //{

                        //    porcentaje = 0;

                        //}



                        tiposObraSocialSparring.Add(obra_social);
                        tiposObraSocialSparring.Add(cantidad);
                        tiposObraSocialSparring.Add(porcentaje);

                    }


                    return tiposObraSocialSparring;
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


        public List<object> obtenerTiposDeTurnosPorSucursal(DateTime fecha_desde, DateTime fecha_hasta)

        {
            try
            {

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();

                string consulta = @"(SELECT Q.NOMBRE_CENTRO, 
		                                        Q.ESTADO, 
		                                        Q.CANTIDAD, 
		                                        ISNULL(CAST
				                                        (
				                                        (SELECT Q.CANTIDAD*100*1.0/NULLIF((SELECT COUNT(*) 
					                                        from t_turnos t,T_CENTROS c 
					                                        where t.fecha_turno between @fecha_desde and @fecha_hasta 
					                                        and t.ID_CENTRO = c.ID_CENTRO AND Q.NOMBRE_CENTRO = C.NOMBRE_CENTRO
				                                        ),0)
			                                        ) AS DECIMAL(10,2)),0) AS 'PORCENTAJE' 
                                        FROM( 
	                                        SELECT 'CARLOS PAZ I' AS NOMBRE_CENTRO, 
			                                        ESTADO,
			                                        CP AS CANTIDAD
	                                        FROM
	                                        (
	                                        select COUNT(*) AS CP,
			                                        'ATENDIDO' AS ESTADO
			                                        from t_turnos t, T_CENTROS c 
			                                        where  t.fecha_turno between @fecha_desde and @fecha_hasta 
			                                        and t.ID_CENTRO = c.ID_CENTRO
			                                        AND C.NOMBRE_CENTRO = 'CARLOS PAZ I'
			                                        and t.ESTADO = 'ATENDIDO' 
	                                        UNION ALL
	                                        select COUNT(*) AS CP,
			                                        'CANCELADO' AS ESTADO
			                                        from t_turnos t, T_CENTROS c 
			                                        where  t.fecha_turno between @fecha_desde and @fecha_hasta 
			                                        and t.ID_CENTRO = c.ID_CENTRO
			                                        AND C.NOMBRE_CENTRO = 'CARLOS PAZ I'
			                                        and t.ESTADO = 'CANCELADO' 
	                                        UNION ALL
	                                        select COUNT(*) AS CP,
			                                        'OTORGADO' AS ESTADO
			                                        from t_turnos t, T_CENTROS c 
			                                        where  t.fecha_turno between @fecha_desde and @fecha_hasta 
			                                        and t.ID_CENTRO = c.ID_CENTRO
			                                        AND C.NOMBRE_CENTRO = 'CARLOS PAZ I'
	                                        ) A
                                        UNION ALL
	                                        SELECT 'CARLOS PAZ II' AS NOMBRE_CENTRO, 
			                                        ESTADO,
			                                        CP AS CANTIDAD
	                                        FROM
	                                        (
	                                        select COUNT(*) AS CP,
			                                        'ATENDIDO' AS ESTADO
			                                        from t_turnos t, T_CENTROS c 
			                                        where  t.fecha_turno between @fecha_desde and @fecha_hasta 
			                                        and t.ID_CENTRO = c.ID_CENTRO
			                                        AND C.NOMBRE_CENTRO = 'CARLOS PAZ II'
			                                        and t.ESTADO = 'ATENDIDO' 
	                                        UNION ALL
	                                        select COUNT(*) AS CP,
			                                        'CANCELADO' AS ESTADO
			                                        from t_turnos t, T_CENTROS c 
			                                        where  t.fecha_turno between @fecha_desde and @fecha_hasta 
			                                        and t.ID_CENTRO = c.ID_CENTRO
			                                        AND C.NOMBRE_CENTRO = 'CARLOS PAZ II'
			                                        and t.ESTADO = 'CANCELADO' 
	                                        UNION ALL
	                                        select COUNT(*) AS CP,
			                                        'OTORGADO' AS ESTADO
			                                        from t_turnos t, T_CENTROS c 
			                                        where  t.fecha_turno between @fecha_desde and @fecha_hasta 
			                                        and t.ID_CENTRO = c.ID_CENTRO
			                                        AND C.NOMBRE_CENTRO = 'CARLOS PAZ II'	
	                                        ) A
                                        UNION ALL
	                                        SELECT 'CORDOBA' AS NOMBRE_CENTRO, 
			                                        ESTADO,
			                                        CP AS CANTIDAD
	                                        FROM
	                                        (
	                                        select COUNT(*) AS CP,
			                                        'ATENDIDO' AS ESTADO
			                                        from t_turnos t, T_CENTROS c 
			                                        where  t.fecha_turno between @fecha_desde and @fecha_hasta 
			                                        and t.ID_CENTRO = c.ID_CENTRO
			                                        AND C.NOMBRE_CENTRO = 'CORDOBA'
			                                        and t.ESTADO = 'ATENDIDO' 
			
	                                        UNION ALL
	                                        select COUNT(*) AS CP,
			                                        'CANCELADO' AS ESTADO
			                                        from t_turnos t, T_CENTROS c 
			                                        where  t.fecha_turno between @fecha_desde and @fecha_hasta 
			                                        and t.ID_CENTRO = c.ID_CENTRO
			                                        AND C.NOMBRE_CENTRO = 'CORDOBA'
			                                        and t.ESTADO = 'CANCELADO' 
	                                        UNION ALL
	                                        select COUNT(*) AS CP,
			                                        'OTORGADO' AS ESTADO
			                                        from t_turnos t, T_CENTROS c 
			                                        where  t.fecha_turno between @fecha_desde and @fecha_hasta 
			                                        and t.ID_CENTRO = c.ID_CENTRO
			                                        AND C.NOMBRE_CENTRO = 'CORDOBA'
	                                        ) A
                                         )
                                        Q)";

                //string consulta = "(SELECT Q.NOMBRE_CENTRO, Q.ESTADO, Q.CANTIDAD, ISNULL(CAST((SELECT Q.CANTIDAD*100*1.0/NULLIF((SELECT COUNT(*) " +
                //                    "from t_turnos t,T_CENTROS c " +
                //                    "where t.fecha_turno between @fecha_desde and @fecha_hasta and t.ID_CENTRO = c.ID_CENTRO AND Q.NOMBRE_CENTRO = " +
                //                    "C.NOMBRE_CENTRO),0)) AS " +
                //                    "DECIMAL(10,2)),0) AS 'PORCENTAJE' " +
                //                    "FROM( " +
                //                    "select c.NOMBRE_CENTRO, 'OTORGADO' AS 'ESTADO', count(*) as 'CANTIDAD' " +
                //                    "from " +
                //                    "t_turnos t, T_CENTROS c " +
                //                    "where  t.fecha_turno between @fecha_desde and @fecha_hasta and t.ID_CENTRO = c.ID_CENTRO " +
                //                    "group by c.NOMBRE_CENTRO " +
                //                    "UNION " +
                //                    "select c.NOMBRE_CENTRO, 'CANCELADO' AS 'ESTADO', count(*) as 'CANTIDAD' " +
                //                    "from t_turnos t, T_CENTROS c " +
                //                    "where  t.fecha_turno between @fecha_desde and @fecha_hasta and t.ID_CENTRO = c.ID_CENTRO " +
                //                    "and t.ESTADO = 'CANCELADO' " +
                //                    "group by c.NOMBRE_CENTRO " +
                //                    "UNION " +
                //                    "select c.NOMBRE_CENTRO, 'ATENDIDO' AS 'ESTADO', count(*) as 'CANTIDAD' " +
                //                    "from t_turnos t, T_CENTROS c " +
                //                    "where  t.fecha_turno between @fecha_desde and @fecha_hasta and t.ID_CENTRO = c.ID_CENTRO " +
                //                    "and t.ESTADO = 'ATENDIDO' " +
                //                    "group by c.NOMBRE_CENTRO " +
                //                    ")Q) ";


                cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<object> cantTurnosPorSucursal = new List<object>();

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {

                        string nombre_centro = dr[0].ToString();
                        string estado_turno = dr[1].ToString();
                        int cantidad = Convert.ToInt32(dr[2]);
                        decimal porcentaje = Convert.ToDecimal(dr[3]);

                        cantTurnosPorSucursal.Add(nombre_centro);
                        cantTurnosPorSucursal.Add(estado_turno);
                        cantTurnosPorSucursal.Add(cantidad);
                        cantTurnosPorSucursal.Add(porcentaje);

                    }


                    return cantTurnosPorSucursal;
                }

                else {

                    return null;
                
                }

              

            }
            catch (Exception e)
            {
                throw e;

            }

        }

        public List<object> obtenerEspMasDemandadaPorSuc(DateTime fecha_desde, DateTime fecha_hasta)

        {
            try
            {

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();

                string consulta = "select TOP 3 x.NOMBRE_CENTRO, x.DESCRIPCION,x.cantidad,CAST( x.cantidad*100*1.0/(select COUNT(*) from T_CENTROS c," +
                    "T_TURNOS t, T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 1 and t.ID_CENTRO = 1) AS decimal " +
                    "(10, 2)) as 'porcetaje '" +
                    "from(select c.NOMBRE_CENTRO, e.DESCRIPCION, count(*) as cantidad  from T_CENTROS c, T_TURNOS t, T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO  between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 1 and t.ID_CENTRO = 1 " +
                    "group by c.NOMBRE_CENTRO, e.DESCRIPCION)x " +
                    "union " +
                    "select TOP 3 x.NOMBRE_CENTRO, x.DESCRIPCION,x.cantidad,CAST(x.cantidad * 100 * 1.0 / (select COUNT(*) from T_CENTROS c, T_TURNOS t, " +
                    "T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO  between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 2 and t.ID_CENTRO = 2) AS  decimal " +
                    "(10, 2)) as 'porcetaje' " +
                    "from(select c.NOMBRE_CENTRO, e.DESCRIPCION, count(*) as cantidad  from T_CENTROS c, T_TURNOS t, T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO  between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 2 and t.ID_CENTRO = 2 " +
                    "group by c.NOMBRE_CENTRO, e.DESCRIPCION)x " +
                    "UNION " +
                    "select TOP 3 x.NOMBRE_CENTRO, x.DESCRIPCION,x.cantidad,CAST(x.cantidad * 100 * 1.0 / (select COUNT(*) from T_CENTROS c, T_TURNOS t, " +
                    "T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO  between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 3 and t.ID_CENTRO = 3) AS  decimal " +
                    "(10, 2)) as 'porcetaje' " +
                    "from(select c.NOMBRE_CENTRO, e.DESCRIPCION, count(*) as cantidad  from T_CENTROS c, T_TURNOS t, T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO  between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 3 and t.ID_CENTRO = 3 " +
                    "group by c.NOMBRE_CENTRO, e.DESCRIPCION)x " +
                    "ORDER BY X.NOMBRE_CENTRO, X.cantidad DESC";


                cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<object> especialidadMasDemandadaPorSucursal = new List<object>();

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {

                        string nombre_centro = dr[0].ToString();
                        string descripcion = dr[1].ToString();
                        int cantidad = Convert.ToInt32(dr[2]);
                        decimal porcentaje = Convert.ToDecimal(dr[3]);

                        especialidadMasDemandadaPorSucursal.Add(nombre_centro);
                        especialidadMasDemandadaPorSucursal.Add(descripcion);
                        especialidadMasDemandadaPorSucursal.Add(cantidad);
                        especialidadMasDemandadaPorSucursal.Add(porcentaje);

                    }


                    return especialidadMasDemandadaPorSucursal;
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


        public List<object> obtenerEspMenosDemandadaPorSuc(DateTime fecha_desde, DateTime fecha_hasta)

        {
            try
            {

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                con.Open();

                string consulta = "select TOP 3 x.NOMBRE_CENTRO, x.DESCRIPCION,x.cantidad,CAST( x.cantidad*100*1.0/(select COUNT(*) from T_CENTROS c," +
                    "T_TURNOS t, T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 1 and t.ID_CENTRO = 1) AS decimal " +
                    "(10, 2)) as 'porcetaje '" +
                    "from(select c.NOMBRE_CENTRO, e.DESCRIPCION, count(*) as cantidad  from T_CENTROS c, T_TURNOS t, T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO  between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 1 and t.ID_CENTRO = 1 " +
                    "group by c.NOMBRE_CENTRO, e.DESCRIPCION)x " +
                    "union " +
                    "select TOP 3 x.NOMBRE_CENTRO, x.DESCRIPCION,x.cantidad,CAST(x.cantidad * 100 * 1.0 / (select COUNT(*) from T_CENTROS c, T_TURNOS t, " +
                    "T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO  between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 2 and t.ID_CENTRO = 2) AS  decimal " +
                    "(10, 2)) as 'porcetaje' " +
                    "from(select c.NOMBRE_CENTRO, e.DESCRIPCION, count(*) as cantidad  from T_CENTROS c, T_TURNOS t, T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO  between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 2 and t.ID_CENTRO = 2 " +
                    "group by c.NOMBRE_CENTRO, e.DESCRIPCION)x " +
                    "UNION " +
                    "select TOP 3 x.NOMBRE_CENTRO, x.DESCRIPCION,x.cantidad,CAST(x.cantidad * 100 * 1.0 / (select COUNT(*) from T_CENTROS c, T_TURNOS t, " +
                    "T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO  between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 3 and t.ID_CENTRO = 3) AS  decimal " +
                    "(10, 2)) as 'porcetaje' " +
                    "from(select c.NOMBRE_CENTRO, e.DESCRIPCION, count(*) as cantidad  from T_CENTROS c, T_TURNOS t, T_ESPECIALIDADES e " +
                    "where t.FECHA_TURNO  between @fecha_desde and @fecha_hasta and t.ID_ESPECIALIDAD = e.ID_ESPECIALIDADES and c.ID_CENTRO = 3 and t.ID_CENTRO = 3 " +
                    "group by c.NOMBRE_CENTRO, e.DESCRIPCION)x " +
                    "ORDER BY X.NOMBRE_CENTRO, X.cantidad asc";


                cmd = new SqlCommand(consulta, con);

                cmd.Parameters.AddWithValue("@fecha_desde", fecha_desde);
                cmd.Parameters.AddWithValue("@fecha_hasta", fecha_hasta);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<object> especialidadMenosDemandadaPorSucursal = new List<object>();

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow dr in dt.Rows)
                    {

                        string nombre_centro = dr[0].ToString();
                        string descripcion = dr[1].ToString();
                        int cantidad = Convert.ToInt32(dr[2]);
                        decimal porcentaje = Convert.ToDecimal(dr[3]);

                        especialidadMenosDemandadaPorSucursal.Add(nombre_centro);
                        especialidadMenosDemandadaPorSucursal.Add(descripcion);
                        especialidadMenosDemandadaPorSucursal.Add(cantidad);
                        especialidadMenosDemandadaPorSucursal.Add(porcentaje);

                    }


                    return especialidadMenosDemandadaPorSucursal;
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






