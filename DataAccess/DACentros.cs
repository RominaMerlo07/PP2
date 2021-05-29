using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DACentros
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;

        public List<Centro> traerCentros()
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_CENTROS " +
                                    "WHERE FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);
                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                List<Centro> listaCentros = new List<Centro>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Centro centro = new Centro();
                        if (dr["ID_CENTRO"] != DBNull.Value)
                            centro.IdCentro = Convert.ToInt32(dr["ID_CENTRO"]);
                        if (dr["NOMBRE_CENTRO"] != DBNull.Value)
                            centro.NombreCentro = Convert.ToString(dr["NOMBRE_CENTRO"]);
                        if (dr["DOMICILIO_CENTRO"] != DBNull.Value)
                            centro.DomicilioCentro = Convert.ToString(dr["DOMICILIO_CENTRO"]);
                        if (dr["LOCALIDAD_CENTRO"] != DBNull.Value)
                            centro.LocalidadCentro = Convert.ToString(dr["LOCALIDAD_CENTRO"]);
                        if (dr["EMAIL_CENTRO"] != DBNull.Value)
                            centro.EmailCentro = Convert.ToString(dr["EMAIL_CENTRO"]);
                        if (dr["NRO_CONTACTO_1"] != DBNull.Value)
                            centro.NroCentro1 = Convert.ToString(dr["NRO_CONTACTO_1"]);
                        if (dr["NRO_CONTACTO_2"] != DBNull.Value)
                            centro.NroCentro2 = Convert.ToString(dr["NRO_CONTACTO_1"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            centro.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            centro.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            centro.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            centro.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            centro.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            centro.FechaMod = Convert.ToDateTime(dr["FECHA_BAJA"]);

                        listaCentros.Add(centro);

                    }

                    return listaCentros;
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

        public Centro obtenerCentro(int idCentro)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_CENTROS " +
                                    "WHERE ID_CENTRO = @ID_CENTRO " +
                                    "AND FECHA_BAJA IS NULL;";

                cmd = new SqlCommand(consulta, con);

                if (idCentro != 0)
                    cmd.Parameters.AddWithValue("@ID_CENTRO", idCentro);
                else
                    cmd.Parameters.AddWithValue("@ID_CENTRO", DBNull.Value);

                dta = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dta.Fill(dt);

                Centro centro = new Centro();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        
                        if (dr["ID_CENTRO"] != DBNull.Value)
                            centro.IdCentro = Convert.ToInt32(dr["ID_CENTRO"]);
                        if (dr["NOMBRE_CENTRO"] != DBNull.Value)
                            centro.NombreCentro = Convert.ToString(dr["NOMBRE_CENTRO"]);
                        if (dr["DOMICILIO_CENTRO"] != DBNull.Value)
                            centro.DomicilioCentro = Convert.ToString(dr["DOMICILIO_CENTRO"]);
                        if (dr["LOCALIDAD_CENTRO"] != DBNull.Value)
                            centro.LocalidadCentro = Convert.ToString(dr["LOCALIDAD_CENTRO"]);
                        if (dr["EMAIL_CENTRO"] != DBNull.Value)
                            centro.EmailCentro = Convert.ToString(dr["EMAIL_CENTRO"]);
                        if (dr["NRO_CONTACTO_1"] != DBNull.Value)
                            centro.NroCentro1 = Convert.ToString(dr["NRO_CONTACTO_1"]);
                        if (dr["NRO_CONTACTO_2"] != DBNull.Value)
                            centro.NroCentro2 = Convert.ToString(dr["NRO_CONTACTO_1"]);
                        if (dr["USUARIO_ALTA"] != DBNull.Value)
                            centro.UsuarioAlta = Convert.ToInt32(dr["USUARIO_ALTA"]);
                        if (dr["FECHA_ALTA"] != DBNull.Value)
                            centro.FechaAlta = Convert.ToDateTime(dr["FECHA_ALTA"]);
                        if (dr["USUARIO_MOD"] != DBNull.Value)
                            centro.UsuarioMod = Convert.ToInt32(dr["USUARIO_MOD"]);
                        if (dr["FECHA_MOD"] != DBNull.Value)
                            centro.FechaMod = Convert.ToDateTime(dr["FECHA_MOD"]);
                        if (dr["USUARIO_BAJA"] != DBNull.Value)
                            centro.UsuarioBaja = Convert.ToInt32(dr["USUARIO_BAJA"]);
                        if (dr["FECHA_BAJA"] != DBNull.Value)
                            centro.FechaMod = Convert.ToDateTime(dr["FECHA_BAJA"]);

                    }

                    return centro;
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
