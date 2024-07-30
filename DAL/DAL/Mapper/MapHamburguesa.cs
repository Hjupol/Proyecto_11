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
    public class MapHamburguesa
    {
        DAL conexion = new DAL();
        public int InsertarHamburguesa(Hamburguesa hamburguesa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(conexion.CrearParametro("@nombre", hamburguesa.Nombre));
            parametros.Add(conexion.CrearParametro("@detalle", hamburguesa.Detalle));
            parametros.Add(conexion.CrearParametro("@baja", 0));

            conexion.Abrir();
            int resultado = conexion.Escribir("insertarHamburguesa", parametros);
            conexion.Cerrar();

            return resultado;
        }

        public int EditarHamburguesa(Hamburguesa hamburguesa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(conexion.CrearParametro("@idhamburguesa", hamburguesa.ID));
            parametros.Add(conexion.CrearParametro("@nombre", hamburguesa.Nombre));
            parametros.Add(conexion.CrearParametro("@detalle", hamburguesa.Detalle));

            conexion.Abrir();
            int resultado = conexion.Escribir("editarHamburguesa", parametros);
            conexion.Cerrar();

            return resultado;
        }

        public int BorrarHamburguesa(Hamburguesa hamburguesa)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(conexion.CrearParametro("@idhamburguesa", hamburguesa.ID));
            parametros.Add(conexion.CrearParametro("@baja", 1));

            conexion.Abrir();
            int resultado = conexion.Escribir("borrarHamburguesa", parametros);
            conexion.Cerrar();

            return resultado;
        }

        public static List<Hamburguesa> Listar()
        {
            DAL conexion = new DAL();
            List<Hamburguesa> hamburguesas = new List<Hamburguesa>();

            conexion.Abrir();
            DataTable tabla = conexion.Leer("listarHamburguesa", null);
            conexion.Cerrar();

            foreach (DataRow row in tabla.Rows)
            {
                Hamburguesa h = new Hamburguesa();
                h.ID = int.Parse(row["idhamburguesa"].ToString());
                h.Nombre = row["nombre"].ToString();
                h.Detalle = row["detalle"].ToString();
                if (int.TryParse(row["baja"].ToString(), out int j))
                {
                    h.Baja = j;
                }
                else
                {
                    h.Baja = 0;                    
                }

                hamburguesas.Add(h);
            }
            return hamburguesas;
        }
    }
}
