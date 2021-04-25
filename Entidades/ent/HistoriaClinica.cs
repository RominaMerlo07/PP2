using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class HistoriaClinica
    {
        private int id_historia_clinica;
        private int id_paciente;
        private int id_profesional;
        private string derivante;
        private string mat_derivante;
        private string especialidad_derivante;
        private DateTime fecha_ingreso;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdHistoriaClinica
        {
            get { return id_historia_clinica; }
            set { id_historia_clinica = value; }
        }

        public int IdPaciente
        {
            get { return id_paciente; }
            set { id_paciente = value; }
        }

        public int IdProfesional
        {
            get { return id_profesional; }
            set { id_profesional = value; }
        }

        public string Derivante
        {
            get { return derivante; }
            set { derivante = value; }
        }

        public string MatDerivante
        {
            get { return mat_derivante; }
            set { mat_derivante = value; }
        }

        public string EspecialidadDerivante
        {
            get { return especialidad_derivante; }
            set { especialidad_derivante = value; }
        }

        public DateTime FechaIngreso
        {
            get { return fecha_ingreso; }
            set { fecha_ingreso = value; }
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

        public HistoriaClinica() { }
    }
}
