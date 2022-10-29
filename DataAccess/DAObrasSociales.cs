using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DAObrasSociales
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public List<ObraSocial> traerObrasSociales()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"select  os.ID_OBRA_SOCIAL,
                                            os.DESCRIPCION
                                        from t_obras_sociales os
                                        where os.fecha_baja is null                                        
                                        ;";
                //and os.id_centro = @idCentro

                cmd = new SqlCommand(consulta, con);

                //if (!string.IsNullOrEmpty(id_Centro))
                //    cmd.Parameters.AddWithValue("@idCentro", id_Centro);
                //else
                //    cmd.Parameters.AddWithValue("@idCentro", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<ObraSocial> listaObrasSociales = new List<ObraSocial>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ObraSocial obraSocial = new ObraSocial();
                        if (dr["ID_OBRA_SOCIAL"] != DBNull.Value)
                            obraSocial.IdObraSocial = Convert.ToInt32(dr["ID_OBRA_SOCIAL"]);
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            obraSocial.Descripcion = Convert.ToString(dr["DESCRIPCION"]);
                        
                        //if (dr["USUARIO_ALTA"] != DBNull.Value)
                        //    obraSocial.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        //if (dr["FECHA_ALTA"] != DBNull.Value)
                        //    obraSocial.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        //if (dr["USUARIO_MOD"] != DBNull.Value)
                        //    obraSocial.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        //if (dr["FECHA_MOD"] != DBNull.Value)
                        //    obraSocial.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        //if (dr["USUARIO_BAJA"] != DBNull.Value)
                        //    obraSocial.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        //if (dr["FECHA_BAJA"] != DBNull.Value)
                        //    obraSocial.FechaMod = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        listaObrasSociales.Add(obraSocial);

                    }

                    return listaObrasSociales;
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


        public List<ObraSocial> cargarObrasSocialesPaciente(string idPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT os.ID_OBRA_SOCIAL, 
                                           os.DESCRIPCION
                                      FROM t_pacientes p, T_OBRAS_PACIENTES op, T_OBRAS_SOCIALES os, T_OBRAS_PLANES opl
                                     WHERE p.ID_PACIENTE = op.ID_PACIENTE
                                       AND os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL
									   AND op.ID_PLAN = opl.ID_PLANES
                                       AND p.FECHA_BAJA IS NULL
                                       AND op.FECHA_BAJA IS NULL
                                       AND os.FECHA_BAJA IS NULL
									   AND opl.FECHA_BAJA IS NULL
                                       AND p.ID_PACIENTE = @ID_PACIENTE";

            

                cmd = new SqlCommand(consulta, con);

                if (!string.IsNullOrEmpty(idPaciente))
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", idPaciente);
                else
                    cmd.Parameters.AddWithValue("@ID_PACIENTE", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<ObraSocial> listaObrasSociales = new List<ObraSocial>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ObraSocial obraSocial = new ObraSocial();
                        if (dr["ID_OBRA_SOCIAL"] != DBNull.Value)
                            obraSocial.IdObraSocial = Convert.ToInt32(dr["ID_OBRA_SOCIAL"]);
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            obraSocial.Descripcion = Convert.ToString(dr["DESCRIPCION"]);
                                 

                        listaObrasSociales.Add(obraSocial);

                    }

                    return listaObrasSociales;
                }
                else
                {
                    return listaObrasSociales;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DarBajaObraSocial(ObraSocial obraSocial)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE t_obras_sociales " +
                                        "SET USUARIO_BAJA = @USUARIO_BAJA, " +
                                            "FECHA_BAJA = @FECHA_BAJA " +
                                    "WHERE ID_OBRA_SOCIAL = @idObraSocial;";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@idObraSocial", obraSocial.IdObraSocial);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", obraSocial.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", obraSocial.FechaBaja);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable TraerPlanes(string idObraSocial)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"SELECT * FROM T_OBRAS_PLANES
                                        WHERE ID_OBRA_SOCIAL = @idObraSocial
                                          AND FECHA_BAJA IS NULL"; /*CONSULTAR A GAS SI GENERA PROBLEMAS EN OTRO LADO*/

                cmd = new SqlCommand(consulta, con);

                if (!String.IsNullOrEmpty(idObraSocial))
                    cmd.Parameters.AddWithValue("@idObraSocial", idObraSocial);
                else
                    cmd.Parameters.AddWithValue("@idObraSocial", DBNull.Value);

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


        public DataTable cargarPlanesPacientes(string idObraSocial, string idPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"SELECT opl.ID_PLANES, 
                                           opl.DESCRIPCION, 
                                           op.NRO_AFILIADO
                                      FROM t_pacientes p, 
                                           T_OBRAS_PACIENTES op, 
                                           T_OBRAS_PLANES opl
                                     WHERE p.ID_PACIENTE = op.ID_PACIENTE
                                       AND opl.ID_PLANES = op.ID_PLAN
                                       AND p.FECHA_BAJA IS NULL
                                       AND op.FECHA_BAJA IS NULL
                                       AND opl.FECHA_BAJA IS NULL
                                       AND p.ID_PACIENTE = @idPaciente
                                       AND opl.ID_OBRA_SOCIAL = @idObraSocial"; /*CONSULTAR A GAS SI GENERA PROBLEMAS EN OTRO LADO*/

                cmd = new SqlCommand(consulta, con);

                if (!String.IsNullOrEmpty(idObraSocial))
                    cmd.Parameters.AddWithValue("@idObraSocial", idObraSocial);
                else
                    cmd.Parameters.AddWithValue("@idObraSocial", DBNull.Value);

                if (!String.IsNullOrEmpty(idPaciente))
                    cmd.Parameters.AddWithValue("@idPaciente", idPaciente);
                else
                    cmd.Parameters.AddWithValue("@idPaciente", DBNull.Value);

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

        public void DarBajaPlan(ObrasPlanes plan)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_OBRAS_PLANES " +
                                        "SET USUARIO_BAJA = @USUARIO_BAJA, " +
                                            "FECHA_BAJA = @FECHA_BAJA " +
                                    "WHERE ID_PLANES = @idPlan;";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@idPlan", plan.IdPlanes);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", plan.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", plan.FechaBaja);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AgregarPlan(ObrasPlanes plan)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "insert into T_OBRAS_PLANES " +
                    "(DESCRIPCION, ID_OBRA_SOCIAL, USUARIO_ALTA, FECHA_ALTA) " +
                    "values (@descripcion, @idObraSocial, @usrAlta, @fechaAlta);";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@descripcion", plan.Descripcion);
                cmd.Parameters.AddWithValue("@idObraSocial", plan.IdObraSocial);
                cmd.Parameters.AddWithValue("@usrAlta", plan.UsuarioAlta);
                cmd.Parameters.AddWithValue("@fechaAlta", plan.FechaAlta);


                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AgregarObraSocial(ObraSocial obraSocial)
        {       
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "insert into T_OBRAS_SOCIALES " +
                    "(DESCRIPCION, USUARIO_ALTA, FECHA_ALTA) " +
                    "values (@descripcion, @usrAlta, @fechaAlta);";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@descripcion", obraSocial.Descripcion);
                cmd.Parameters.AddWithValue("@usrAlta", obraSocial.UsuarioAlta);
                cmd.Parameters.AddWithValue("@fechaAlta", obraSocial.FechaAlta);
                cmd.Parameters.AddWithValue("@idCentro", obraSocial.Centro.IdCentro);            

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //public List<ObraSocial> obtenerOSPacientes()
        //{
        //    try
        //    {
        //        string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
        //        con = new SqlConnection(cadenaDeConexion);

        //        string consulta = @"SELECT ID_OBRA_SOCIAL, 
	       //                                DESCRIPCION
        //                              FROM T_OBRAS_SOCIALES OS, T_CENTROS C
        //                             WHERE OS.FECHA_BAJA IS NULL
        //                               AND C.FECHA_BAJA IS NULL
        //                             ORDER BY DESCRIPCION;";
            

        //        cmd = new SqlCommand(consulta, con);
          
        //        dta = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        dta.Fill(dt);

        //        List<ObraSocial> listaObrasSociales = new List<ObraSocial>();

        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                ObraSocial obraSocial = new ObraSocial();
        //                if (dr["ID_OBRA_SOCIAL"] != DBNull.Value)
        //                    obraSocial.IdObraSocial = Convert.ToInt32(dr["ID_OBRA_SOCIAL"]);
        //                if (dr["DESCRIPCION"] != DBNull.Value)
        //                    obraSocial.Descripcion = Convert.ToString(dr["DESCRIPCION"]);
                    
        //                listaObrasSociales.Add(obraSocial);
        //            }

        //            return listaObrasSociales;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}


        public List<ObraSocial> obtenerOSxPaciente(string idPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT ID_OBRA_SOCIAL, 
	                                       DESCRIPCION
                                      FROM T_OBRAS_SOCIALES OS
                                     WHERE OS.FECHA_BAJA IS NULL
                                       AND C.FECHA_BAJA IS NULL
                                    EXCEPT
                                    SELECT os.ID_OBRA_SOCIAL, 
	                                       OS.DESCRIPCION
                                      FROM T_OBRAS_SOCIALES OS,
                                           T_OBRAS_PACIENTES OP, 
                                           T_OBRAS_PLANES OPL
                                     WHERE OS.ID_OBRA_SOCIAL = OP.ID_OBRA_SOCIAL
                                       AND OP.ID_PLAN =  OPL.ID_PLANES
                                       AND OP.ID_PACIENTE = @ID_PACIENTE                                       
                                       AND OP.FECHA_BAJA IS NULL
                                     ORDER BY DESCRIPCION;";


                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@ID_PACIENTE", idPaciente);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<ObraSocial> listaObrasSociales = new List<ObraSocial>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ObraSocial obraSocial = new ObraSocial();
                        if (dr["ID_OBRA_SOCIAL"] != DBNull.Value)
                            obraSocial.IdObraSocial = Convert.ToInt32(dr["ID_OBRA_SOCIAL"]);
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            obraSocial.Descripcion = Convert.ToString(dr["DESCRIPCION"]);

                        listaObrasSociales.Add(obraSocial);
                    }

                    return listaObrasSociales;
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

        public List<ObraSocial> obtenerOSePaciente(string idObraPaciente)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT OS.ID_OBRA_SOCIAL, 
                                           OS.DESCRIPCION DESCRIPCION
                                      FROM T_OBRAS_SOCIALES OS, 
                                           T_OBRAS_PACIENTES OP, 
                                           T_OBRAS_PLANES OPL
                                     WHERE OS.ID_OBRA_SOCIAL = OP.ID_OBRA_SOCIAL
                                       AND OP.ID_PLAN =  OPL.ID_PLANES
                                       AND OP.ID_OBRA_PACIENTE = @ID_OBRA_PACIENTE
                                       AND OS.FECHA_BAJA IS NULL
                                       AND C.FECHA_BAJA IS NULL
                                       AND OP.FECHA_BAJA IS NULL;";


                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@ID_OBRA_PACIENTE", idObraPaciente);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<ObraSocial> listaObrasSociales = new List<ObraSocial>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ObraSocial obraSocial = new ObraSocial();
                        if (dr["ID_OBRA_SOCIAL"] != DBNull.Value)
                            obraSocial.IdObraSocial = Convert.ToInt32(dr["ID_OBRA_SOCIAL"]);
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            obraSocial.Descripcion = Convert.ToString(dr["DESCRIPCION"]);

                        listaObrasSociales.Add(obraSocial);
                    }

                    return listaObrasSociales;
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

        public ObraSocial traerObraSocialById(string idObraSocial)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"select  os.ID_OBRA_SOCIAL,
                                            os.DESCRIPCION
                                        from t_obras_sociales os
                                        where os.fecha_baja is null
                                          and os.id_obra_social = @idObraSocial
                                        ;";


                cmd = new SqlCommand(consulta, con);

                if (!string.IsNullOrEmpty(idObraSocial))
                    cmd.Parameters.AddWithValue("@idObraSocial", idObraSocial);
                else
                    cmd.Parameters.AddWithValue("@idObraSocial", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                ObraSocial obraSocial = new ObraSocial();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows) { 
                        if (dr["ID_OBRA_SOCIAL"] != DBNull.Value)
                        obraSocial.IdObraSocial = Convert.ToInt32(dr["ID_OBRA_SOCIAL"]);
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            obraSocial.Descripcion = Convert.ToString(dr["DESCRIPCION"]);
                    }

                    return obraSocial;

                } else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ObrasPlanes traerPlanObraById(string idPlanObraSocial)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"select  ID_PLANES,
                                            COD_PLAN,
                                            DESCRIPCION
                                        from T_OBRAS_PLANES 
                                        where fecha_baja is null
                                          and ID_PLANES = @idPlanObraSocial
                                        ;";


                cmd = new SqlCommand(consulta, con);

                if (!string.IsNullOrEmpty(idPlanObraSocial))
                    cmd.Parameters.AddWithValue("@idPlanObraSocial", idPlanObraSocial);
                else
                    cmd.Parameters.AddWithValue("@idPlanObraSocial", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                ObrasPlanes planObraSocial = new ObrasPlanes();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["ID_PLANES"] != DBNull.Value)
                            planObraSocial.IdObraSocial = Convert.ToInt32(dr["ID_PLANES"]);
                        if (dr["COD_PLAN"] != DBNull.Value)
                            planObraSocial.CodPlan = dr["COD_PLAN"].ToString();
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            planObraSocial.Descripcion = Convert.ToString(dr["DESCRIPCION"]);
                    }

                    return planObraSocial;

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
