using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class PlanTratamiento
    {
        private int id_tratamiento;
        private string descripcion;

        private string profesional_derivante;
        private string matricula;
        private string especialidad;
        private string diagnostico_ingreso;
        private string evaluacion_ingreso;
        private string descripcion_plan;
        private string objetivo_plan;
        private bool consentimiento_firmado;

        private DateTime fecha;
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

        public string ProfesionalDerivante
        {
            get { return profesional_derivante; }
            set { profesional_derivante = value; }
        }

        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public string DiagnosticoIngreso
        {
            get { return diagnostico_ingreso; }
            set { diagnostico_ingreso = value; }
        }

        public string EvaluacionIngreso
        {
            get { return evaluacion_ingreso; }
            set { evaluacion_ingreso = value; }
        }

        public string DescripcionPlan
        {
            get { return descripcion_plan; }
            set { descripcion_plan = value; }
        }

        public string ObjetivoPlan
        {
            get { return objetivo_plan; }
            set { objetivo_plan = value; }
        }

        public bool ConsentimientoFirmado
        {
            get { return consentimiento_firmado; }
            set { consentimiento_firmado = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
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
