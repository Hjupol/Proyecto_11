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
    public class MapCerveza
    {
        DAL conexion = new DAL();
        public int InsertarCerveza(Cerveza cerveza)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(conexion.CrearParametro("@nombre", cerveza.Nombre));
            parametros.Add(conexion.CrearParametro("@tipo", cerveza.Tipo));

            conexion.Abrir();
            int resultado = conexion.Escribir("insertarCerveza", parametros);
            conexion.Cerrar();

            return resultado;
        }

        public int EditarCerveza(Cerveza cerveza)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(conexion.CrearParametro("@idcerveza", cerveza.ID));
            parametros.Add(conexion.CrearParametro("@nombre", cerveza.Nombre));
            parametros.Add(conexion.CrearParametro("@tipo", cerveza.Tipo));

            conexion.Abrir();
            int resultado = conexion.Escribir("editarCerveza", parametros);
            conexion.Cerrar();

            return resultado;
        }

        public int BorrarCerveza(Cerveza cerveza)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(conexion.CrearParametro("@idhamburguesa", cerveza.ID));

            conexion.Abrir();
            int resultado = conexion.Escribir("borrarCerveza", parametros);
            conexion.Cerrar();

            return resultado;
        }

        public static List<Cerveza> Listar()
        {
            DAL conexion = new DAL();
            List<Cerveza> cervezas = new List<Cerveza>();

            conexion.Abrir();
            DataTable tabla = conexion.Leer("listarCerveza", null);
            conexion.Cerrar();

            foreach (DataRow row in tabla.Rows)
            {
                Cerveza c = new Cerveza();
                c.Nombre = row["nombre"].ToString();
                c.Tipo = row["tipo"].ToString();

                cervezas.Add(c);
            }
            return cervezas;
        }
    }
}
