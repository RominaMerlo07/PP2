﻿using Entidades.ent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TurneroWeb10
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static string traerRol()
        {
            Usuario usr = (Usuario)HttpContext.Current.Session["TURNERO.Usuario"];
            return usr.Rol.NombreRol;
        }
        
    }
}