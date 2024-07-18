using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Combo
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private float precio;

        public float Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private int idhamburguesa;

        public int IDHamburguesa
        {
            get { return idhamburguesa; }
            set { idhamburguesa = value; }
        }

        private int idcerveza;

        public int IDCerveza
        {
            get { return idcerveza; }
            set { idcerveza = value; }
        }
    }
}
