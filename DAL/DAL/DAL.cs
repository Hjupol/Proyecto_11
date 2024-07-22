using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DAL
    {

        SqlConnection conexion;
        public void Abrir()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=DESKTOP-6PDF17Q\MSSQLSERVER01;Initial Catalog=Cerveceria;Integrated Security=True";
            conexion.Open();
        }

        public void Cerrar()
        {
            conexion.Close();
            conexion.Dispose();
            conexion = null;
            GC.Collect();
        }

        private SqlCommand CrearComando(string nombre, List<SqlParameter> parametros)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = nombre;
            comando.CommandType = CommandType.StoredProcedure;
            if(parametros!=null && parametros.Count > 0)
            {
                comando.Parameters.AddRange(parametros.ToArray());
            }
            return comando;
        }


        public DataTable Leer(string  nombre, List<SqlParameter> parametros)
        {
            SqlDataAdapter adaptador = new SqlDataAdapter();
            adaptador.SelectCommand = CrearComando(nombre, parametros);

            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            adaptador = null;

            return tabla;
        }

        public int Escribir(string nombre, List<SqlParameter> parametros)
        {
            SqlCommand comando = CrearComando(nombre, parametros);
            int filasAfectadas = 0;
            try
            {
                filasAfectadas = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                filasAfectadas = -1;
            }
            return filasAfectadas;
        }

        public SqlParameter CrearParametro(string nombre, string valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.String;

            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, int valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.Int32;

            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, float valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.Single;

            return parametro;
        }

        public SqlParameter CrearParametro(string nombre, bool valor)
        {
            SqlParameter parametro = new SqlParameter();
            parametro.ParameterName = nombre;
            parametro.Value = valor;
            parametro.DbType = DbType.Boolean;

            return parametro;
        }
    }
}
