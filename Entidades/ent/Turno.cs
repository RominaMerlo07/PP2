using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class Turno
    {
        private int id_turno;
        private Paciente paciente;
        private ProfesionalDetalle profesional_detalle;
        private ObraSocial obra_social;
        private Especialidad especialidad;
        private Centro centro;
        private DateTime fecha_turno;
        private TimeSpan hora_desde;
        private TimeSpan hora_hasta;
        private string estado;
        private string observaciones;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdTurno
        {
            get { return id_turno; }
            set { id_turno = value; }
        }

        public Paciente Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }

        public ProfesionalDetalle ProfesionalDetalle
        {
            get { return profesional_detalle; }
            set { profesional_detalle = value; }
        }

        public ObraSocial ObraSocial
        {
            get { return obra_social; }
            set { obra_social = value; }
        }

        public Especialidad Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public Centro Centro
        {
            get { return centro; }
            set { centro = value; }
        }

        public DateTime FechaTurno
        {
            get { return fecha_turno; }
            set { fecha_turno = value; }
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

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
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

        public Turno() { }
    }
}
