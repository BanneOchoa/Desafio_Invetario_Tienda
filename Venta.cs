using System;
using System.Collections.Generic;

namespace Midesafio
{
    public class Venta
    {
        private string v;
        private List<Producto> productosVenta;

        public int VentaID { get; set; }
        public int ClienteID { get; set; }
        public List<Producto> Productos { get; set; } = new List<Producto>();
        public decimal MontoTotal { get; private set; }

        public Venta(int ventaID, int clienteID, List<Producto> productosVenta)
        {
            VentaID = ventaID;
            ClienteID = clienteID;
        }

        public Venta(int ventaID, string v, List<Producto> productosVenta)
        {
            VentaID = ventaID;
            this.v = v;
            this.productosVenta = productosVenta;
        }

        public Venta(int ventaID, int clienteID)
        {
            VentaID = ventaID;
            ClienteID = clienteID;
        }

        public void CalcularMontoTotal()
        {
            MontoTotal = 0;
            foreach (var producto in Productos)
            {
                MontoTotal += producto.Precio * producto.Cantidad;
            }
        }
    }
}
