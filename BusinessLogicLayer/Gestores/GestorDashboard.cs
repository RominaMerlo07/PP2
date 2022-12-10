using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;
using System.Data;

namespace BusinessLogicLayer.Gestores
{
    public class GestorDashboard
    {

        public List<object> traerCantidadTiposTurnosTotales(DateTime fecha_desde, DateTime fecha_hasta)
        {

            try
            {
                DADashboard DaDashboard = new DADashboard();
                return DaDashboard.traerCantidadTiposTurnosTotales(fecha_desde, fecha_hasta);
            }
            catch (Exception e)
            {
                throw e;
            }


        }


        //public int cantidadTurnosSucursal(DateTime fecha_desde, DateTime fecha_hasta, int sucursal)
        //{
        //    try {

        //        DADashboard dADashboard = new DADashboard();
        //        return dADashboard.obtenerCantTurnosSucursal(fecha_desde, fecha_hasta, sucursal);

        //    }

        //    catch (Exception e) {
        //        throw e;

        //    }


        //}

        public List<object> traerEspecialidadesMasDemandadas(DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                DADashboard dADashboard = new DADashboard();
                return dADashboard.traerEspecialidadesMasDemandadas(fecha_desde, fecha_hasta);
            }

            catch (Exception e)
            {

                throw e;
            }

        }

        public List<object> traerEspecialidadesMenosDemandadas(DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                DADashboard dADashboard = new DADashboard();
                return dADashboard.traerEspecialidadesMenosDemandadas(fecha_desde, fecha_hasta);
            }

            catch (Exception e)
            {

                throw e;
            }

        }

        public List<object> obtenerEspecialidadesMasDemandadasPorSucursal(DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                DADashboard dADashboard = new DADashboard();
                return dADashboard.obtenerEspMasDemandadaPorSuc(fecha_desde, fecha_hasta);
            }

            catch (Exception e)
            {

                throw e;
            }

        }

        public List<object> obtenerEspecialidadesMenosDemandadasPorSucursal(DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                DADashboard dADashboard = new DADashboard();
                return dADashboard.obtenerEspMenosDemandadaPorSuc(fecha_desde, fecha_hasta);
            }

            catch (Exception e)
            {

                throw e;
            }

        }


        public List<object> obtenerTiposObraSocialSparring(DateTime fecha_desde, DateTime fecha_hasta)
        {

            try
            {
                DADashboard DaDashboard = new DADashboard();
                return DaDashboard.obtenerTiposObrasSocialesSparring(fecha_desde, fecha_hasta);
            }
            catch (Exception e)
            {
                throw e;
            }


        }


        public List<object> obtenerCantTurnosPorSucursal(DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                DADashboard dADashboard = new DADashboard();
                return dADashboard.obtenerTiposDeTurnosPorSucursal(fecha_desde, fecha_hasta);
            }

            catch (Exception e)
            {

                throw e;
            }

        }





    }
}
