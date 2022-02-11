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
    public partial class ObrasSociales : System.Web.UI.Page
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
        public static string traerObrasSociales()
        {
            try
            {
                GestorObrasSociales gObrasSociales = new GestorObrasSociales();
                List<ObraSocial> obrasSociales = gObrasSociales.obtenerObrasSociales();
                string json = JsonConvert.SerializeObject(obrasSociales);
                return json;
                //return obrasSociales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static void darBajaObraSocial(string idObraSocial)
        {
            try
            {
                GestorObrasSociales gObrasSociales = new GestorObrasSociales();
                ObraSocial obraSocial = new ObraSocial();
                obraSocial.IdObraSocial = Convert.ToInt32(idObraSocial);
                obraSocial.UsuarioBaja = 1;
                obraSocial.FechaBaja = DateTime.Now;
                gObrasSociales.DarBajaObraSocial(obraSocial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static string traerPlanes (string idObraSocial)
        {
            GestorObrasSociales gObrasSociales = new GestorObrasSociales();
            DataTable planes = gObrasSociales.TraerPlanes(idObraSocial);
            string json = JsonConvert.SerializeObject(planes);
            return json;
        }

        [WebMethod]
        public static void darBajaPlan(string idPlan)
        {
            try
            {
                GestorObrasSociales gObrasSociales = new GestorObrasSociales();
                ObrasPlanes plan = new ObrasPlanes();
                plan.IdPlanes = Convert.ToInt32(idPlan);
                plan.UsuarioBaja = 1;
                plan.FechaBaja = DateTime.Now;
                gObrasSociales.DarBajaPlan(plan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static void agregarPlan(string idObraSocial, string nombrePlan)
        {
            try
            {
                GestorObrasSociales gObrasSociales = new GestorObrasSociales();
                ObrasPlanes plan = new ObrasPlanes();
                plan.Descripcion = nombrePlan;
                plan.IdObraSocial = Convert.ToInt32(idObraSocial);
                plan.UsuarioAlta = 1;
                plan.FechaAlta = DateTime.Now;

                gObrasSociales.AgregarPlan(plan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static void agregarObraSocial(string obraSocial)
        {
            try
            {
                GestorObrasSociales gObrasSociales = new GestorObrasSociales();
                ObraSocial obraSoc = new ObraSocial();
                obraSoc.Descripcion = obraSocial;
                obraSoc.UsuarioAlta = 1;
                obraSoc.FechaAlta = DateTime.Now;

                gObrasSociales.AgregarObraSocial(obraSoc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}