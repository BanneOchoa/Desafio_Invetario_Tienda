using System;
using System.Linq;
namespace Midesafio
{ //clase producto*//
    public class Producto
   
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
 

        // Constructor tradicional con validaciones
        public Producto(int productoID, string nombre, decimal precio, int cantidad, string categoria)
        {
          

            if (precio <= 0)
                throw new ArgumentException("El precio debe ser mayor que cero.");

            if (cantidad < 0)
                throw new ArgumentException("La cantidad no puede ser negativa.");

            if (string.IsNullOrWhiteSpace(categoria))
                throw new ArgumentException("La categoría no puede estar vacía.");

            // Asignación de valores
            ProductoID = productoID;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            Categoria = categoria;
        }

        internal static object First(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        internal object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public Producto(int v, string v1) { }

        public Producto()
        {
        }

        /*public Producto(int v, string v1, decimal v2, int v3, string v4) : this(v, v1)
        {
        }*/
    }
}
