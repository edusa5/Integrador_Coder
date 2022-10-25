using Sistema_Gestion.clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Gestion.ADO_query
{
    
    public class Usuario_quer
    {

        public static string ConnectionString = "Data Source=DESKTOP-2733T02; Initial Catalog = SistemaGestion; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Usuario> GetUsuarios(DataTable table)
        {
            List<Usuario> usuarios = new List<Usuario>();
            foreach (DataRow row in table.Rows)
            {
                Usuario getUsuario = new Usuario();
                getUsuario.Id = Convert.ToInt32(row["Id"]);
                getUsuario.Nombre = row["Nombre"].ToString();
                getUsuario.Apellido = row["Apellido"].ToString();
                getUsuario.NombreUsuario = row["NombreUsuario"].ToString();
                getUsuario.Contraseña = row["Contraseña"].ToString();
                getUsuario.Email = row["Mail"].ToString();

                usuarios.Add(getUsuario);
            }
            return usuarios;
        }
        /*Traer Usuario:  Recibe como parámetro un nombre del usuario,
     * buscarlo en la base de datos y devolver el objeto con todos sus datos 
     * (Esto se hará para la página en la que se mostrara los datos del usuario y en la página para modificar
     * sus datos).
*/
        public static Usuario GetUsuarioByUserName(string nombre)
        {
            Usuario usuario = new Usuario();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Connection.Open();

                    command.CommandText = @"SELECT * 
                                FROM Usuario 
                                WHERE NombreUsuario = @nombre;";

                    command.Parameters.AddWithValue("@nombre", nombre);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count < 1)
                    {
                        return new Usuario();
                    }


                    List<Usuario> usuarios = GetUsuarios(table);
                    usuario = usuarios[0];

                    command.Connection.Close();
                }
            }
            return usuario;
        }




        /*Inicio de sesión: Se le pase como parámetro el nombre del usuario y la contraseña,
         * buscar en la base de datos si el usuario existe y si coincide con la contraseña 
         * lo devuelve (el objeto Usuario), caso contrario devuelve uno vacío 
         * (Con sus datos vacíos y el id en 0). 
         * 
         * 
    */

        public static Usuario GetUsuarioByPassword(string nombre, string contraseña)
        {

            Usuario usuario = new Usuario();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.Connection.Open();

                    command.CommandText = @" SELECT * 
                                FROM Usuario 
                                WHERE NombreUsuario = @nombre
                                AND   Contraseña = @contraseña;";

                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@contraseña", contraseña);

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count < 1)
                    {
                        return new Usuario();
                    }


                    List<Usuario> usuarios = GetUsuarios(table);
                    usuario = usuarios[0];

                    command.Connection.Close();
                }
            }
            return usuario;
        }
    }
}
