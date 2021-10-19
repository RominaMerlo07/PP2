using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ent
{
    public class ObrasPlanes
    {
        private int id_planes;
        private string cod_plan;
        private string descripcion;
        private int id_obra_social;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdPlanes
        {
            get { return id_planes; }
            set { id_planes = value; }
        }

        public string CodPlan
        {
            get { return cod_plan; }
            set { cod_plan = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int IdObraSocial
        {
            get { return id_obra_social; }
            set { id_obra_social = value; }
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
    }
}
