using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class Usuario
    {
        private int id_usuario;
        private string nombre_usuario;
        private string clave_usuario;
        private Rol rol;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;
        private Profesional profesional;

        public int IdUsuario
        {
            get { return id_usuario; }
            set { id_usuario = value; }
        }

        public string NombreUsuario
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }

        public string ClaveUsuario
        {
            get { return clave_usuario; }
            set { clave_usuario = value; }
        }

        public Rol Rol
        {
            get { return rol; }
            set { rol = value; }
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

        public Profesional Profesional
        {
            get { return profesional; }
            set { profesional = value; }
        }

        public Usuario() { }
    }
}
