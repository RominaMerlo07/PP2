using System;
using System.Collections.Generic;
using System.Text;
using Entidades.ent;
using DataAccess;

namespace BusinessLogicLayer.Gestores
{
    public class GestorProfesionales
    {
        public string RegistrarProfesional(Profesional profesional)
        {
            try
            {
                DAProfesional DaProfesional = new DAProfesional();
                return DaProfesional.DaRegistrarProfesional(profesional);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
