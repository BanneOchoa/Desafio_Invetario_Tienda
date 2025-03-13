using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Midesafio
{
    public static class GestionVentas
    {
        // Lista de ventas global
        public static List<Venta> ventas = new List<Venta>();

        // Método para realizar una venta
        public static void RealizarVenta(int clienteID, List<Producto> productosVenta)
        {
            // Crear la venta
            int ventaID = ventas.Count + 1;  // Esto suma 1 al conteo actual de ventas
            var venta = new Venta(ventaID, clienteID);
            venta.Productos = productosVenta;
            venta.CalcularMontoTotal();

            // Agregar la venta a la lista de ventas
            ventas.Add(venta);

            MessageBox.Show($"Venta realizada con éxito. Monto total: {venta.MontoTotal}");
        }

        // Método para obtener todas las ventas
        public static List<Venta> ObtenerVentas()
        {
            return ventas;
        }
    }
}
