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
    public partial class Agenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string traerTurnosDelDia(string idCentro, string dia)
        {
            try
            {
                string result = "ok";

                GestorTurno gTurnos = new GestorTurno();
                DataTable dt = gTurnos.TraerTurnosDelDia(idCentro, dia);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static List<Centro> cargarCentros()
        {
            try
            {
                GestorCentros gestorCentros = new GestorCentros();
                List<Centro> centros = gestorCentros.obtenerCentros();
                return centros;
                //string col = JsonConvert.SerializeObject(centros);
                //return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string traeEstados()
        {
            try
            {
                GestorTurno gestorTurno = new GestorTurno();
                DataTable estados = gestorTurno.TraeEstados();
                string col = JsonConvert.SerializeObject(estados);
                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        [WebMethod]
        public static void modificarEstadoEnTurno(string idturno, string estado)
        {
            try
            {
                GestorTurno gestorTurno = new GestorTurno();
                gestorTurno.ModificarEstadoEnTurno(idturno, estado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}