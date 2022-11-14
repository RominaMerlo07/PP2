using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;
using System.Data;

namespace BusinessLogicLayer.Gestores
{
    public class GestorPersonal
    {

        public int DaRegistrarPersonal(Personal personal)
        {
            try
            {
                DAPersonal DAPersonal = new DAPersonal();
                return DAPersonal.DaRegistrarPersonal(personal);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<Personal> obtenerPersonal()
        {
            try
            {
                DAPersonal daPersonal = new DAPersonal();
                List<Personal> list = daPersonal.traerPersonal();

                if (list.Count > 0)
                {
                    return list;
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Personal obtenerPersonal(int idPersonal)
        {
            try
            {
                DAPersonal daPersonal = new DAPersonal();
                return daPersonal.obtenerPersonal(idPersonal);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        public string ActualizarPersonal(Personal personal)
        {
            try
            {
                DAPersonal DaPersonal = new DAPersonal();
                return DaPersonal.ActualizarPersonal(personal);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string DarBajaPersonal(Personal personal)
        {
            try
            {
                DAPersonal DaPersonal = new DAPersonal();
                return DaPersonal.DarBajaPersonal(personal);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int validarDniPersonal(string dni) {

            try
            {
                DAPersonal DaPersonal = new DAPersonal();
                return DaPersonal.validarDniPersonal(dni);
            }
            catch (Exception e)
            {
                throw e;
            }
        }        

    }



}
