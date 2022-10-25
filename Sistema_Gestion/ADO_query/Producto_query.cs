using Sistema_Gestion.clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Sistema_Gestion.ADO_query
{
   
    public class Producto_query
    {
        public static string ConnectionString = "Data Source=DESKTOP-2733T02; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public static List<Producto> GetProductos(int id) 
            
        {

            List<Producto> IDproductos = new List<Producto>();

            //connecion 
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Connection.Open();

                   /* consulta
                    Traer Producto: Recibe un número de IdUsuario como parámetro,
                    debe traer todos los productos cargados en la base de este usuario en particular.*/
                    sqlCommand.CommandText = @"select * from Producto
                                                where IdUsuario = @idUsuario;";

                    sqlCommand.Parameters.AddWithValue("@idUsuario", id);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = sqlCommand;
                    DataTable table = new DataTable();
                    dataAdapter.Fill(table);
                    sqlCommand.Connection.Close();
                    foreach (DataRow row in table.Rows)
                    {
                        Producto producto = new Producto();
                        producto.Id = Convert.ToInt32(row["Id"]);
                        producto.Descripciones = row["Descripciones"].ToString();
                        producto.Costo = (float)Convert.ToDouble(row["Costo"]);
                        producto.PrecioVenta = (float)Convert.ToDouble(row["PrecioVenta"]);
                        producto.Stock = Convert.ToInt32(row["Stock"]);
                        producto.IdUsuario = Convert.ToInt32(row["IdUsuario"]);

                        IDproductos.Add(producto);
                    }

                }
            }
            return IDproductos;

        }
    }
}
