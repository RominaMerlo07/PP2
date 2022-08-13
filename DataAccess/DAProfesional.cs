using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DAProfesional
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;


        public int DaRegistrarProfesional(Profesional profesional)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "INSERT INTO T_PROFESIONALES " +
                                              "(NOMBRE," +
                                              "APELLIDO," +
                                              "DOCUMENTO," +
                                              "NRO_CONTACTO," +
                                              "EMAIL_CONTACTO," +
                                              "FECHA_NACIMIENTO," +
                                              "DOMICILIO," +
                                              "LOCALIDAD," +
                                              "NRO_MATRICULA," +
                                              "USUARIO_ALTA," +
                                              "FECHA_ALTA)" +
                                      "VALUES(" +
                                            "@NOMBRE," +
                                            "@APELLIDO," +
                                            "@DOCUMENTO," +
                                            "@NRO_CONTACTO," +
                                            "@EMAIL_CONTACTO," +
                                            "@FECHA_NACIMIENTO," +
                                            "@DOMICILIO," +
                                            "@LOCALIDAD," +
                                            "@NRO_MATRICULA," +
                                            "@USUARIO_ALTA," +
                                            "@FECHA_ALTA); SELECT SCOPE_IDENTITY()";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(profesional.Nombre))
                    cmd.Parameters.AddWithValue("@NOMBRE", profesional.Nombre);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Apellido))
                    cmd.Parameters.AddWithValue("@APELLIDO", profesional.Apellido);
                else
                    cmd.Parameters.AddWithValue("@APELLIDO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Documento))
                    cmd.Parameters.AddWithValue("@DOCUMENTO", profesional.Documento);
                else
                    cmd.Parameters.AddWithValue("@DOCUMENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.NroContacto))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", profesional.NroContacto);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.EmailContacto))
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", profesional.EmailContacto);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(profesional.FechaNacimiento)))
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", profesional.FechaNacimiento);
                else
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Domicilio))
                    cmd.Parameters.AddWithValue("@DOMICILIO", profesional.Domicilio);
                else
                    cmd.Parameters.AddWithValue("@DOMICILIO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Localidad))
                    cmd.Parameters.AddWithValue("@LOCALIDAD", profesional.Localidad);
                else
                    cmd.Parameters.AddWithValue("@LOCALIDAD", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.NroMatricula))
                    cmd.Parameters.AddWithValue("@NRO_MATRICULA", profesional.NroMatricula);
                else
                    cmd.Parameters.AddWithValue("@NRO_MATRICULA", DBNull.Value);



                cmd.Parameters.AddWithValue("@USUARIO_ALTA", profesional.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", profesional.FechaAlta);

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
        
        public List<Profesional> traerProfesionales()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_PROFESIONALES " +
                                    "WHERE FECHA_BAJA IS NULL " +
                                    "ORDER BY ID_PROFESIONAL;";

                cmd = new SqlCommand(consulta, con);
                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<Profesional> listaProfesionales = new List<Profesional>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Profesional profesional = new Profesional();
                        if (dr["ID_PROFESIONAL"] != DBNull.Value)
                            profesional.IdProfesional = Convert.ToInt32(dr["ID_PROFESIONAL"]);
                        if (dr["NOMBRE"] != DBNull.Value)
                            profesional.Nombre = Convert.ToString(dr["NOMBRE"]);
                        if (dr["APELLIDO"] != DBNull.Value)
                            profesional.Apellido = Convert.ToString(dr["APELLIDO"]);
                        if (dr["DOCUMENTO"] != DBNull.Value)
                            profesional.Documento = Convert.ToString(dr["DOCUMENTO"]);
                        if (dr["NRO_CONTACTO"] != DBNull.Value)
                            profesional.NroContacto = Convert.ToString(dr["NRO_CONTACTO"]);
                        if (dr["EMAIL_CONTACTO"] != DBNull.Value)
                            profesional.EmailContacto = Convert.ToString(dr["EMAIL_CONTACTO"]);
                        if (dr["FECHA_NACIMIENTO"] != DBNull.Value)
                            profesional.FechaNacimiento = Convert.ToDateTime(dr["FECHA_NACIMIENTO"]);
                        if (dr["DOMICILIO"] != DBNull.Value)
                            profesional.Domicilio = Convert.ToString(dr["DOMICILIO"]);
                        if (dr["LOCALIDAD"] != DBNull.Value)
                            profesional.Localidad = Convert.ToString(dr["LOCALIDAD"]);
                        if (dr["NRO_MATRICULA"] != DBNull.Value)
                            profesional.NroMatricula = Convert.ToString(dr["NRO_MATRICULA"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            profesional.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            profesional.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            profesional.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            profesional.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            profesional.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            profesional.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        listaProfesionales.Add(profesional);
                    }

                    return listaProfesionales;
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

        public Profesional obtenerProfesional(int idProfesional)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_PROFESIONALES " +
                                    "WHERE ID_PROFESIONAL = @ID_PROFESIONAL " +
                                    "AND FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);

                if (idProfesional != 0)
                    cmd.Parameters.AddWithValue("@ID_PROFESIONAL", idProfesional);
                else
                    cmd.Parameters.AddWithValue("@ID_PROFESIONAL", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                Profesional profesional = new Profesional();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {                        
                        if (dr["ID_PROFESIONAL"] != DBNull.Value)
                            profesional.IdProfesional = Convert.ToInt32(dr["ID_PROFESIONAL"]);
                        if (dr["NOMBRE"] != DBNull.Value)
                            profesional.Nombre = Convert.ToString(dr["NOMBRE"]);
                        if (dr["APELLIDO"] != DBNull.Value)
                            profesional.Apellido = Convert.ToString(dr["APELLIDO"]);
                        if (dr["DOCUMENTO"] != DBNull.Value)
                            profesional.Documento = Convert.ToString(dr["DOCUMENTO"]);
                        if (dr["NRO_CONTACTO"] != DBNull.Value)
                            profesional.NroContacto = Convert.ToString(dr["NRO_CONTACTO"]);
                        if (dr["EMAIL_CONTACTO"] != DBNull.Value)
                            profesional.EmailContacto = Convert.ToString(dr["EMAIL_CONTACTO"]);
                        if (dr["FECHA_NACIMIENTO"] != DBNull.Value)
                            profesional.FechaNacimiento = Convert.ToDateTime(dr["FECHA_NACIMIENTO"]);
                        if (dr["DOMICILIO"] != DBNull.Value)
                            profesional.Domicilio = Convert.ToString(dr["DOMICILIO"]);
                        if (dr["LOCALIDAD"] != DBNull.Value)
                            profesional.Localidad = Convert.ToString(dr["LOCALIDAD"]);
                        if (dr["NRO_MATRICULA"] != DBNull.Value)
                            profesional.NroMatricula = Convert.ToString(dr["NRO_MATRICULA"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            profesional.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            profesional.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            profesional.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            profesional.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            profesional.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            profesional.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);
                    }

                    return profesional;
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



        public string ActualizarProfesional(Profesional profesional)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_PROFESIONALES " +
                                     "SET NOMBRE = @NOMBRE, " +
                                          "APELLIDO = @APELLIDO, " +
                                          "DOCUMENTO = @DOCUMENTO, " +
                                          "NRO_CONTACTO = @NRO_CONTACTO, " +
                                          "EMAIL_CONTACTO = @EMAIL_CONTACTO, " +
                                          "FECHA_NACIMIENTO = @FECHA_NACIMIENTO, " +
                                          "DOMICILIO = @DOMICILIO, " +
                                          "LOCALIDAD = @LOCALIDAD, " +
                                          "NRO_MATRICULA = @NRO_MATRICULA, " +
                                          "USUARIO_MOD = @USUARIO_MOD, " +
                                          "FECHA_MOD = @FECHA_MOD " +
                                   "WHERE ID_PROFESIONAL = @ID_PROFESIONAL; SELECT SCOPE_IDENTITY();";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(profesional.Nombre))
                    cmd.Parameters.AddWithValue("@NOMBRE", profesional.Nombre);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Apellido))
                    cmd.Parameters.AddWithValue("@APELLIDO", profesional.Apellido);
                else
                    cmd.Parameters.AddWithValue("@APELLIDO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Documento))
                    cmd.Parameters.AddWithValue("@DOCUMENTO", profesional.Documento);
                else
                    cmd.Parameters.AddWithValue("@DOCUMENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.NroContacto))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", profesional.NroContacto);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.EmailContacto))
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", profesional.EmailContacto);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(Convert.ToString(profesional.FechaNacimiento)))
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", profesional.FechaNacimiento);
                else
                    cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Domicilio))
                    cmd.Parameters.AddWithValue("@DOMICILIO", profesional.Domicilio);
                else
                    cmd.Parameters.AddWithValue("@DOMICILIO", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.Localidad))
                    cmd.Parameters.AddWithValue("@LOCALIDAD", profesional.Localidad);
                else
                    cmd.Parameters.AddWithValue("@LOCALIDAD", DBNull.Value);

                if (!string.IsNullOrEmpty(profesional.NroMatricula))
                    cmd.Parameters.AddWithValue("@NRO_MATRICULA", profesional.NroMatricula);
                else
                    cmd.Parameters.AddWithValue("@NRO_MATRICULA", DBNull.Value);

                cmd.Parameters.AddWithValue("@ID_PROFESIONAL", profesional.IdProfesional);
                cmd.Parameters.AddWithValue("@USUARIO_MOD", profesional.UsuarioMod);
                cmd.Parameters.AddWithValue("@FECHA_MOD", profesional.FechaMod);

                cmd.ExecuteNonQuery();
                //int devolver = Convert.ToInt32(cmd.ExecuteScalar());
                trans.Commit();
                con.Close();

                result = "OK";

            }
            catch (Exception e)
            {
                result = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;
            }

            return result;

        }

        public string DarBajaProfesional(Profesional profesional)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = "UPDATE T_PROFESIONALES " +
                                     "SET USUARIO_BAJA = @USUARIO_BAJA, " +
                                          "FECHA_BAJA = @FECHA_BAJA " +
                                   "WHERE ID_PROFESIONAL = @ID_PROFESIONAL;";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_PROFESIONAL", profesional.IdProfesional);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", profesional.UsuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", profesional.FechaBaja);

                cmd.ExecuteNonQuery();
                //int devolver = Convert.ToInt32(cmd.ExecuteScalar());
                trans.Commit();
                con.Close();

                result = "OK";

            }
            catch (Exception e)
            {
                result = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;
            }

            return result;

        }

        public DataTable obtenerProfesionalesDisponibles(string idCentro, string idEspecialidad)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"select pd.ID_PROFESIONAL,  
	                                       concat(p.APELLIDO, ', ', p.NOMBRE) as NOMBRE
                                    from t_profesionales_detalle pd, T_PROFESIONALES p
                                    where p.ID_PROFESIONAL = pd.ID_PROFESIONAL
                                    and pd.FECHA_BAJA is null
                                    and pd.ID_CENTRO = @idCentro
                                    and ID_ESPECIALIDAD = @idEspecialidad
                                    ; ";

                cmd = new SqlCommand(consulta, con);

                if (!String.IsNullOrEmpty(idCentro))
                    cmd.Parameters.AddWithValue("@idCentro", idCentro);
                else
                    cmd.Parameters.AddWithValue("@idCentro", DBNull.Value);

                if (!String.IsNullOrEmpty(idEspecialidad))
                    cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);
                else
                    cmd.Parameters.AddWithValue("@idEspecialidad", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataTable TraerDisponibilidadHoraria(string idProfesional, string idEspecialidad, string idCentro, string dia = null)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"select top 1 dh.*
                                    from t_profesionales_detalle pd, t_disponibilidad_horaria dh
                                    where pd.id_profesionales_detalle = dh.id_Profesionales_detalle
                                    and pd.FECHA_BAJA is null
                                    and dh.FECHA_BAJA is null
                                    and pd.ID_CENTRO = @idCentro
                                    and pd.ID_PROFESIONAL = @idProfesional
                                    and pd.ID_ESPECIALIDAD = @idEspecialidad
                                    order by ID_DISPONIBILIDAD desc
                                     ";

                cmd = new SqlCommand(consulta, con);

                if (!String.IsNullOrEmpty(idCentro))
                    cmd.Parameters.AddWithValue("@idCentro", idCentro);
                else
                    cmd.Parameters.AddWithValue("@idCentro", DBNull.Value);
                if (!String.IsNullOrEmpty(idProfesional))
                    cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                else
                    cmd.Parameters.AddWithValue("@idProfesional", DBNull.Value);
                if (!String.IsNullOrEmpty(idEspecialidad))
                    cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);
                else
                    cmd.Parameters.AddWithValue("@idEspecialidad", DBNull.Value);
                if (!String.IsNullOrEmpty(dia))
                {
                    cmd.Parameters.AddWithValue("@dia", Convert.ToDateTime(dia));
                    consulta += " and @dia between dh.FECHA_INIC and dh.FECHA_FIN ";
                }


                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable especialidadPorProfesional(string idProfesional)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = @"SELECT DISTINCT PD.ID_ESPECIALIDAD, " +
                                         "UPPER(E.DESCRIPCION) ESPECIALIDAD " +
                                    "FROM T_PROFESIONALES P, " +
                                         "T_PROFESIONALES_DETALLE PD, " +
                                         "T_ESPECIALIDADES E " +
                                   "WHERE P.ID_PROFESIONAL = PD.ID_PROFESIONAL " +
                                     "AND PD.ID_ESPECIALIDAD = E.ID_ESPECIALIDADES " +
                                     "AND PD.FECHA_BAJA IS NULL " +
                                     "AND P.FECHA_BAJA IS NULL " +
                                     "AND P.ID_PROFESIONAL = @idProfesional " +
                                   "ORDER BY 2; ";

                //DESCOMENTAR PARA MOSTRAR EN TABLA

                //string consulta = @"SELECT DISTINCT PD.ID_ESPECIALIDAD, 
                //                           UPPER(E.DESCRIPCION) ESPECIALIDAD, 
                //                           'A' ESTADO 
                //                      FROM T_PROFESIONALES P, 
                //                           T_PROFESIONALES_DETALLE PD, 
                //                           T_ESPECIALIDADES E 
                //                     WHERE P.ID_PROFESIONAL = PD.ID_PROFESIONAL 
                //                       AND PD.ID_ESPECIALIDAD = E.ID_ESPECIALIDADES 
                //                       AND PD.FECHA_BAJA IS NULL 
                //                       AND P.FECHA_BAJA IS NULL 
                //                       AND P.ID_PROFESIONAL = @idProfesional 
                //                   UNION 
                //                    SELECT E.ID_ESPECIALIDADES, 
                //                           E.DESCRIPCION, 
                //                          'I' ESTADO 
                //                      FROM T_ESPECIALIDADES E 
                //                     WHERE ID_ESPECIALIDADES NOT IN (SELECT PD.ID_ESPECIALIDAD 
                //                                                       FROM T_PROFESIONALES_DETALLE PD 
                //                                                      WHERE PD.ID_ESPECIALIDAD = ID_ESPECIALIDADES 
                //                                                       AND PD.ID_PROFESIONAL = @idProfesional)
                //                    ORDER BY ESTADO DESC;";

                cmd = new SqlCommand(consulta, con);                               
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                             
                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string DarBajaProfesionalE(string idProfesional, string idEspecialidad, int usuarioBaja, DateTime fechaBaja)
        {

            string result;
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);
                con.Open();
                trans = con.BeginTransaction();

                string consulta = @"UPDATE T_PROFESIONALES_DETALLE 
                                       SET FECHA_BAJA = @FECHA_BAJA, USUARIO_MOD = @USUARIO_BAJA 
                                     WHERE ID_PROFESIONAL = @ID_PROFESIONAL 
                                       AND ID_ESPECIALIDAD = @ID_ESPECIALIDAD 
                                       AND FECHA_BAJA IS NULL;";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                cmd.Parameters.AddWithValue("@ID_PROFESIONAL", idProfesional);
                cmd.Parameters.AddWithValue("@ID_ESPECIALIDAD", idEspecialidad);
                cmd.Parameters.AddWithValue("@USUARIO_BAJA", usuarioBaja);
                cmd.Parameters.AddWithValue("@FECHA_BAJA", fechaBaja);

                cmd.ExecuteNonQuery();
                trans.Commit();
                con.Close();

                result = "OK";

            }
            catch (Exception e)
            {
                result = "ERROR - " + e.ToString();
                trans.Rollback();
                con.Close();
                throw e;
            }

            return result;

        }

        //public List<Profesional> Select2Prof(string search)
        //{
        //    try
        //    {
        //        string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
        //        con = new SqlConnection(cadenaDeConexion);

        //        string consulta = "SELECT * " +
        //                            "FROM T_PROFESIONALES " +
        //                            "WHERE FECHA_BAJA IS NULL " +
        //                            "AND NOMBRE like '%@VALOR%' " +
        //                            "AND APELLIDO like '%@VALOR%' " +
        //                            "ORDER BY ID_PROFESIONAL;";

        //        cmd = new SqlCommand(consulta, con);
        //        cmd.Parameters.AddWithValue("@VALOR", search);

        //        dta = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        dta.Fill(dt);

        //        List<Profesional> listaProfesionales = new List<Profesional>();

        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                Profesional profesional = new Profesional();
        //                if (dr["ID_PROFESIONAL"] != DBNull.Value)
        //                    profesional.IdProfesional = Convert.ToInt32(dr["ID_PROFESIONAL"]);
        //                if (dr["NOMBRE"] != DBNull.Value)
        //                    profesional.Nombre = Convert.ToString(dr["NOMBRE"]);
        //                if (dr["APELLIDO"] != DBNull.Value)
        //                    profesional.Apellido = Convert.ToString(dr["APELLIDO"]);
        //                if (dr["DOCUMENTO"] != DBNull.Value)
        //                    profesional.Documento = Convert.ToString(dr["DOCUMENTO"]);
        //                if (dr["NRO_CONTACTO"] != DBNull.Value)
        //                    profesional.NroContacto = Convert.ToString(dr["NRO_CONTACTO"]);
        //                if (dr["EMAIL_CONTACTO"] != DBNull.Value)
        //                    profesional.EmailContacto = Convert.ToString(dr["EMAIL_CONTACTO"]);
        //                if (dr["FECHA_NACIMIENTO"] != DBNull.Value)
        //                    profesional.FechaNacimiento = Convert.ToDateTime(dr["FECHA_NACIMIENTO"]);
        //                if (dr["DOMICILIO"] != DBNull.Value)
        //                    profesional.Domicilio = Convert.ToString(dr["DOMICILIO"]);
        //                if (dr["LOCALIDAD"] != DBNull.Value)
        //                    profesional.Localidad = Convert.ToString(dr["LOCALIDAD"]);
        //                if (dr["NRO_MATRICULA"] != DBNull.Value)
        //                    profesional.NroMatricula = Convert.ToString(dr["NRO_MATRICULA"]);
        //                if (dr["USUARIO_ALTA"] != DBNull.Value)
        //                    profesional.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
        //                if (dr["FECHA_ALTA"] != DBNull.Value)
        //                    profesional.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
        //                if (dr["USUARIO_MOD"] != DBNull.Value)
        //                    profesional.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
        //                if (dr["FECHA_MOD"] != DBNull.Value)
        //                    profesional.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
        //                if (dr["USUARIO_BAJA"] != DBNull.Value)
        //                    profesional.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
        //                if (dr["FECHA_BAJA"] != DBNull.Value)
        //                    profesional.FechaBaja = Convert.ToDateTime(dr["FECHA_BAJA"]);

        //                listaProfesionales.Add(profesional);
        //            }

        //            return listaProfesionales;
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

    }
}

