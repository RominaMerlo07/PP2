using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class ObrasPacientes
    {
        private int id_obra_paciente;
        private int id_obra_social;
        private int id_paciente;
        private int id_plan;
        private string nro_afiliado;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdObraPaciente
        {
            get { return id_obra_paciente; }
            set { id_obra_paciente = value; }
        }

        public int IdObraSocial
        {
            get { return id_obra_social; }
            set { id_obra_social = value; }
        }

        public int IdPaciente
        {
            get { return id_paciente; }
            set { id_paciente = value; }
        }

        public int IdPlan
        {
            get { return id_plan; }
            set { id_plan = value; }
        }

        public string nroAfiliado
        {
            get { return nro_afiliado; }
            set { nro_afiliado = value; }
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

        public ObrasPacientes() { }
    }
}
