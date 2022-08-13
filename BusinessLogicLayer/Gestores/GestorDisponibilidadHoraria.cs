using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;

namespace BusinessLogicLayer.Gestores
{
    public class GestorDisponibilidadHoraria
    {
        //public string RegistrarDisponibilidad(DisponibilidadHoraria disponibilidad)
        //{
        //    string mensaje = "OK";

        //    try
        //    {
        //        DADisponibilidadHoraria DADisponibilidad= new DADisponibilidadHoraria();
        //        DADisponibilidad.DaRegistrarDisponibilidad(disponibilidad);

        //        return mensaje;
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //}

        public List<DisponibilidadHoraria> TraerHorariosProfesional(string idProfesional)
        {
            try
            {

                DADisponibilidadHoraria DADisponibilidad = new DADisponibilidadHoraria();
                return DADisponibilidad.DaTraerHorariosProfesional(idProfesional);
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DisponibilidadHoraria TraerHorario(string idDisponibilidad)
        {
            try
            {

                DADisponibilidadHoraria DADisponibilidad = new DADisponibilidadHoraria();
                return DADisponibilidad.TraerHorario(idDisponibilidad);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public String ValidarDisponibilidad(string idProfesional, DisponibilidadHoraria horarioDisponibilidad)
        {
            try
            {
                DADisponibilidadHoraria DADisponibilidad = new DADisponibilidadHoraria();
                return DADisponibilidad.ValidarDisponibilidad(idProfesional, horarioDisponibilidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public String RegistrarDisponibilidad(string idProfesional, DisponibilidadHoraria horarioDisponibilidad)
        {
            try
            {
                DADisponibilidadHoraria DADisponibilidad = new DADisponibilidadHoraria();
                return DADisponibilidad.RegistrarDisponibilidad(idProfesional, horarioDisponibilidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public String ConsultarTurnosEnDisponibilidad(string idDisponibilidad, string idProfesional)
        {
            try
            {
                DADisponibilidadHoraria DADisponibilidad = new DADisponibilidadHoraria();
                return DADisponibilidad.ConsultarTurnosEnDisponibilidad(idDisponibilidad, idProfesional);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public String DarDeBajaDisponibilidad(string idDisponibilidad, string idProfesional, int idUsuarioMod)
        {
            try
            {
                DATurno DATurnos = new DATurno();
                bool status = DATurnos.CambiarEstadoReprogramarTurnos(idDisponibilidad, idProfesional, idUsuarioMod);

                if (status)
                {
                    DADisponibilidadHoraria DADisponibilidad = new DADisponibilidadHoraria();
                    return DADisponibilidad.DarDeBajaDisponibilidad(idDisponibilidad, idProfesional, idUsuarioMod);
                } else
                {
                    return "ERR";
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        

    }
}
