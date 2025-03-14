﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midesafio
{
    public class ClienteModel
    {
        public int ClienteID { get; set; }
        public object NombreCliente { get; set; }

        public string Direccion { get; set; }
        public string Telefono { get; set; }
        
        public ClienteModel(int clienteID, string nombreCliente, string direccion, string telefono)
        {
            ClienteID = clienteID;
            NombreCliente = nombreCliente;
            Direccion = direccion;
            Telefono = telefono;
        }
    }
}
