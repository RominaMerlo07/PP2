using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class Cobro
    {
        private int id_cobro;
        private Turno turno;
        private string estado;
        private decimal importe;
        private DateTime fecha_cobro;
        private string forma_pago;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdCobro
        {
            get { return id_cobro; }
            set { id_cobro = value; }
        }

        public Turno Turno
        {
            get { return turno; }
            set { turno = value; }
        }

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public decimal Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        public DateTime FechaCobro
        {
            get { return fecha_cobro; }
            set { fecha_cobro = value; }
        }

        public string FormaPago
        {
            get { return forma_pago; }
            set { forma_pago = value; }
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

        public Cobro() { }
    }
}
