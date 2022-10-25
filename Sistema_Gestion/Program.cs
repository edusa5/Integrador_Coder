using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_Gestion;
using Sistema_Gestion.ADO_query;

namespace Sistema_Gestion
{
    public class Program 
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Sistema de Gestion");
            
            Console.WriteLine("----------------------------------------------------------");

            Console.WriteLine("Prueba Trear Usuarios Existente");
            Usuario_quer.GetUsuarioByUserName("tobias");
            
            Console.WriteLine("Prueba Trear Usuarios No Existente");
            Usuario_quer.GetUsuarioByUserName("asdasd");

            Console.WriteLine("\n----------------------------------------------------------");
            Console.WriteLine("Prueba Traer Producto Existente");
            Producto_query.GetProductos(1);
            
            Console.WriteLine("\nPrueba Traer Producto No Existente");
            Producto_query.GetProductos(1234);
            Console.WriteLine("\n----------------------------------------------------------");
            Console.WriteLine("Prueba Traer ProductoVendido Existente");
            ProductoVendido_query.GetProductosVendidos(1);
            Console.WriteLine("\nPrueba Traer ProductoVendido No Existente");
            ProductoVendido_query.GetProductosVendidos(1234543);
            Console.WriteLine("\n----------------------------------------------------------");
            Console.WriteLine("Prueba Traer Vetas Existente");
            Venta_query.GetVentas(1);
            Console.WriteLine("\nPrueba Traer Vetas No Existente");
            Venta_query.GetVentas(12432);
            Console.WriteLine("\n----------------------------------------------------------");
            Console.WriteLine("Prueba Traer Usuario Login Existente");
            Usuario_quer.GetUsuarioByPassword("tcasazza", "SoytobiasCasazza");
            
           

        }



    }
}
