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

        public List<ObraSocial> traerObrasSociales(string id_Centro)
        {
            try
            {
                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();
                con = new SqlConnection(cadenaDeConexion);

                string consulta = "SELECT * FROM T_OBRAS_SOCIALES " +
                                    "WHERE ID_CENTRO = @id_Centro;";

                cmd = new SqlCommand(consulta, con);

                if (!string.IsNullOrEmpty(id_Centro))
                    cmd.Parameters.AddWithValue("@id_Centro", id_Centro);
                else
                    cmd.Parameters.AddWithValue("@id_Centro", DBNull.Value);

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
                        if (dr["ID_CENTRO"] != DBNull.Value)
                        { 
                            Centro centro = new Centro();
                            centro.IdCentro = Convert.ToInt32(dr["ID_CENTRO"]);
                            obraSocial.Centro = centro;
                        }
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
                            obraSocial.FechaMod = Convert.ToDateTime(dr["FECHA_BAJA"]);

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
    }
}
