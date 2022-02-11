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
    public partial class InformeObras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static List<Centro> cargarCentros()
        {
            try
            {
                GestorCentros gestorCentros = new GestorCentros();
                List<Centro> centros = gestorCentros.obtenerCentro();
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
        public static string traerTurnosInformes(string idSucursal, string idObraSocial, string fechaDesde, string fechaHasta)
        {
            try
            {
                GestorTurno gestorTurno = new GestorTurno();
                DataTable dt = gestorTurno.TraerTurnosInformes(idSucursal, idObraSocial, fechaDesde, fechaHasta);
                string col = JsonConvert.SerializeObject(dt);

                return col;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}