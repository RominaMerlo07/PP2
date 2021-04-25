using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class PlanTratamiento
    {
        private int id_tratamiento;
        private string descripcion;
        private DateTime fecha;
        private Turno turno;
        private HistoriaClinica historia_clinica;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdTratamiento
        {
            get { return id_tratamiento; }
            set { id_tratamiento = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Turno Turno
        {
            get { return turno; }
            set { turno = value; }
        }

        public HistoriaClinica HistoriaClinica
        {
            get { return historia_clinica; }
            set { historia_clinica = value; }
        }

        public int UsuarioAlta
        {
            get { return usuario_alta; }
            set { usuario_alta = value; }
        }

        public DateTime FechaAlta
        {
            get { return fecha_alta; }
            set { fecha_alta = value; }
        }

        public int UsuarioMod
        {
            get { return usuario_mod; }
            set { usuario_mod = value; }
        }

        public DateTime FechaMod
        {
            get { return fecha_mod; }
            set { fecha_mod = value; }
        }

        public int UsuarioBaja
        {
            get { return usuario_baja; }
            set { usuario_baja = value; }
        }

        public DateTime FechaBaja
        {
            get { return fecha_baja; }
            set { fecha_baja = value; }
        }

        public PlanTratamiento() { }
    }
}
