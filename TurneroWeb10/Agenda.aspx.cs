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
        public static string traerTurnosDelDia(string idCentro, string dia)
        {
            try
            {
               

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
        public static string TraeEstadosFecha()
        {
            try
            {
                GestorTurno gestorTurno = new GestorTurno();
                DataTable estados = gestorTurno.TraeEstadosFecha();
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

                if (estado == "CANCELADO")                {

                    gestorTurno.CancelarTurno(idturno, estado);
                }
                else {

                    gestorTurno.ModificarEstadoEnTurno(idturno, estado);

                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static void modificarNroOrden(string idturno, string autorizacion)
        {
            try
            {
                GestorTurno gestorTurno = new GestorTurno();
                gestorTurno.ModificarNroOrden(idturno, autorizacion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [WebMethod]
        public static string buscarTurnosVencidos()
        {

            try
            {
                GestorTurno gestorTurno = new GestorTurno();

                DataTable dt = gestorTurno.buscarTurnosVencidos();
                string col = JsonConvert.SerializeObject(dt);
                return col;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //[WebMethod]
        //public string cancelarTurnos(string p_id)
        //{
        //    try
        //    {
        //        string resultado;

        //        GestorTurno gestorTurno = new GestorTurno();
        //        resultado = gestorTurno.cancelarTurnos(p_id);

        //        return resultado;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}



        [WebMethod]
        public static string cancelarTurnos(string p_id)
        {
            GestorTurno gestorTurno = new GestorTurno();

            try
            {
                string mensaje = "OK";

                gestorTurno.cancelarTurnos(p_id);

                return mensaje;
            }

            catch (Exception e)
            {
                string error = "Se produjo un error al registrar el profesional " + e.Message;
                return error;
            }

        }


    }
}