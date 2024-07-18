using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL.Mapper;

namespace BLL
{
    public class Hamburguesa
    {
        MapHamburguesa mapear = new MapHamburguesa();

        public int Insertar(BE.Hamburguesa hamburguesa)
        {
            return mapear.InsertarHamburguesa(hamburguesa);
        }

        public int Editar(BE.Hamburguesa hamburguesa)
        {
            return mapear.EditarHamburguesa(hamburguesa);
        }

        public int Borrar(BE.Hamburguesa hamburguesa)
        {
            return mapear.BorrarHamburguesa(hamburguesa);
        }

        public static List<BE.Hamburguesa> ListarHamburguesas()
        {
            return MapHamburguesa.Listar();
        }
    }
}
