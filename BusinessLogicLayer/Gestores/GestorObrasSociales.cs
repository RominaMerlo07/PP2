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
    public class GestorObrasSociales
    {
        public List<ObraSocial> obtenerObrasSociales()
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                List<ObraSocial> list = daObrasSociales.traerObrasSociales();

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

        public List<ObraSocial> cargarObrasSocialesById(string idCentro)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                List<ObraSocial> list = daObrasSociales.cargarObrasSocialesById(idCentro);

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

        public void DarBajaObraSocial(ObraSocial obraSocial)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                daObrasSociales.DarBajaObraSocial(obraSocial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TraerPlanes(string idObraSocial)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                return daObrasSociales.TraerPlanes(idObraSocial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DarBajaPlan(ObrasPlanes plan)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                daObrasSociales.DarBajaPlan(plan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarPlan(ObrasPlanes plan)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                daObrasSociales.AgregarPlan(plan);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarObraSocial(ObraSocial obraSocial)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                daObrasSociales.AgregarObraSocial(obraSocial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ObraSocial> obtenerOSPacientes()
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                List<ObraSocial> list = daObrasSociales.obtenerOSPacientes();

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

        public List<ObraSocial> obtenerOSxPaciente(string idPaciente)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                List<ObraSocial> list = daObrasSociales.obtenerOSxPaciente(idPaciente);

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

        public List<ObraSocial> obtenerOSePaciente(string idObraPaciente)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                List<ObraSocial> list = daObrasSociales.obtenerOSePaciente(idObraPaciente);

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

    }


}
