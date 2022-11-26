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


        public List<ObraSocial> cargarObrasSocialesPaciente(string IdPaciente)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                List<ObraSocial> list = daObrasSociales.cargarObrasSocialesPaciente(IdPaciente);

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


        //public List<ObraSocial> cargarObrasSocialesById(string idCentro)
        //{
        //    try
        //    {
        //        DAObrasSociales daObrasSociales = new DAObrasSociales();
        //        List<ObraSocial> list = daObrasSociales.cargarObrasSocialesById(idCentro);

        //        if (list.Count > 0)
        //        {
        //            return list;
        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        //public void DarBajaObraSocial(ObraSocial obraSocial)
        //{
        //    try
        //    {
        //        DAObrasSociales daObrasSociales = new DAObrasSociales();
        //        daObrasSociales.DarBajaObraSocial(obraSocial);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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

        public DataTable TraerPlanesAll(string idObraSocial)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                return daObrasSociales.TraerPlanesAll(idObraSocial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable cargarPlanesPacientes(string idObraSocial, string idPaciente)
        {
            try
            {
                DAObrasSociales daObrasSociales = new DAObrasSociales();
                return daObrasSociales.cargarPlanesPacientes(idObraSocial, idPaciente);
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
                //DACentros centros = new DACentros();
                //List<Centro> listaCentros = centros.traerCentros();

                //foreach (Centro centro in listaCentros)
                //{
                //    obraSocial.Centro = centro;
                //    DAObrasSociales daObrasSociales = new DAObrasSociales();
                //    daObrasSociales.AgregarObraSocial(obraSocial);
                //}

                DAObrasSociales daObrasSociales = new DAObrasSociales();
                daObrasSociales.AgregarObraSocial(obraSocial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public List<ObraSocial> obtenerOSPacientes()
        //{
        //    try
        //    {
        //        DAObrasSociales daObrasSociales = new DAObrasSociales();
        //        List<ObraSocial> list = daObrasSociales.obtenerOSPacientes();

        //        if (list.Count > 0)
        //        {
        //            return list;
        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

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

        public int validarObraSocial(string obraSocial)
        {

            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.validarObraSocial(obraSocial);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ObraSocial cargarObrasSociales(int idObraSocial)
        {
            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.cargarObrasSociales(idObraSocial);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string editarObraSocial(ObraSocial obraSocial)
        {
            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.editarObraSocial(obraSocial);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int validarPlan(int id_obraSocial, string plan)
        {

            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.validarPlan(id_obraSocial, plan);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public ObrasPlanes cargarPlan(int idPlan)
        {
            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.cargarPlan(idPlan);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string editarPlan(ObrasPlanes obrasPlanes)
        {
            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.editarPlan(obrasPlanes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int TurnosFuturos(int idObraSocial)
        {
            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.TurnosFuturos(idObraSocial);

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public DataTable ObtenerTurnosFuturos(int idObraSocial)
        {
            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.ObtenerTurnosFuturos(idObraSocial);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DaDarDeBajaTurnos(int idObraSocial, int usuarioBaja)
        {
            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.DaDarDeBajaTurnos(idObraSocial, usuarioBaja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string darBajaObraSocial(ObraSocial obraSocial)
        {
            try

            {

                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.darBajaObraSocial(obraSocial);

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string darBajaObraSocialPaciente(ObraSocial obraSocial)
        {
            try

            {

                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.darBajaObraSocialPaciente(obraSocial);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int obtenerTratamientos(int idObraSocial)
        {
            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.obtenerTratamientos(idObraSocial);

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public string DarBajaTratamiento(int idObraSocial, int usuarioBaja)
        {
            try
            {
                DAObrasSociales DaObrasSociales = new DAObrasSociales();
                return DaObrasSociales.DarBajaTratamiento(idObraSocial, usuarioBaja);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }


}
