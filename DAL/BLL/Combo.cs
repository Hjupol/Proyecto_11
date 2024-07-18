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
    public class Combo
    {
        MapCombo mapear = new MapCombo();

        public int Insertar(BE.Combo combo)
        {
            return mapear.InsertarCombo(combo);
        }

        public int Editar(BE.Combo combo)
        {
            return mapear.EditarCombo(combo);
        }

        public int Borrar(BE.Combo combo)
        {
            return mapear.BorrarCombo(combo);
        }

        public static List<BE.Combo> ListarCombos()
        {
            return MapCombo.Listar();
        }

    }
}
