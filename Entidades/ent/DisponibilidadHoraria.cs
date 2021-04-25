using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class DisponibilidadHoraria
    {
        private int id_disponibilidad_horaria;
        private ProfesionalDetalle profesional_detalle;
        private DateTime fecha_inic;
        private DateTime fecha_fin;
        private TimeSpan hora_desde;
        private TimeSpan hora_hasta;
        private string observaciones;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;


        public int IdDisponibilidadHoraria
        {
            get { return id_disponibilidad_horaria; }
            set { id_disponibilidad_horaria = value; }
        }

        public ProfesionalDetalle ProfesionalDetalle
        {
            get { return profesional_detalle; }
            set { profesional_detalle = value; }
        }

        public DateTime FechaInic
        {
            get { return fecha_inic; }
            set { fecha_inic = value; }
        }

        public DateTime FechaFin
        {
            get { return fecha_fin; }
            set { fecha_fin = value; }
        }

        public TimeSpan HoraDesde
        {
            get { return hora_desde; }
            set { hora_desde = value; }
        }

        public TimeSpan HoraHasta
        {
            get { return hora_hasta; }
            set { hora_hasta = value; }
        }

        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
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

        public DisponibilidadHoraria() { }
    }
}
