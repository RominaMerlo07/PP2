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
                                        FROM t_pacientes p, T_OBRAS_PACIENTES op, T_OBRAS_SOCIALES os
                                        WHERE p.ID_PACIENTE = op.ID_PACIENTE
                                        AND os.ID_OBRA_SOCIAL = op.ID_OBRA_SOCIAL
                                        AND p.FECHA_BAJA IS NULL
                                        AND op.FECHA_BAJA IS NULL
                                        AND os.FECHA_BAJA IS NULL
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
                                          AND FECHA_BAJA IS NULL";

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

                string consulta = "INSERT INTO T_OBRAS_SOCIALES " +
                                            "(DESCRIPCION, USUARIO_ALTA, FECHA_ALTA) " +
                                     "VALUES (@descripcion, @usrAlta, @fechaAlta);";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@descripcion", obraSocial.Descripcion);
                cmd.Parameters.AddWithValue("@usrAlta", obraSocial.UsuarioAlta);
                cmd.Parameters.AddWithValue("@fechaAlta", obraSocial.FechaAlta);
               // cmd.Parameters.AddWithValue("@idCentro", obraSocial.Centro.IdCentro);            

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
                                    EXCEPT
                                    SELECT OS.ID_OBRA_SOCIAL, 
	                                       OS.DESCRIPCION
                                      FROM T_OBRAS_SOCIALES OS,
                                           T_OBRAS_PACIENTES OP, 
                                           T_OBRAS_PLANES OPL
                                     WHERE OS.ID_OBRA_SOCIAL = OP.ID_OBRA_SOCIAL
                                       AND OP.ID_PLAN =  OPL.ID_PLANES
                                       AND OP.ID_PACIENTE = @ID_PACIENTE                                       
                                       AND OP.FECHA_BAJA IS NULL
                                    UNION
                                    SELECT ID_OBRA_SOCIAL, 
	                                       DESCRIPCION
                                      FROM T_OBRAS_SOCIALES OS
                                     WHERE OS.FECHA_BAJA IS NULL
                                    EXCEPT
                                    SELECT OS.ID_OBRA_SOCIAL, 
	                                       OS.DESCRIPCION
                                      FROM T_OBRAS_SOCIALES OS,
                                           T_OBRAS_PACIENTES OP
                                     WHERE OS.ID_OBRA_SOCIAL = OP.ID_OBRA_SOCIAL
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

        public int validarObraSocial(string obraSocial)
        {
            int devolver = 0;

            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "SELECT count(*) " +
                                    "FROM T_OBRAS_SOCIALES " +
                                    "WHERE DESCRIPCION = @OBRA_SOCIAL " +
                                    "AND FECHA_BAJA is null; ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@OBRA_SOCIAL", obraSocial);

                devolver = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }

            return devolver;

        }

        public ObraSocial cargarObrasSociales(int idObraSocial)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_OBRAS_SOCIALES " +
                                    "WHERE ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL " +
                                    "AND FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);

                if (idObraSocial != 0)
                    cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", idObraSocial);
                else
                    cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                ObraSocial obraSocial = new ObraSocial();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        if (dr["ID_OBRA_SOCIAL"] != DBNull.Value)
                            obraSocial.IdObraSocial = Convert.ToInt32(dr["ID_OBRA_SOCIAL"]);
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            obraSocial.Descripcion = Convert.ToString(dr["DESCRIPCION"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            obraSocial.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            obraSocial.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            obraSocial.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            obraSocial.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            obraSocial.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            obraSocial.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);

                    }

                    return obraSocial;
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

        public string editarObraSocial(ObraSocial obraSocial)
        {
            try
            {
                string resultado = "OK";

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_OBRAS_SOCIALES " +
                                     "SET DESCRIPCION = @DESCRIPCION, FECHA_MOD = @FECHA_MOD, USUARIO_MOD = @USUARIO_MOD " +
                                     "WHERE ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL; ";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(obraSocial.Descripcion))
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obraSocial.Descripcion);
                else
                    cmd.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value);


                cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", obraSocial.IdObraSocial);
                cmd.Parameters.AddWithValue("@USUARIO_MOD", obraSocial.UsuarioMod);
                cmd.Parameters.AddWithValue("@FECHA_MOD", obraSocial.FechaMod);

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


        public int validarPlan(int id_obraSocial, string plan)
        {
            int devolver = 0;

            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "SELECT COUNT(*) FROM T_OBRAS_SOCIALES O, T_OBRAS_PLANES P " +
                                   "WHERE O.ID_OBRA_SOCIAL = P.ID_OBRA_SOCIAL " +
                                     "AND O.FECHA_BAJA IS NULL " +
                                     "AND P.FECHA_BAJA IS NULL " +
                                     "AND O.ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL " +
                                     "AND P.DESCRIPCION = @PLAN; ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", id_obraSocial);
                cmd.Parameters.AddWithValue("@PLAN", plan);

                devolver = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

            }
            catch (Exception e)
            {
                con.Close();
                throw e;
            }

            return devolver;

        }


        public DataTable TraerPlanesAll(string idObraSocial)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);
                string consulta = @"SELECT * FROM T_OBRAS_PLANES
                                        WHERE ID_OBRA_SOCIAL = @idObraSocial
                                        ORDER BY FECHA_BAJA ASC;";

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


        public ObrasPlanes cargarPlan(int idPlan)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_OBRAS_PLANES " +
                                    "WHERE ID_PLANES = @ID_PLANES " +
                                    "AND FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);

                if (idPlan != 0)
                    cmd.Parameters.AddWithValue("@ID_PLANES", idPlan);
                else
                    cmd.Parameters.AddWithValue("@ID_PLANES", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                ObrasPlanes obrasPlanes = new ObrasPlanes();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {

                        if (dr["ID_PLANES"] != DBNull.Value)
                            obrasPlanes.IdPlanes = Convert.ToInt32(dr["ID_PLANES"]);
                        if (dr["DESCRIPCION"] != DBNull.Value)
                            obrasPlanes.Descripcion = Convert.ToString(dr["DESCRIPCION"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            obrasPlanes.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            obrasPlanes.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            obrasPlanes.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            obrasPlanes.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            obrasPlanes.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            obrasPlanes.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);

                    }

                    return obrasPlanes;
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


        public string editarPlan(ObrasPlanes obrasPlanes)
        {
            try
            {
                string resultado = "OK";

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_OBRAS_PLANES " +
                                     "SET DESCRIPCION = @DESCRIPCION, FECHA_MOD = @FECHA_MOD, USUARIO_MOD = @USUARIO_MOD " +
                                     "WHERE ID_PLANES = @ID_PLANES; ";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(obrasPlanes.Descripcion))
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obrasPlanes.Descripcion);
                else
                    cmd.Parameters.AddWithValue("@DESCRIPCION", DBNull.Value);


                cmd.Parameters.AddWithValue("@ID_PLANES", obrasPlanes.IdPlanes);
                cmd.Parameters.AddWithValue("@USUARIO_MOD", obrasPlanes.UsuarioMod);
                cmd.Parameters.AddWithValue("@FECHA_MOD", obrasPlanes.FechaMod);

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


        public int TurnosFuturos(int idObraSocial)
        {

            int devolver = 0;

            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "SELECT COUNT(*) CANTIDAD " +
                                    "FROM T_TURNOS T, T_OBRAS_SOCIALES O " +
                                    "WHERE T.ID_OBRA_SOCIAL = O.ID_OBRA_SOCIAL " +
                                    "AND O.ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL " +
                                    "AND T.ESTADO = 'OTORGADO' " +
                                    "AND T.FECHA_BAJA IS NULL " +
                                    "AND O.FECHA_BAJA IS NULL " +
                                    "AND T.FECHA_TURNO > GETDATE(); ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", idObraSocial);

                devolver = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

            }
            catch (Exception e)
            {

                con.Close();
                throw e;

            }

            return devolver;

        }


        public DataTable ObtenerTurnosFuturos(int idObraSocial)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT CONVERT(varchar,T.FECHA_TURNO,103) TURNO, 
	                                        SUBSTRING ((CONVERT(varchar,T.HORA_DESDE,8)),0,6) as HORA, 
	                                        CONCAT (P.NOMBRE, ' ', P.APELLIDO) PACIENTE, 
	                                        P.NRO_CONTACTO,
	                                        P.EMAIL_CONTACTO
                                        FROM T_TURNOS T, T_OBRAS_SOCIALES O, T_PACIENTES P
                                        WHERE T.ID_OBRA_SOCIAL = O.ID_OBRA_SOCIAL
                                        AND T.ID_PACIENTE = P.ID_PACIENTE
                                        AND O.ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL
                                        AND T.ESTADO = 'OTORGADO'
                                        AND T.FECHA_BAJA IS NULL
                                        AND O.FECHA_BAJA IS NULL
                                        AND T.FECHA_TURNO > GETDATE();";

                cmd = new SqlCommand(consulta, con);
                cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", idObraSocial);

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

        public string DaDarDeBajaTurnos(int idObraSocial, int usuarioBaja)
        {

            string resultado = "OK";
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_TURNOS " +
                                     "SET FECHA_BAJA = GETDATE(), ESTADO = 'CANCELADO', USUARIO_BAJA = @USUARIO_BAJA " +
                                     "WHERE ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL " +
                                     "AND FECHA_TURNO > GETDATE(); ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", idObraSocial);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", usuarioBaja);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                resultado = "OK";

            }
            catch (Exception e)
            {

                resultado = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;

            }

            return resultado;

        }


        public string darBajaObraSocial(ObraSocial obraSocial)
        {


            string resultado = "OK";
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_OBRAS_SOCIALES " +
                                     "SET USUARIO_BAJA = @USUARIO_BAJA, FECHA_BAJA = @FECHA_BAJA " +
                                     "WHERE ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL;";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", obraSocial.IdObraSocial);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", obraSocial.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", obraSocial.FechaBaja);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                resultado = "OK";

            }
            catch (Exception e)
            {

                resultado = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;

            }

            return resultado;

        }


        public string darBajaObraSocialPaciente(ObraSocial obraSocial)
        {


            string resultado = "OK";
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_OBRAS_PACIENTES " +
                                     "SET USUARIO_BAJA = @USUARIO_BAJA, FECHA_BAJA = @FECHA_BAJA " +
                                     "WHERE ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL " +
                                     "AND FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", obraSocial.IdObraSocial);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", obraSocial.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", obraSocial.FechaBaja);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                resultado = "OK";

            }
            catch (Exception e)
            {

                resultado = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;

            }

            return resultado;

        }

        public int obtenerTratamientos(int idObraSocial)
        {
            int devolver = 0;

            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"SELECT COUNT(DISTINCT ID_PLAN_TRATAMIENTO) CANTIDAD
                                      FROM T_TURNOS T, T_PLAN_TRATAMIENTO P
                                     WHERE T.ID_PLAN_TRATAMIENTO = P.ID_TRATAMIENTO
                                       AND ESTADO_PLAN = 'EN CURSO'
                                       AND ID_PLAN_TRATAMIENTO IS NOT NULL
                                       AND T.FECHA_BAJA IS NULL
                                       AND P.FECHA_BAJA IS NULL
                                       AND T.FECHA_TURNO >= GETDATE()
                                       AND T.ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL;";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", idObraSocial);

                devolver = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

            }
            catch (Exception e)
            {

                con.Close();
                throw e;

            }

            return devolver;
        }


        public string DarBajaTratamiento(int idObraSocial, int usuarioBaja)
        {

            string resultado = "OK";
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_PLAN_TRATAMIENTO " +
                                     "SET FECHA_BAJA = GETDATE(), ESTADO_PLAN = 'CANCELADO', USUARIO_BAJA = @USUARIO_BAJA " +
                                     "WHERE ESTADO_PLAN = 'EN CURSO' " +
                                     "AND FECHA_BAJA IS NULL " +
                                     "AND ID_TRATAMIENTO = (SELECT DISTINCT(ID_PLAN_TRATAMIENTO) " +
                                                             "FROM T_TURNOS " +
                                                             "WHERE ID_TRATAMIENTO = ID_PLAN_TRATAMIENTO " +
                                                             "AND ID_OBRA_SOCIAL = @ID_OBRA_SOCIAL " +
                                                             "AND FECHA_BAJA IS NULL " +
                                                             "AND FECHA_TURNO >= GETDATE()); ";

                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_OBRA_SOCIAL", idObraSocial);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", usuarioBaja);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                resultado = "OK";

            }
            catch (Exception e)
            {

                resultado = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;

            }

            return resultado;

        }


    }
}
