using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class Paciente
    {
        private int id_paciente;
        private string nombre;
        private string apellido;
        private string documento;
        private string nro_contacto;
        private string email_contacto;
        private DateTime fecha_nacimiento;
        private string domicilio;
        private string localidad;
        private string nro_legajo;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdPaciente
        {
            get { return id_paciente; }
            set { id_paciente = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public string NroContacto
        {
            get { return nro_contacto; }
            set { nro_contacto = value; }
        }

        public string EmailContacto
        {
            get { return email_contacto; }
            set { email_contacto = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return fecha_nacimiento; }
            set { fecha_nacimiento = value; }
        }

        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        public string NroLegajo
        {
            get { return nro_legajo; }
            set { nro_legajo = value; }
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

        public Paciente() { }
    }
}
