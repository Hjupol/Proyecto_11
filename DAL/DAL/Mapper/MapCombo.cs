using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;

namespace DAL.Mapper
{
    public class MapCombo
    {
        DAL conexion = new DAL();
        public int InsertarCombo(Combo combo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(conexion.CrearParametro("@idhamburguesa", combo.IDHamburguesa));
            parametros.Add(conexion.CrearParametro("@idcerveza", combo.IDCerveza));
            parametros.Add(conexion.CrearParametro("@precio", combo.Precio));


            conexion.Abrir();
            int resultado = conexion.Escribir("insertarCombo", parametros);
            conexion.Cerrar();

            return resultado;
        }

        public int EditarCombo(Combo combo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(conexion.CrearParametro("@idcombo", combo.ID));
            parametros.Add(conexion.CrearParametro("@idhamburguesa", combo.IDHamburguesa));
            parametros.Add(conexion.CrearParametro("@idcerveza", combo.IDCerveza));
            parametros.Add(conexion.CrearParametro("@precio", combo.Precio));

            conexion.Abrir();
            int resultado = conexion.Escribir("editarCombo", parametros);
            conexion.Cerrar();

            return resultado;
        }

        public int BorrarCombo(Combo combo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(conexion.CrearParametro("@idcombo", combo.ID));

            conexion.Abrir();
            int resultado = conexion.Escribir("borrarCombo", parametros);
            conexion.Cerrar();

            return resultado;
        }

        public static List<Combo> Listar()
        {
            DAL conexion = new DAL();
            List<Combo> combos = new List<Combo>();

            conexion.Abrir();
            DataTable tabla = conexion.Leer("listarCombo", null);
            conexion.Cerrar();

            foreach (DataRow row in tabla.Rows)
            {
                Combo c = new Combo();
                c.IDHamburguesa = int.Parse(row["idhamburguesa"].ToString());
                c.IDCerveza = int.Parse(row["idcerveza"].ToString());
                c.Precio = float.Parse(row["precio"].ToString());

                combos.Add(c);
            }
            return combos;
        }
    }
}
