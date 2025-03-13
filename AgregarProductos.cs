using System;
using System.Collections.Generic;
using System.Linq;

namespace Midesafio
{
    internal class AgregarProductos
    {
        internal class GestionProductosPorCategoria
        {
            // Lista de productos que contiene todos los productos con su categoría
            public static List<Producto> productos = new List<Producto>();

            // Propiedad FileFind para realizar búsqueda
            public static int FileFind { get; internal set; }

            // Método para agregar un producto
            public static void AgregarProducto(Producto producto)
            {
                productos.Add(producto);
            }

            // Método para buscar un producto por su nombre o ID
            public static Producto BuscarProducto(string nombre)
            {
                return productos.FirstOrDefault(p => p.Nombre.IndexOf(nombre, StringComparison.OrdinalIgnoreCase) >= 0 || p.ProductoID == FileFind);
            }

            // Método para obtener los productos de una categoría específica
            public static List<Producto> ObtenerProductosPorCategoria(string categoria)
            {
                return productos.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Método para obtener todos los productos
            public static List<Producto> ObtenerTodosLosProductos()
            {
                return productos;
            }

           
        }
    }
}