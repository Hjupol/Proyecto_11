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
    public class Cerveza
    {
        MapCerveza mapear = new MapCerveza();

        public int Insertar(BE.Cerveza cerveza)
        {
            return mapear.InsertarCerveza(cerveza);
        }

        public int Editar(BE.Cerveza cerveza)
        {
            return mapear.EditarCerveza(cerveza);
        }

        public int Borrar(BE.Cerveza cerveza)
        {
            return mapear.BorrarCerveza(cerveza);
        }

        public static List<BE.Cerveza> ListarCervezas()
        {
            return MapCerveza.Listar();
        }
    }
}
