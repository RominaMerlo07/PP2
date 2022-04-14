using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class HistoriaClinica
    {
        private int id_historia_clinica;

        private bool tension;
        private string tension_valores;
        private bool diabetes;
        private bool fumador;
        private bool cardiaco;
        private bool cirrosis;
        private bool artrosis;
        private bool artritis_rematoidea;
        private bool hemiplejia;
        private bool asma;
        private bool marcapasos;
        private bool protesis;
        private bool cadera_derecha;
        private bool cadera_izquierda;
        private string otros;
        private string antecedentes;
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

        public bool Tension
        {
            get { return tension; }
            set { tension = value; }
        }

        public string TensionValores
        {
            get { return tension_valores; }
            set { tension_valores = value; }
        }

        public bool Diabetes
        {
            get { return diabetes; }
            set { diabetes = value; }
        }

        public bool Fumador
        {
            get { return fumador; }
            set { fumador = value; }
        }

        public bool Cardiaco
        {
            get { return cardiaco; }
            set { cardiaco = value; }
        }

        public bool Cirrosis
        {
            get { return cirrosis; }
            set { cirrosis = value; }
        }

        public bool Artrosis
        {
            get { return artrosis; }
            set { artrosis = value; }
        }

        public bool ArtritisRematoidea
        {
            get { return artritis_rematoidea; }
            set { artritis_rematoidea = value; }
        }

        public bool Hemiplejia
        {
            get { return hemiplejia; }
            set { hemiplejia = value; }
        }

        public bool Asma
        {
            get { return asma; }
            set { asma = value; }
        }

        public bool Marcapasos
        {
            get { return marcapasos; }
            set { marcapasos = value; }
        }

        public bool Protesis
        {
            get { return protesis; }
            set { protesis = value; }
        }

        public bool CaderaDerecha
        {
            get { return cadera_derecha; }
            set { cadera_derecha = value; }
        }

        public bool CaderaIzquierda
        {
            get { return cadera_izquierda; }
            set { cadera_izquierda = value; }
        }

        public string Otros
        {
            get { return otros; }
            set { otros = value; }
        }

        public string Antecedentes
        {
            get { return antecedentes; }
            set { antecedentes = value; }
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
