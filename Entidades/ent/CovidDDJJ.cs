using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class CovidDDJJ
    {
        private int id_covid_ddjj;
        private Paciente paciente;
        private decimal temperatura;
        private bool sintomas;
        private bool contacto_estrecho;
        private bool caso_sospechoso;
        private bool viaje;
        private bool distancia_social;
        private bool lugares_cerrados;
        private DateTime fecha_ddjj;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdCovidDdjj
        {
            get { return id_covid_ddjj; }
            set { id_covid_ddjj = value; }
        }

        public Paciente Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }

        public decimal Temperatura
        {
            get { return temperatura; }
            set { temperatura = value; }
        }

        public bool Sintomas
        {
            get { return sintomas; }
            set { sintomas = value; }
        }

        public bool ContactoEstrecho
        {
            get { return contacto_estrecho; }
            set { contacto_estrecho = value; }
        }

        public bool CasoSospechoso
        {
            get { return caso_sospechoso; }
            set { caso_sospechoso = value; }
        }

        public bool Viaje
        {
            get { return viaje; }
            set { viaje = value; }
        }

        public bool DistanciaSocial
        {
            get { return distancia_social; }
            set { distancia_social = value; }
        }

        public bool LugaresCerrados
        {
            get { return lugares_cerrados; }
            set { lugares_cerrados = value; }
        }

        public DateTime FechaDdjj
        {
            get { return fecha_ddjj; }
            set { fecha_ddjj = value; }
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

        public CovidDDJJ() { }
    }
}
