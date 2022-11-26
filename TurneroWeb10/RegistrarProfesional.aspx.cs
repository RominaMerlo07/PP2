﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Gestores;
using Entidades.ent;
using Newtonsoft.Json;

namespace TurneroWeb10
{
    public partial class RegistrarProfesional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registrarProfesional(string p_dni, string p_matricula, List<string> p_especialidades,    string p_nombre, string p_apellido, string p_fechaNac,
                                                 string p_calle, string p_numero, string p_barrio, string p_localidad, string p_celular, string p_email1, string p_email2)
        {

            Profesional profesional = new Profesional();
            GestorProfesionales gestorProfesionales = new GestorProfesionales();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Profesional

                if (!string.IsNullOrEmpty(p_dni))
                {
                    profesional.Documento = p_dni;
                }

                if (!string.IsNullOrEmpty(p_matricula))
                {
                    profesional.NroMatricula = p_matricula;
                }

                if (!string.IsNullOrEmpty(p_nombre))
                {
                    profesional.Nombre = p_nombre;
                }

                if (!string.IsNullOrEmpty(p_apellido))
                {
                    profesional.Apellido = p_apellido;
                }

                if (!string.IsNullOrEmpty(p_fechaNac))
                {
                    profesional.FechaNacimiento = Convert.ToDateTime(p_fechaNac);
                }

                if ((!string.IsNullOrEmpty(p_calle)) && (!string.IsNullOrEmpty(p_numero)))
                {
                    string domicilio = p_calle + " " + p_numero + " Barrio: " + p_barrio;
                    profesional.Domicilio = domicilio;
                }

                if (!string.IsNullOrEmpty(p_localidad))
                {
                    profesional.Localidad = p_localidad;
                }

                if (!string.IsNullOrEmpty(p_celular))
                {
                    profesional.NroContacto = p_celular;
                }

                if ((!string.IsNullOrEmpty(p_email1)) && (!string.IsNullOrEmpty(p_email2)))
                {
                    string email = p_email1 + "@" + p_email2;
                    profesional.EmailContacto = email;
                }
                    
                profesional.UsuarioAlta = 1;
                profesional.FechaAlta = DateTime.Today;

                #endregion

                gestorProfesionales.RegistrarProfesional(profesional, p_especialidades);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el profesional " + e.Message;
                return error;
            }
        }

        [WebMethod]
        public static List<Especialidad> cargarEspecialidades()
        {
            try
            {
                GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();
                List<Especialidad> especialidades = gestorEspecialidades.obtenerEspecialidades();
                return especialidades;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static List<Profesional> cargarProfesionales()
        {
            List<Profesional> profesionales = null;

            try
            {
                GestorProfesionales gestorProfesionales = new GestorProfesionales();
                profesionales = gestorProfesionales.obtenerProfesionales();                
            }
            catch (Exception e)
            {
                profesionales = null;
                throw e;
            }
            return profesionales;
        }


        [WebMethod]
        public static string actualizarProfesional(string id, string nombre, string apellido, string dni, string matricula, string fechaNacimiento,
                                                   string localidad, string barrio, string direccion, string celular, string email1, string email2)
        {

            Profesional profesional = new Profesional();
            GestorProfesionales gestorProfesionales = new GestorProfesionales();


            try
            {
                string mensaje = "OK";

                #region Completa entidad Profesional

                if (!string.IsNullOrEmpty(dni))
                {
                    profesional.Documento = dni;
                }

                if (!string.IsNullOrEmpty(matricula))
                {
                    profesional.NroMatricula = matricula;
                }

                if (!string.IsNullOrEmpty(nombre))
                {
                    profesional.Nombre = nombre;
                }

                if (!string.IsNullOrEmpty(apellido))
                {
                    profesional.Apellido = apellido;
                }

                if (!string.IsNullOrEmpty(fechaNacimiento))
                {
                    profesional.FechaNacimiento = Convert.ToDateTime(fechaNacimiento);
                }

                if (!string.IsNullOrEmpty(direccion))
                {
                    string domicilio = direccion + " Barrio: " + barrio;
                    profesional.Domicilio = domicilio;
                }

                if (!string.IsNullOrEmpty(localidad))
                {
                    profesional.Localidad = localidad;
                }

                if (!string.IsNullOrEmpty(celular))
                {
                    profesional.NroContacto = celular;
                }

                if ((!string.IsNullOrEmpty(email1)) && (!string.IsNullOrEmpty(email2)))
                {
                    string email = email1 + "@" + email2;
                    profesional.EmailContacto = email;
                }

                profesional.IdProfesional = Convert.ToInt32(id);

                profesional.UsuarioMod = 1;
                profesional.FechaMod = DateTime.Today;

                #endregion

                gestorProfesionales.ActualizarProfesional(profesional);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del profesional " + e.Message;
                return error;
            }                                  

        }

        [WebMethod]
        public static string darBajaProfesional(string idProfesional)
        {

            Profesional profesional = new Profesional();
            GestorProfesionales gestorProfesionales = new GestorProfesionales();

            try
            {
                string mensaje = "OK";

                profesional.IdProfesional = Convert.ToInt32(idProfesional);

                profesional.UsuarioBaja = 1;
                profesional.FechaBaja = DateTime.Today;

                mensaje = gestorProfesionales.DarBajaProfesional(profesional);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del profesional " + e.Message;
                return error;
            }

        }

        [WebMethod]
        public static Profesional buscaProfesional(int idProf)
        {
            try
            {
                Profesional profesional = new Profesional();
                GestorProfesionales gestorProfesionales = new GestorProfesionales();
                profesional = gestorProfesionales.obtenerProfesional(idProf);

                return profesional;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string especialidadPorProfesional(string idProfesional)
        {
            try
            {
                GestorProfesionales gProfesionales = new GestorProfesionales();
                DataTable dt = gProfesionales.especialidadPorProfesional(idProfesional);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
               


        [WebMethod]
        public static List<Especialidad> cargarEspecialidadesNotInProfesional(string idProfesional)
        {
            try
            {
                GestorEspecialidades gestorEspecialidades = new GestorEspecialidades();
                List<Especialidad> especialidades = gestorEspecialidades.traerEspecialidadesNotInProfesional(idProfesional);
                return especialidades;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string registrarEspeProfesional(string p_numero, List<string> p_especialidadesP)
        {

            Profesional profesional = new Profesional();
            GestorProfesionales gestorProfesionales = new GestorProfesionales();

            try
            {
                string mensaje = "OK";

                profesional.IdProfesional = Convert.ToInt32(p_numero);
                profesional.UsuarioAlta = 1;
                profesional.FechaAlta = DateTime.Today;

                gestorProfesionales.RegistrarEspeProfesional(profesional, p_especialidadesP);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el profesional " + e.Message;
                return error;
            }
        }


        [WebMethod]
        public static string darBajaProfesionalE(string IdProfesional, string idEspecialidad)
        {

            Profesional profesional = new Profesional();
            GestorProfesionales gestorProfesionales = new GestorProfesionales();

            try
            {
                string mensaje = "OK";

                var usuarioBaja = 1;
                var fechaBaja = DateTime.Today;

                mensaje = gestorProfesionales.DarBajaProfesionalE(IdProfesional, idEspecialidad, usuarioBaja, fechaBaja);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del profesional " + e.Message;
                return error;
            }

        }


        [WebMethod]
        public static string validarDni(string dni)
        {

            string result = "OK";
            try
            {
                GestorPersonal gPersonal = new GestorPersonal();
                GestorProfesionales gestorProfesionales = new GestorProfesionales();

                int existePersonal = gPersonal.validarDniPersonal(dni);
                int existeProfesional = gestorProfesionales.validarDniProfesional(dni);


                if (existePersonal > 0 || existeProfesional > 0)
                {

                    result = "existe";
                    return result;
                }
                else {
                    return result;
                }


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string validarMatricula(string matricula)
        {

            string result = "OK";
            try
            {

                GestorProfesionales gestorProfesionales = new GestorProfesionales();


                int existeMatricula = gestorProfesionales.validarMatricula(matricula);


                if (existeMatricula > 0)
                {

                    result = "existe";
                    return result;
                }
                else
                {
                    return result;
                }


            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string ObtenerTurnosFuturos(string p_id)
        {

            string col = "sin info";
            try
            {
                GestorProfesionales gestorProfesionales = new GestorProfesionales();

                int id = Convert.ToInt32(p_id);

                int cantTurnosFuturos = gestorProfesionales.TurnosFuturos(id);

                if (cantTurnosFuturos > 0)
                {

                    DataTable dt = gestorProfesionales.ObtenerTurnosFuturos(id);
                    col = JsonConvert.SerializeObject(dt);
                    return col;
                }

                return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string MostrarTurnosFuturos(string p_id)
        {

            try
            {
                GestorProfesionales gestorProfesionales = new GestorProfesionales();

                int id = Convert.ToInt32(p_id);

                DataTable dt = gestorProfesionales.ObtenerTurnosFuturos(id);
                string col = JsonConvert.SerializeObject(dt);
                return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string DaDarDeBajaProfTurnos(string p_id)
        {

            string col = "OK";
            try
            {

                GestorProfesionales gestorProfesionales = new GestorProfesionales();
                Profesional profesional = new Profesional();

                int id = Convert.ToInt32(p_id);

                string resultadoBajaProfDet = gestorProfesionales.DaDarDeBajaProfDetalle(id, 1);

                if (resultadoBajaProfDet == "OK")
                {
                    string resultadoBajaProfUsuario = gestorProfesionales.DaDarDeBajaProfUsuario(id, 1);

                    if (resultadoBajaProfUsuario == "OK")
                    {

                        int cantIdTratamiento = gestorProfesionales.obtenerTratamientos(id);

                        if (cantIdTratamiento > 0)
                        {

                            string resultadoBajaTratamiento = gestorProfesionales.DarBajaTratamiento(id, 1);

                            if (resultadoBajaTratamiento == "OK")
                            {

                                string resultadoBajaProfTurnos = gestorProfesionales.DaDarDeBajaTurnos(id, 1);

                                if (resultadoBajaProfTurnos == "OK")
                                {
                                    
                                    profesional.IdProfesional = id;
                                    profesional.UsuarioBaja = 1;
                                    profesional.FechaBaja = DateTime.Today;

                                    string resultadoBajaDisponibilidad = gestorProfesionales.DarBajaDisponibilidad(profesional);

                                    if (resultadoBajaDisponibilidad == "OK") { 

                                        col = gestorProfesionales.DarBajaProfesional(profesional);

                                    }
                                }
                            }

                        }
                        else {

                            string resultadoBajaProfTurnos = gestorProfesionales.DaDarDeBajaTurnos(id, 1);

                            if (resultadoBajaProfTurnos == "OK")
                            {
                                profesional.IdProfesional = id;
                                profesional.UsuarioBaja = 1;
                                profesional.FechaBaja = DateTime.Today;

                                string resultadoBajaDisponibilidad = gestorProfesionales.DarBajaDisponibilidad(profesional);

                                if (resultadoBajaDisponibilidad == "OK")
                                {

                                    col = gestorProfesionales.DarBajaProfesional(profesional);

                                }
                            }

                        }                        
                        
                    }

                }

                return col;

                //return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string DaDarDeBajaProf(string p_id)
        {

            string col = "OK";
            try
            {

                GestorProfesionales gestorProfesionales = new GestorProfesionales();
                Profesional profesional = new Profesional();

                int id = Convert.ToInt32(p_id);

                string resultadoBajaProfDet = gestorProfesionales.DaDarDeBajaProfDetalle(id, 1);

                if (resultadoBajaProfDet == "OK")
                {
                    string resultadoBajaProfUsuario = gestorProfesionales.DaDarDeBajaProfUsuario(id, 1);

                    if (resultadoBajaProfUsuario == "OK")
                    {
                        
                            profesional.IdProfesional = id;
                            profesional.UsuarioBaja = 1;
                            profesional.FechaBaja = DateTime.Today;

                            col = gestorProfesionales.DarBajaProfesional(profesional);
                        

                    }

                }

                return col;

                //return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string ObtenerTurnosFuturosE(string IdProfesional, string idEspecialidad)
        {

            string col = "sin info";
            try
            {
                GestorProfesionales gestorProfesionales = new GestorProfesionales();

                int idP = Convert.ToInt32(IdProfesional);
                int idE = Convert.ToInt32(idEspecialidad);

                int cantTurnosFuturos = gestorProfesionales.TurnosFuturosE(idP, idE);

                if (cantTurnosFuturos > 0)
                {

                    DataTable dt = gestorProfesionales.ObtenerTurnosFuturosE(idP, idE);
                    col = JsonConvert.SerializeObject(dt);
                    return col;
                }

                return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string MostrarTurnosFuturosE(string IdProfesional, string idEspecialidad)
        {

            try
            {
                GestorProfesionales gestorProfesionales = new GestorProfesionales();

                int idP = Convert.ToInt32(IdProfesional);
                int idE = Convert.ToInt32(idEspecialidad);

                DataTable dt = gestorProfesionales.ObtenerTurnosFuturosE(idP, idE);
                string col = JsonConvert.SerializeObject(dt);
                return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string DaDarDeBajaProfTurnosE(string IdProfesional, string idEspecialidad)
        {

            string col = "OK";
            try
            {

                GestorProfesionales gestorProfesionales = new GestorProfesionales();
                Profesional profesional = new Profesional();

                int idProf = Convert.ToInt32(IdProfesional);
                int idEsp = Convert.ToInt32(idEspecialidad);

                int cantIdTratamiento = gestorProfesionales.obtenerTratamientosE(idProf, idEsp);

                if (cantIdTratamiento > 0)
                {

                    string resultadoBajaTratamiento = gestorProfesionales.DarBajaTratamientoE(idProf, idEsp, 1);

                    if (resultadoBajaTratamiento == "OK")
                    {

                        string resultadoBajaProfTurnos = gestorProfesionales.DaDarDeBajaTurnosE(idProf, idEsp, 1);

                        if (resultadoBajaProfTurnos == "OK")
                        {

                           int usuarioBaja = 1;
                           DateTime fechaBaja = DateTime.Today;

                            col = gestorProfesionales.DarBajaProfesionalE(IdProfesional, idEspecialidad, usuarioBaja, fechaBaja);
                        }
                    }

                }
                else
                {

                    string resultadoBajaProfTurnos = gestorProfesionales.DaDarDeBajaTurnosE(idProf, idEsp, 1);

                    if (resultadoBajaProfTurnos == "OK")
                    {
                        int usuarioBaja = 1;
                        DateTime fechaBaja = DateTime.Today;

                        col = gestorProfesionales.DarBajaProfesionalE(IdProfesional, idEspecialidad, usuarioBaja, fechaBaja);
                    }

                }

                return col;


            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}