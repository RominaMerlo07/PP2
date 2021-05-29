using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class ProfesionalDetalle
    {
        private int id_profesional_detalle;
        private Profesional profesional;
        private Centro centro;
        private Especialidad especialidad;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdProfesionalDetalle
        {
            get { return id_profesional_detalle; }
            set { id_profesional_detalle = value; }
        }

        public Profesional Profesional
        {
            get { return profesional; }
            set { profesional = value; }
        }

        public Centro Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        public Especialidad Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
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

        public ProfesionalDetalle() { }

    }
}
