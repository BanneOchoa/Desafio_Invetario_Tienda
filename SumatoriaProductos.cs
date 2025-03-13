using System;
using System.Collections.Generic;

namespace Midesafio
{
    public class SumatoriaProductos
    {
        // Método que calcula la cantidad total de productos vendidos
        public static int CalcularCantidadTotal(List<Producto> productos)
        {
            int cantidadTotal = 0;
            foreach (var producto in productos)
            {
                cantidadTotal += producto.Cantidad;
            }
            return cantidadTotal;
        }

        // Método que calcula el monto total de los productos vendidos
        public static decimal CalcularMontoTotal(List<Producto> productos)
        {
            decimal montoTotal = 0;
            foreach (var producto in productos)
            {
                montoTotal += producto.Precio * producto.Cantidad;
            }
            return montoTotal;
        }

        // Método que devuelve un resumen de todos los productos
        public static string ObtenerResumenProductos(List<Producto> productos)
        {
            string resumen = "Resumen de Productos:\n";
            foreach (var producto in productos)
            {
                resumen += $"Producto: {producto.Nombre}, Precio: {producto.Precio}, Cantidad: {producto.Cantidad}\n";
            }
            return resumen;
        }
    }
}
