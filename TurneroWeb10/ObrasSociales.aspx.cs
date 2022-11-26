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

        //[WebMethod]
        //public static void darBajaObraSocial(string idObraSocial)
        //{
        //    try
        //    {
        //        GestorObrasSociales gObrasSociales = new GestorObrasSociales();
        //        ObraSocial obraSocial = new ObraSocial();
        //        obraSocial.IdObraSocial = Convert.ToInt32(idObraSocial);
        //        obraSocial.UsuarioBaja = 1;
        //        obraSocial.FechaBaja = DateTime.Now;
        //        gObrasSociales.DarBajaObraSocial(obraSocial);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [WebMethod]
        public static string traerPlanes (string idObraSocial)
        {
            GestorObrasSociales gObrasSociales = new GestorObrasSociales();
            DataTable planes = gObrasSociales.TraerPlanes(idObraSocial);
            string json = JsonConvert.SerializeObject(planes);
            return json;
        }


        [WebMethod]
        public static string traerPlanesAll(string idObraSocial)
        {
            GestorObrasSociales gObrasSociales = new GestorObrasSociales();
            DataTable planes = gObrasSociales.TraerPlanesAll(idObraSocial);
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


        [WebMethod]
        public static string validarObraSocial(string obraSocial)
        {

            string result = "OK";
            try
            {
                GestorObrasSociales gObrasSociales = new GestorObrasSociales();

                int existeOS = gObrasSociales.validarObraSocial(obraSocial);

                if (existeOS > 0)
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
        public static ObraSocial cargarObrasSociales(string idObraSocial)
        {
            try
            {
                int id = Convert.ToInt32(idObraSocial);

                GestorObrasSociales gestorOS = new GestorObrasSociales();
                ObraSocial obraSocial = new ObraSocial();
                obraSocial = gestorOS.cargarObrasSociales(id);

                return obraSocial;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string editarObraSocial(string p_id, string p_descripcion)
        {
            ObraSocial obraSocial = new ObraSocial();
            GestorObrasSociales gestorOS = new GestorObrasSociales();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Obra Social

                if (!string.IsNullOrEmpty(p_descripcion))
                {
                    obraSocial.Descripcion = p_descripcion;
                }

                obraSocial.IdObraSocial = Convert.ToInt32(p_id);

                obraSocial.UsuarioMod = 1;
                obraSocial.FechaMod = DateTime.Today;

                #endregion

                gestorOS.editarObraSocial(obraSocial);

                return mensaje;
            }

            catch (Exception e)
            {
                string error = "Se produjo un error al registrar la obra social " + e.Message;
                return error;
            }

        }

        [WebMethod]
        public static string validarPlan(string p_id, string p_descripcion)
        {

            string result = "OK";
            try
            {
                GestorObrasSociales gObrasSociales = new GestorObrasSociales();

                var id = Convert.ToInt32(p_id);

                int existeOS = gObrasSociales.validarPlan(id, p_descripcion);

                if (existeOS > 0)
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
        public static ObrasPlanes cargarPlan(string idPlan)
        {
            try
            {
                int id = Convert.ToInt32(idPlan);

                GestorObrasSociales gestorOS = new GestorObrasSociales();
                ObrasPlanes obrasPlanes = new ObrasPlanes();
                obrasPlanes = gestorOS.cargarPlan(id);

                return obrasPlanes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string editarPlan(string p_id, string p_descripcion)
        {
            ObrasPlanes obrasPlanes = new ObrasPlanes();
            GestorObrasSociales gestorOS = new GestorObrasSociales();

            try
            {
                string mensaje = "OK";

                #region Completa entidad Obra Social

                if (!string.IsNullOrEmpty(p_descripcion))
                {
                    obrasPlanes.Descripcion = p_descripcion;
                }

                obrasPlanes.IdPlanes = Convert.ToInt32(p_id);

                obrasPlanes.UsuarioMod = 1;
                obrasPlanes.FechaMod = DateTime.Today;

                #endregion

                gestorOS.editarPlan(obrasPlanes);

                return mensaje;
            }

            catch (Exception e)
            {
                string error = "Se produjo un error al editar el plan " + e.Message;
                return error;
            }

        }


        [WebMethod]
        public static string ObtenerTurnosFuturos(string p_id)
        {

            string col = "sin info";

            try
            {
                GestorObrasSociales gestorOS = new GestorObrasSociales();

                int id = Convert.ToInt32(p_id);

                int cantTurnosFuturos = gestorOS.TurnosFuturos(id);

                if (cantTurnosFuturos > 0)
                {

                    DataTable dt = gestorOS.ObtenerTurnosFuturos(id);
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

            string col = "sin info";

            try
            {
                GestorObrasSociales gestorOS = new GestorObrasSociales();

                int id = Convert.ToInt32(p_id);
                DataTable dt = gestorOS.ObtenerTurnosFuturos(id);
                col = JsonConvert.SerializeObject(dt);
                return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]
        public static string DarDeBajaTurnos(string p_id)
        {

            string col = "OK";
            try
            {

                GestorObrasSociales gestorOS = new GestorObrasSociales();
                ObraSocial obraSocial = new ObraSocial();

                int id = Convert.ToInt32(p_id);

                int cantIdTratamiento = gestorOS.obtenerTratamientos(id);

                if (cantIdTratamiento > 0) {

                    string resultadoBajaTratamiento = gestorOS.DarBajaTratamiento(id, 1);

                    if (resultadoBajaTratamiento == "OK") {

                        string resultado = gestorOS.DaDarDeBajaTurnos(id, 1);

                        if (resultado == "OK")
                        {
                            obraSocial.IdObraSocial = id;
                            obraSocial.UsuarioBaja = 1;
                            obraSocial.FechaBaja = DateTime.Today;

                            col = gestorOS.darBajaObraSocial(obraSocial);
                        }

                    }                    

                }
                else
                {

                    string resultado = gestorOS.DaDarDeBajaTurnos(id, 1);

                    if (resultado == "OK")
                    {
                        obraSocial.IdObraSocial = id;
                        obraSocial.UsuarioBaja = 1;
                        obraSocial.FechaBaja = DateTime.Today;

                        col = gestorOS.darBajaObraSocial(obraSocial);
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
        public static string darBajaObraSocial(string p_id)
        {
            GestorObrasSociales gestorOS = new GestorObrasSociales();
            ObraSocial obraSocial = new ObraSocial();

            try
            {
                string mensaje = "OK";

                obraSocial.IdObraSocial = Convert.ToInt32(p_id);
                obraSocial.UsuarioBaja = 1;
                obraSocial.FechaBaja = DateTime.Today;

                var resultado = gestorOS.darBajaObraSocialPaciente(obraSocial);

                if (resultado == "OK")
                {

                    mensaje = gestorOS.darBajaObraSocial(obraSocial);

                }

                return mensaje;
            }
            catch (Exception e)
            {
                throw e;
            }

        }


    }
}