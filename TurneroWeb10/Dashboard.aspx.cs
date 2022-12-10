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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]

        public static List<object> traerCantidadTurnosTotales(DateTime p_fecha_desde, DateTime p_fecha_hasta)
        {
            try
            {
                GestorDashboard gestorDashboard = new GestorDashboard();

                List<object> listaTurnos = gestorDashboard.traerCantidadTiposTurnosTotales(p_fecha_desde, p_fecha_hasta);
                return listaTurnos;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //[WebMethod]
        //public static string cantidadTurnosSucursal(DateTime p_fecha_desde, DateTime p_fecha_hasta, int p_sucursal) {

        //    GestorDashboard gestorDashboard = new GestorDashboard();

        //    try
        //    {

        //        int cantidadTurnosSucursal = gestorDashboard.cantidadTurnosSucursal(p_fecha_desde, p_fecha_hasta, p_sucursal);

        //        return Convert.ToString(cantidadTurnosSucursal);

        //    }
        //    catch (Exception e) { 

        //    string error = "Se produjo un error al obtener cantidad total de turnos de la sucursal " + p_sucursal + "." + e.Message;
        //        return error;
        //    }
        //}

        [WebMethod]
        public static List<object> traerEspecialidadesMasDemandadas(DateTime p_fecha_desde, DateTime p_fecha_hasta)
        {


            try
            {

                GestorDashboard gestorDashboard = new GestorDashboard();

                List<object> especialidadesMasDemandadas = gestorDashboard.traerEspecialidadesMasDemandadas(p_fecha_desde, p_fecha_hasta);
                return especialidadesMasDemandadas;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [WebMethod]
        public static List<object> traerEspecialidadesMenosDemandadas(DateTime p_fecha_desde, DateTime p_fecha_hasta)
        {


            try
            {

                GestorDashboard gestorDashboard = new GestorDashboard();

                List<object> especialidadesMenosDemandadas = gestorDashboard.traerEspecialidadesMenosDemandadas(p_fecha_desde, p_fecha_hasta);
                return especialidadesMenosDemandadas;

            }
            catch (Exception e)
            {
                throw e;
            }

        }


        [WebMethod]
        public static List<object> obtenerEspecialidadesMasDemandadasPorSucursal(DateTime p_fecha_desde, DateTime p_fecha_hasta)
        {


            try
            {

                GestorDashboard gestorDashboard = new GestorDashboard();

                List<object> especMasDemPorSucursal = gestorDashboard.obtenerEspecialidadesMasDemandadasPorSucursal(p_fecha_desde, p_fecha_hasta);
                return especMasDemPorSucursal;

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [WebMethod]
        public static List<object> obtenerEspecialidadesMenosDemandadasPorSucursal(DateTime p_fecha_desde, DateTime p_fecha_hasta)
        {


            try
            {

                GestorDashboard gestorDashboard = new GestorDashboard();

                List<object> especMenosDemPorSucursal = gestorDashboard.obtenerEspecialidadesMenosDemandadasPorSucursal(p_fecha_desde, p_fecha_hasta);
                return especMenosDemPorSucursal;

            }
            catch (Exception e)
            {
                throw e;
            }

        }


        [WebMethod]

        public static List<object> ObtenerTipoObraSocialSparring(DateTime p_fecha_desde, DateTime p_fecha_hasta)
        {
            try
            {
                GestorDashboard gestorDashboard = new GestorDashboard();

                List<object> listaOsSparring = gestorDashboard.obtenerTiposObraSocialSparring(p_fecha_desde, p_fecha_hasta);
                return listaOsSparring;

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [WebMethod]

        public static List<object> ObtenerCantTurnosPorSucursal(DateTime p_fecha_desde, DateTime p_fecha_hasta)
        {
            try
            {
                GestorDashboard gestorDashboard = new GestorDashboard();

                List<object> listaTurnosPorSucursal = gestorDashboard.obtenerCantTurnosPorSucursal(p_fecha_desde, p_fecha_hasta);
                return listaTurnosPorSucursal;

            }
            catch (Exception e)
            {
                throw e;
            }
        }





    }
}