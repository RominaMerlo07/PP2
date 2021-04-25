using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class HistoriaClinicaDetalle
    {
        private int id_historia_clinica_det;
        private HistoriaClinica historia_clinica;
        private ItemHistoriaClinica item_historia_clinica;
        private bool confirma;
        private decimal valor;
        private string desarrollo;
        private DateTime fecha;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdHistoriaClinicaDet
        {
            get { return id_historia_clinica_det; }
            set { id_historia_clinica_det = value; }
        }

        public HistoriaClinica HistoriaClinica
        {
            get { return historia_clinica; }
            set { historia_clinica = value; }
        }

        public ItemHistoriaClinica ItemHistoriaClinica
        {
            get { return item_historia_clinica; }
            set { item_historia_clinica = value; }
        }

        public bool Confirma
        {
            get { return confirma; }
            set { confirma = value; }
        }

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string Desarrollo
        {
            get { return desarrollo; }
            set { desarrollo = value; }
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

        public HistoriaClinicaDetalle() { }
    }
}
