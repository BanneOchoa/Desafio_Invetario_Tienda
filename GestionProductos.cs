using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Midesafio
{
    public static class GestionProductos
    {
        // Lista estática de productos
        //public static List<Producto> productos = new List<Producto>();



        // Método para buscar un producto por ID
        public static Producto BuscarProductoPorID(int id)
        {
            return Logica.productos.FirstOrDefault(p => p.ProductoID == id);
            
        }

        // Método para eliminar un producto de la lista por ID
        public static bool EliminarProducto(int productoId)
        {
            var productoAEliminar = Logica.productos.FirstOrDefault(p => p.ProductoID == productoId);
            Console.WriteLine("VARIABLE productoAEliminar: " + productoAEliminar);

            if (productoAEliminar != null)
            {
                Logica.productos.Remove(productoAEliminar); // Eliminar de la lista
                MessageBox.Show("Producto eliminado exitosamente.");
                return true;
            }

            MessageBox.Show("Producto no encontrado.");
            return false;
        }

        // Método para obtener todos los productos
        public static List<Producto> ObtenerTodosLosProductos()
        {
            return Logica.productos;
        }
    }
}
