using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades.ent
{
    public class ItemHistoriaClinica
    {
        private int id_item_historia_clinica;
        private string categoria_item;
        private string item;
        private int id_items_rel;
        private int usuario_alta;
        private DateTime fecha_alta;
        private int usuario_mod;
        private DateTime fecha_mod;
        private int usuario_baja;
        private DateTime fecha_baja;

        public int IdItemHistoriaClinica
        {
            get { return id_item_historia_clinica; }
            set { id_item_historia_clinica = value; }
        }

        public string CategoriaItem
        {
            get { return categoria_item; }
            set { categoria_item = value; }
        }

        public string Item
        {
            get { return item; }
            set { item = value; }
        }

        public int IdItemsRel
        {
            get { return id_items_rel; }
            set { id_items_rel = value; }
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

        public ItemHistoriaClinica() { }
    }
}
