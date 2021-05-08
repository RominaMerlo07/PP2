using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.Gestores;
using Entidades.ent;


namespace TurneroWeb10
{
    public partial class RegistrarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string registrarPaciente(string p_dni, string p_nombre, string p_apellido, string p_fechaNac, string p_obraSocial,
                                               string p_calle, string p_numero, string p_barrio, string p_localidad, string p_celular, string p_email1, string p_email2)
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

                if (!string.IsNullOrEmpty(p_fechaNac))
                {
                    paciente.FechaNacimiento = Convert.ToDateTime(p_fechaNac);
                }

                if ((!string.IsNullOrEmpty(p_calle)) && (!string.IsNullOrEmpty(p_numero)))
                {
                    string domicilio = p_calle + " " + p_numero + " Barrio: " + p_barrio;
                    paciente.Domicilio = domicilio;
                }

                if (!string.IsNullOrEmpty(p_localidad))
                {
                    paciente.Localidad = p_localidad;
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

                //Sumar Campo de Obra Social

                //if (!string.IsNullOrEmpty(p_obra_social))   
                //{
                //    ObraSocial obraSocial = new ObraSocial(p_obra_social, centro.IdCentro);
                //    turno.ObraSocial = obraSocial;
                //}                


                #endregion

                gestorPacientes.RegistrarPaciente(paciente);

                return mensaje;
            }
            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el paciente " + e.Message;
                return error;
            }

        }

    }


    
}