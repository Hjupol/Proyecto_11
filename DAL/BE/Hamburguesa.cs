using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Hamburguesa
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string detalle;

        public string Detalle
        {
            get { return detalle; }
            set { detalle = value; }
        }

        private int baja;

        public int Baja
        {
            get { return baja; }
            set { baja = value; }
        }
    }
}
