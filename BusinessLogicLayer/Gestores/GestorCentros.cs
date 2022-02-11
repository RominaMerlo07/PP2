using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.ent;
using DataAccess;

namespace BusinessLogicLayer.Gestores
{
    public class GestorCentros
    {
        public List<Centro> traerCentros()
        {
            try
            {
                DACentros daCentros = new DACentros();
                List<Centro> list = daCentros.traerCentros();

                if (list.Count > 0)
                {
                    return list;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string RegistrarCentros(Centro centro)
        {
            try
            {
                DACentros DaCentros = new DACentros();
                return DaCentros.DaRegistrarCentros(centro);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string ActualizarCentros(Centro centro)
        {
            try
            {
                DACentros DaCentros = new DACentros();
                return DaCentros.DaActualizarCentro(centro);
            }
            catch (Exception e) 
            {
                throw e;
            }      
        }


        public Centro obtenerCentro(int IdCentro)
        {
            try
            {
                DACentros daCentros = new DACentros();
                return daCentros.obtenerCentro(IdCentro);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string  DarDeBajaCentro(Centro centro)
        {
            try 
            
            {

                DACentros daCentros = new DACentros();
                return daCentros.DaDarDeBajaCentro(centro);
            
            }
            catch (Exception e)
            {
                throw e;
            }


        }

    }




}


