﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Entidades.ent;

namespace DataAccess
{
    public class DAPaciente
    {
        SqlConnectionManager SqlConnectionManager = new SqlConnectionManager();
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter dta;
        DataTable dt;
        SqlDataReader dr;
        SqlTransaction trans;


        public int DaRegistrarPaciente(Paciente paciente)
        {
            try
            {
                string resultado = "OK";

                string cadenaDeConexion = SqlConnectionManager.getCadenaConexion();

                con = new SqlConnection(cadenaDeConexion);             
                con.Open();
                trans = con.BeginTransaction();
                

                string consulta = "INSERT INTO T_PACIENTES (" +
                                        "NOMBRE, " +
                                        "APELLIDO, " +
                                        "DOCUMENTO, " +
                                        "NRO_CONTACTO, " +
                                        "EMAIL_CONTACTO, " +
                                        "USUARIO_ALTA, " +
                                        "FECHA_ALTA " +
                                    ") VALUES ( " +
                                        "@NOMBRE, " +
                                        "@APELLIDO, " +
                                        "@DOCUMENTO, " +
                                        "@NRO_CONTACTO, " +
                                        "@EMAIL_CONTACTO, " +
                                        "@USUARIO_ALTA, " +
                                        "@FECHA_ALTA " +
                                        "); ; SELECT SCOPE_IDENTITY()";


                cmd = new SqlCommand(consulta, con);
                cmd.Transaction = trans;

                if (!string.IsNullOrEmpty(paciente.Nombre))
                    cmd.Parameters.AddWithValue("@NOMBRE", paciente.Nombre);
                else
                    cmd.Parameters.AddWithValue("@NOMBRE", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.Apellido))
                    cmd.Parameters.AddWithValue("@APELLIDO", paciente.Apellido);
                else
                    cmd.Parameters.AddWithValue("@APELLIDO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.Documento))
                    cmd.Parameters.AddWithValue("@DOCUMENTO", paciente.Documento);
                else
                    cmd.Parameters.AddWithValue("@DOCUMENTO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.NroContacto))
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", paciente.NroContacto);
                else
                    cmd.Parameters.AddWithValue("@NRO_CONTACTO", DBNull.Value);

                if (!string.IsNullOrEmpty(paciente.EmailContacto))
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", paciente.EmailContacto);
                else
                    cmd.Parameters.AddWithValue("@EMAIL_CONTACTO", DBNull.Value);

                cmd.Parameters.AddWithValue("@USUARIO_ALTA", paciente.UsuarioAlta);
                cmd.Parameters.AddWithValue("@FECHA_ALTA", paciente.FechaAlta);

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
    }
}
