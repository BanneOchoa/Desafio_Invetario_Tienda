using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Midesafio
{
    public class Logica
    {
        // Lista para simular una base de datos
        public static List<Producto> productos = new List<Producto>();

        // Método para agregar productos predeterminados
        public static void ListaProductos()
        {
            if (productos.Count == 0)
            {
                productos.AddRange(new List<Producto>
                {
                    new Producto(1, "Carne de res", 100.0m, 10, "Carnes"),
                    new Producto(2, "Pollo", 50.0m, 20, "Carnes"),
                    new Producto(3, "Cerdo", 80.0m, 15, "Carnes"),
                    new Producto(4, "Cordero", 120.0m, 8, "Carnes"),
                    new Producto(5, "Pescado", 90.0m, 25, "Carnes"),
                    new Producto(6, "Salchichón", 40.0m, 30, "Carnes"),
                    new Producto(7, "Queso", 30.0m, 5, "Lácteos"),
                    new Producto(8, "Leche", 20.0m, 10, "Lácteos"),
                    new Producto(9, "Yogur", 25.0m, 8, "Lácteos"),
                    new Producto(10, "Mantequilla", 15.0m, 7, "Lácteos"),
                    new Producto(11, "Crema", 12.0m, 5, "Lácteos"),
                    new Producto(12, "Helado", 35.0m, 12, "Lácteos"),
                    new Producto(13, "Pasta dental", 15.0m, 25, "Limpieza"),
                    new Producto(14, "Frijoles", 10.0m, 30, "Abarrotes"),
                    new Producto(15, "Aceite", 40.0m, 20, "Abarrotes"),
                    new Producto(16, "Azúcar", 5.0m, 40, "Abarrotes"),
                    new Producto(17, "Sal", 2.0m, 50, "Abarrotes"),
                    new Producto(18, "Harina", 10.0m, 20, "Abarrotes"),
                    new Producto(19, "Pasta", 8.0m, 30, "Abarrotes"),
                    new Producto(20, "Vino tinto", 4.0m, 60, "Bebidas"),
                    new Producto(21, "Detergente", 12.0m, 50, "Limpieza"),
                    new Producto(22, "Jabón", 5.0m, 60, "Limpieza"),
                    new Producto(23, "Limpiador", 7.0m, 25, "Limpieza"),
                    new Producto(24, "Cloro", 3.0m, 40, "Limpieza"),
                    new Producto(25, "Esponja", 1.0m, 50, "Limpieza"),
                    new Producto(26, "Jugo natural", 7.0m, 30, "Bebidas"),
                    new Producto(27, "Jugo de naranja", 6.0m, 25, "Bebidas"),
                    new Producto(28, "Cerveza", 40.0m, 10, "Bebidas"),
                    new Producto(29, "Gaseosa", 10.0m, 15, "Bebidas"),
                    new Producto(30, "Jugo de limon", 20.0m, 10, "Bebidas"),
                    new Producto(31, "Agua mineral", 5.0m, 30, "Bebidas"),
                    new Producto(32, "Café", 18.0m, 12, "Bebidas"),
                    new Producto(33, "Té", 15.0m, 18, "Bebidas"),
                    new Producto(34, "Margarina", 8.0m, 10, "Lácteos"),
                    new Producto(35, "Leche condensada", 22.0m, 5, "Lácteos"),
                    new Producto(36, "Queso cheddar", 12.0m, 30, "Lácteos"),
                    new Producto(37, "Chocolatina", 9.0m, 35, "Lácteos"),
                    new Producto(38, "Mayonesa", 15.0m, 20, "Abarrotes"),
                    new Producto(39, "Mostaza", 7.0m, 40, "Abarrotes"),
                    new Producto(40, "Miel", 25.0m, 15, "Abarrotes"),
                    new Producto(41, "Suavitel", 45.0m, 10, "Limpieza"),
                    new Producto(42, "Tequila", 70.0m, 5, "Bebidas"),
                    new Producto(43, "Escoba", 50.0m, 8, "Limpieza"),
                    new Producto(44, "Jabon para platos", 45.0m, 12, "Limpieza"),
                    new Producto(45, "Lejia", 100.0m, 3, "Limpieza"),
                    new Producto(46, "Cereal", 80.0m, 5, "Abarrotes"),
                    new Producto(47, "Jamon de pavo", 120.0m, 6, "Carnes"),
                    new Producto(48, "Carne molida", 18.0m, 12, "Carnes"),
                    new Producto(49, "Lonja de pescado", 9.0m, 25, "Carnes"),
                    new Producto(50, "Medallones", 5.0m, 50, "Carnes")
                });
            }
        }

        // Método para agregar un producto
        public static void AgregarProducto(Producto producto)
        {
            // Validar que los campos del producto sean válidos
            if (string.IsNullOrWhiteSpace(producto.Nombre))
            {
                MessageBox.Show("El nombre del producto no puede estar vacío.");
                return;
            }

            if (producto.Precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.");
                return;
            }

            if (producto.Cantidad < 0)
            {
                MessageBox.Show("La cantidad debe ser un número positivo.");
                return;
            }

            // Agregar el producto si todo es válido
            productos.Add(producto);
            MessageBox.Show("Producto agregado con éxito");
        }

        // Método para obtener la lista completa de productos
        public static List<Producto> ObtenerListaProductos()
        {
            return productos;
        }

        // Lista de clientes (base de datos improvisada)
        public static List<Cliente> clientes = new List<Cliente>();

        public static void ListaClientes()
        {
            if (clientes.Count == 0)
            {
                clientes.AddRange(new List<Cliente>
                {
                    new Cliente(1, "Juan Pérez", "Calle Ficticia 123", "555-1234"),
                    new Cliente(2, "Ana López", "Avenida Siempre Viva 456", "555-5678"),
                    new Cliente(3, "Carlos Díaz", "Boulevard Libertad 789", "555-9876")
                });
            }
        }


        // Método para agregar clientes predeterminados
        public static void AgregarClientesPredeterminados(Cliente cliente)
        {


            clientes.Add(cliente);
            MessageBox.Show("Cliente agregado con éxito");
        }

        // Método para obtener la lista completa de clientes

        public static List<Cliente> ObtenerListaClientes()
        {
            return clientes;
        }



        // Método para realizar una venta
        public static void RealizarVenta(int clienteID, List<Producto> productosVenta)
        {
            // Verificar si hay suficiente stock de cada producto
            foreach (var producto in productosVenta)
            {
                var productoEnInventario = productos.FirstOrDefault(p => p.ProductoID == producto.ProductoID);
                if (productoEnInventario == null || productoEnInventario.Cantidad < producto.Cantidad)
                {
                    MessageBox.Show($"No hay suficiente stock de {producto.Nombre}.");
                    return;
                }
            }

           
            // Actualizar el inventario
            foreach (var producto in productosVenta)
            {
                var productoEnInventario = productos.First(p => p.ProductoID == producto.ProductoID);
                productoEnInventario.Cantidad -= producto.Cantidad; // Reducir el stock
            }

           
        }
        public static List<Cliente> ObtenerListaClientesPorTelefono(string telefono)
{
        // Filtrar clientes que tengan un teléfono que contenga el texto ingresado
        return clientes.Where(cliente => cliente.Telefono.Contains(telefono)).ToList();
}

    
        internal static List<Form1.Venta> ObtenerListaVentas()
        {
            throw new NotImplementedException();
        }

        internal static Form1.Venta ObtenerVentaPorId(int idVentaSeleccionado)
        {
            throw new NotImplementedException();
        }

        internal static object ObtenerListadeVentas()
        {
            throw new NotImplementedException();
        }

        internal static object ObtenerListadeClientesPorTelefono(string telefonoBusqueda)
        {
            throw new NotImplementedException();
        }
    }
}
