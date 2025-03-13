using System;

namespace Midesafio
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string NombreC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Cliente(int clienteID, string nombre, string direccion, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(direccion))
                throw new ArgumentException("El correo no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono no puede estar vacío.");

            ClienteID = clienteID;
            NombreC = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        public Cliente()
        {
        }
    }
}
