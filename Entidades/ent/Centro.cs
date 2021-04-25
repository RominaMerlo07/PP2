using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class Centro
    {
        private int id_centro;
        private string nombre_centro;
        private string domicilio_centro;
        private string localidad_centro;
        private string email_centro;
        private string nro_contacto_1;
        private string nro_contacto_2;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdCentro
        {
            get { return id_centro; }
            set { id_centro = value; }
        }

        public string NombreCentro
        {
            get { return nombre_centro; }
            set { nombre_centro = value; }
        }

        public string DomicilioCentro
        {
            get { return domicilio_centro; }
            set { domicilio_centro = value; }
        }

        public string LocalidadCentro
        {
            get { return localidad_centro; }
            set { localidad_centro = value; }
        }

        public string EmailCentro
        {
            get { return email_centro; }
            set { email_centro = value; }
        }

        public string NroCentro1
        {
            get { return nro_contacto_1; }
            set { nro_contacto_1 = value; }
        }

        public string NroCentro2
        {
            get { return nro_contacto_2; }
            set { nro_contacto_2 = value; }
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

        public Centro() { }
    }
}
