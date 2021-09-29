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
        public static string traerTurnosDelDia()
        {
            try
            {
                string result = "ok";

                GestorTurno gTurnos = new GestorTurno();
                DataTable dt = gTurnos.TraerTurnosDelDia();
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