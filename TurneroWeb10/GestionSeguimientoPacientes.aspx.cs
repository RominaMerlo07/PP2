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
using Newtonsoft.Json.Linq;

namespace TurneroWeb10
{
    public partial class GestionSeguimientoPacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string buscarPaciente(string dniPaciente)
        {
            try
            {
                GestorPacientes gPacientes = new GestorPacientes();
                Paciente paciente = new Paciente();
                paciente = gPacientes.BuscarPaciente(dniPaciente);
                string col = JsonConvert.SerializeObject(paciente);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string registrarHistoriaClinica(string historiaClinica)
        {
            try
            {
                JObject obj = JObject.Parse(historiaClinica);

                Paciente paciente = new Paciente();
                HistoriaClinica histClinica = new HistoriaClinica();

                paciente.IdPaciente = Convert.ToInt32(obj.GetValue("p_idPaciente").ToString());
                paciente.Nombre = obj.GetValue("p_nombrePaciente").ToString();
                paciente.Apellido = obj.GetValue("p_apellidoPaciente").ToString();
                paciente.Documento = obj.GetValue("p_documentoPaciente").ToString(); 
                paciente.NroContacto = obj.GetValue("p_nroPaciente").ToString();
                paciente.EmailContacto = obj.GetValue("p_emailPaciente").ToString();

                histClinica.Tension = Convert.ToBoolean(obj.GetValue("p_tension").ToString());
                histClinica.TensionValores = obj.GetValue("p_tension").ToString();
                histClinica.Diabetes = Convert.ToBoolean(obj.GetValue("p_diabetes").ToString());
                histClinica.Fumador = Convert.ToBoolean(obj.GetValue("p_fumador").ToString());
                histClinica.Cardiaco = Convert.ToBoolean(obj.GetValue("p_cardiaco").ToString());
                histClinica.Cirrosis = Convert.ToBoolean(obj.GetValue("p_cirrosis").ToString());
                histClinica.Artrosis = Convert.ToBoolean(obj.GetValue("p_artrosis").ToString());
                histClinica.ArtritisRematoidea = Convert.ToBoolean(obj.GetValue("p_artritis").ToString());
                histClinica.Hemiplejia = Convert.ToBoolean(obj.GetValue("p_hemiplejia").ToString());
                histClinica.Asma = Convert.ToBoolean(obj.GetValue("p_asma").ToString());
                histClinica.Marcapasos = Convert.ToBoolean(obj.GetValue("p_marcapasos").ToString());
                histClinica.Protesis = Convert.ToBoolean(obj.GetValue("p_protesis").ToString());
                histClinica.CaderaDerecha = Convert.ToBoolean(obj.GetValue("p_caderaDer").ToString());
                histClinica.CaderaIzquierda = Convert.ToBoolean(obj.GetValue("p_caderaIzq").ToString());
                histClinica.Otros = obj.GetValue("p_otros").ToString();
                histClinica.Antecedentes = obj.GetValue("p_antecedentes").ToString();

                Usuario usuario = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];
                histClinica.UsuarioAlta = usuario.IdUsuario;
                histClinica.FechaAlta = DateTime.Now;


                paciente.HistoriaClinica = histClinica;
                GestorHistoriaClinica gHistClinica = new GestorHistoriaClinica();
                gHistClinica.RegistrarHistClinica(paciente);


                return "bien" ;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
    }
}