using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;

namespace BusinessLogicLayer.Gestores
{
    public class GestorDisponibilidadHoraria
    {    
        public string RegistrarDisponibilidad(DisponibilidadHoraria disponibilidad)
        {
            string mensaje = "OK";

            try
            {
                DADisponibilidadHoraria DADisponibilidad= new DADisponibilidadHoraria();
                DADisponibilidad.DaRegistrarDisponibilidad(disponibilidad);

                return mensaje;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
