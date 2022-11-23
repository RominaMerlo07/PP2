using System;
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
    public partial class RegistrarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registrarPaciente(string p_dni, string p_celular, string p_nombre, string p_apellido, string p_email1, string p_email2, string p_obraSocial, string p_plan, string p_nroAfiliado)
        {
                   
            Paciente paciente = new Paciente();
            GestorPacientes gestorPacientes = new GestorPacientes();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Paciente

                if (!string.IsNullOrEmpty(p_dni))
                {
                    paciente.Documento = p_dni;
                }

                if (!string.IsNullOrEmpty(p_nombre))
                {
                    paciente.Nombre = p_nombre;
                }

                if (!string.IsNullOrEmpty(p_apellido))
                {
                    paciente.Apellido = p_apellido;
                }
                         
                if (!string.IsNullOrEmpty(p_celular))
                {
                    paciente.NroContacto = p_celular;
                }

                if ((!string.IsNullOrEmpty(p_email1)) && (!string.IsNullOrEmpty(p_email2)))
                {
                    string email = p_email1 + "@" + p_email2;
                    paciente.EmailContacto = email;
                }

                paciente.UsuarioAlta = 1;
                paciente.FechaAlta = DateTime.Today;

           
                #endregion

                gestorPacientes.RegistrarPacientes(paciente, p_obraSocial, p_plan, p_nroAfiliado);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el paciente " + e.Message;
                return error;
            }

        }


        [WebMethod]
        public static List<ObraSocial> cargarObrasSociales()
        {
            try
            {
                GestorObrasSociales gestorObrasSociales = new GestorObrasSociales();
                List<ObraSocial> obrasSociales = gestorObrasSociales.obtenerObrasSociales();
                return obrasSociales;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string cargarPlanes(string idObraSocial)
        {
            try
            {
                GestorObrasSociales gObras = new GestorObrasSociales();
                DataTable obras = gObras.TraerPlanes(idObraSocial);
                string col = JsonConvert.SerializeObject(obras);

                return col;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [WebMethod]
        public static string cargarPacientes()
        {
            try
            {
                GestorPacientes gestorPacientes = new GestorPacientes();
                DataTable dt = gestorPacientes.cargarPacientes();
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string buscarPaciente(string idPaciente)
        {
            try
            {
                GestorPacientes gestorPacientes = new GestorPacientes();
                DataTable dt = gestorPacientes.buscarPaciente(idPaciente);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string actualizarPaciente(string id, string nombre, string apellido, string dni, string celular, string email1, string email2)
        {

            Paciente paciente = new Paciente();
            GestorPacientes gestorPaciente = new GestorPacientes();


            try
            {
                string mensaje = "OK";

                #region Completa entidad Paciente

                if (!string.IsNullOrEmpty(dni))
                {
                    paciente.Documento = dni;
                }

                if (!string.IsNullOrEmpty(nombre))
                {
                    paciente.Nombre = nombre;
                }

                if (!string.IsNullOrEmpty(apellido))
                {
                    paciente.Apellido = apellido;
                }

                if (!string.IsNullOrEmpty(celular))
                {
                    paciente.NroContacto = celular;
                }

                if ((!string.IsNullOrEmpty(email1)) && (!string.IsNullOrEmpty(email2)))
                {
                    string email = email1 + "@" + email2;
                    paciente.EmailContacto = email;
                }

                paciente.IdPaciente = Convert.ToInt32(id);

                paciente.UsuarioMod = 1;
                paciente.FechaMod = DateTime.Today;

                #endregion

                gestorPaciente.actualizarPaciente(paciente);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del personal " + e.Message;
                return error;
            }

        }

        [WebMethod]
        public static string obraSocialPaciente(string idPaciente)
        {
            try
            {
                GestorPacientes gestorPaciente = new GestorPacientes();
                DataTable dt = gestorPaciente.obraSocialPaciente(idPaciente);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static List<ObraSocial> obtenerOSxPaciente(string idPaciente)
        {
            try
            {
                GestorObrasSociales gestorObrasSociales = new GestorObrasSociales();
                List<ObraSocial> obrasSociales = gestorObrasSociales.obtenerOSxPaciente(idPaciente);
                return obrasSociales;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string registrarOSPaciente(string p_idPaciente, string p_obraSocial, string p_plan, string p_nroAfiliado)
        {

            ObrasPacientes obrasPaciente = new ObrasPacientes();
            GestorPacientes gestorPacientes = new GestorPacientes();

            try
            {
                string mensaje = "OK";

                #region Completa entidad obrasPaciente

                if (!string.IsNullOrEmpty(p_obraSocial))
                {
                    obrasPaciente.IdObraSocial = Convert.ToInt32(p_obraSocial);
                }

                if (!string.IsNullOrEmpty(p_plan))
                {
                    obrasPaciente.IdPlan = Convert.ToInt32(p_plan);
                }

                if (!string.IsNullOrEmpty(p_nroAfiliado))
                {
                    obrasPaciente.nroAfiliado = p_nroAfiliado;
                }
                                             
                obrasPaciente.IdPaciente = Convert.ToInt32(p_idPaciente);
                obrasPaciente.UsuarioAlta = 1;
                obrasPaciente.FechaAlta = DateTime.Today;


                #endregion

                gestorPacientes.registrarOSPaciente(obrasPaciente);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el paciente " + e.Message;
                return error;
            }

        }

        [WebMethod]
        public static string inactivarOSPaciente(string idObraPaciente)
        {

            ObrasPacientes obraPaciente = new ObrasPacientes();
            GestorPacientes gestorPaciente = new GestorPacientes();

            try
            {
                string mensaje = "OK";


                obraPaciente.IdObraPaciente = Convert.ToInt32(idObraPaciente);

                obraPaciente.UsuarioBaja = 1;
                obraPaciente.FechaBaja = DateTime.Today;

                gestorPaciente.inactivarOSPaciente(obraPaciente);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar los datos del personal " + e.Message;
                return error;
            }

        }


        [WebMethod]
        public static List<ObraSocial> obtenerOSePaciente(string idObraPaciente)
        {
            try
            {
                GestorObrasSociales gestorObrasSociales = new GestorObrasSociales();
                List<ObraSocial> obrasSociales = gestorObrasSociales.obtenerOSePaciente(idObraPaciente);
                return obrasSociales;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string actualizarOSPaciente(string p_idObraPaciente, string p_plan, string p_nroAfiliado)
        {

            ObrasPacientes obrasPaciente = new ObrasPacientes();
            GestorPacientes gestorPacientes = new GestorPacientes();

            try
            {
                string mensaje = "OK";

                #region Completa entidad obrasPaciente

                if (!string.IsNullOrEmpty(p_idObraPaciente))
                {
                    obrasPaciente.IdObraPaciente = Convert.ToInt32(p_idObraPaciente);
                }

                if (!string.IsNullOrEmpty(p_plan))
                {
                    obrasPaciente.IdPlan = Convert.ToInt32(p_plan);
                }

                if (!string.IsNullOrEmpty(p_nroAfiliado))
                {
                    obrasPaciente.nroAfiliado = p_nroAfiliado;
                }

                obrasPaciente.UsuarioMod = 1;
                obrasPaciente.FechaMod = DateTime.Today;


                #endregion

                gestorPacientes.actualizarOSPaciente(obrasPaciente);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al actualizar la obra social del paciente " + e.Message;
                return error;
            }

        }


        //[WebMethod]
        //public static string inactivarPaciente(string idPaciente)
        //{

        //    Paciente paciente = new Paciente();
        //    GestorPacientes gestorPacientes = new GestorPacientes();

        //    try
        //    {
        //        string mensaje = "OK";


        //        paciente.IdPaciente = Convert.ToInt32(idPaciente);
        //        paciente.UsuarioBaja = 1;
        //        paciente.FechaBaja = DateTime.Today;


        //        gestorPacientes.inactivarPaciente(paciente);

        //        return mensaje;
        //    }
        //    catch (Exception e)
        //    {
        //        string error = "Se produjo un error al registrar el paciente " + e.Message;
        //        return error;
        //    }

        //}

        [WebMethod]
        public static string validarDni(string dni)
        {

            string result = "OK";
            try
            {
                GestorPacientes gPaciente = new GestorPacientes();

                int existePersonal = gPaciente.validarDniPaciente(dni);

                if (existePersonal > 0)
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
        public static string buscarPacienteParticular(string idPaciente)
        {
            try
            {
                GestorPacientes gestorPacientes = new GestorPacientes();
                DataTable dt = gestorPacientes.buscarPacienteParticular(idPaciente);
                string col = JsonConvert.SerializeObject(dt);

                return col;
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
                GestorPacientes gestorPaciente = new GestorPacientes();

                int id = Convert.ToInt32(p_id);

                int cantTurnosFuturos = gestorPaciente.TurnosFuturos(id);

                if (cantTurnosFuturos > 0)
                {

                    DataTable dt = gestorPaciente.ObtenerTurnosFuturos(id);
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
                GestorPacientes gestorPaciente = new GestorPacientes();

                int id = Convert.ToInt32(p_id);

                DataTable dt = gestorPaciente.ObtenerTurnosFuturos(id);
                string col = JsonConvert.SerializeObject(dt);
                return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string DaDarDeBajaPaciente(string p_id)
        {

            string col = "OK";
            try
            {

                GestorPacientes gestorPacientes = new GestorPacientes();
                Paciente paciente = new Paciente();

                int id = Convert.ToInt32(p_id);

                string resultadoBajaObraPaciente = gestorPacientes.DaDarDeBajaObraPaciente(id, 1);

                if (resultadoBajaObraPaciente == "OK")
                {
                    paciente.IdPaciente = id;
                    paciente.UsuarioBaja = 1;
                    paciente.FechaBaja = DateTime.Today;

                    col = gestorPacientes.DarBajaPaciente(paciente);                                     

                }

                return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string DarDeBajaPacienteTurnos(string p_id)
        {

            string col = "OK";
            try
            {

                GestorPacientes gestorPaciente = new GestorPacientes();
                Paciente paciente = new Paciente();

                int id = Convert.ToInt32(p_id);

            
                string resultadoBajaObraPaciente = gestorPaciente.DaDarDeBajaObraPaciente(id, 1);

                if (resultadoBajaObraPaciente == "OK")
                {

                    int cantIdTratamiento = gestorPaciente.obtenerTratamientos(id);
                    

                    if (cantIdTratamiento > 0)
                    {

                        string resultadoBajaTratamiento = gestorPaciente.DarBajaTratamiento(id, 1);

                        if (resultadoBajaTratamiento == "OK") {

                            string resultadoBajaTurnos = gestorPaciente.DarBajaTurnos(id, 1);


                            if (resultadoBajaTurnos == "OK")
                            {
                                                               

                                    paciente.IdPaciente = id;
                                    paciente.UsuarioBaja = 1;
                                    paciente.FechaBaja = DateTime.Today;

                                    col = gestorPaciente.DarBajaPaciente(paciente);
                                                     

                            }
                        }
                        
                    }
                    else
                    {
                        string resultadoBajaTurnos = gestorPaciente.DarBajaTurnos(id, 1);


                        if (resultadoBajaTurnos == "OK")
                        {
                            
                                paciente.IdPaciente = id;
                                paciente.UsuarioBaja = 1;
                                paciente.FechaBaja = DateTime.Today;

                                col = gestorPaciente.DarBajaPaciente(paciente);
                            

                        }

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