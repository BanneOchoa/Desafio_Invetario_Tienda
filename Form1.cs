
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Midesafio
{
    public partial class Form1 : Form
    {
        public static int cv = 0;
        public static int id = 51;
        public static int cvv = 0;
        public static int idV = 4;


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void ActualizarMontoTotal()
        {
            // Inicializar la sumatoria del monto total
            decimal montoTotal = 0;

            // Recorrer los productos seleccionados en el ListBox
            foreach (Producto producto in listBox1.Items)
            {
                // Sumar el precio de cada producto
                montoTotal += producto.Precio;
            }

            // Mostrar el monto total en textBox12
            textBox12.Text = montoTotal.ToString("C");
        }

        private void btnBuscarP_Click(object sender, EventArgs e)
        {
            // Obtener el nombre del producto ingresado en el TextBox
            string nombreProducto = textBoxNameP.Text.Trim();

            // Verificar si el nombre está vacío
            if (string.IsNullOrWhiteSpace(nombreProducto))
            {
                MessageBox.Show("Por favor ingrese un nombre válido.");
                return;
            }

          
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataProducts(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                // Obtener el producto seleccionado
                Producto productoSeleccionado = (Producto)dataGridView3.SelectedRows[0].DataBoundItem;

                // Modificar los valores con lo que hay en los campos
                productoSeleccionado.Nombre = textBoxNameP.Text;
                productoSeleccionado.Categoria = comboBoxCategoriaP.SelectedItem.ToString();
                productoSeleccionado.Cantidad = int.Parse(textBoxCantidadP.Text);
                productoSeleccionado.Precio = decimal.Parse(textBoxPrecioP.Text);

                // Refrescar la grilla
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = Logica.ObtenerListaProductos();

                MessageBox.Show("Producto actualizado correctamente.");
            }
            else
            {
                MessageBox.Show("Seleccione un producto para modificar.");
            }
        }

        private void CargarProductoEnDataGridView3()
        {
            //MessageBox.Show("Producto agregado exitosamente.");
        }

        private void LimpiarCampos()
        {
           
        }

        private void MostrarProductoEnCampos(Producto producto)
        {
            // Asignar el nombre del producto al TextBox de nombre
            textBoxNameP.Text = producto.Nombre;

            // Asignar el precio del producto al TextBox de precio con formato de dos decimales
            textBoxPrecioP.Text = producto.Precio.ToString("F2");

            // Asignar la cantidad del producto al TextBox de cantidad
            textBoxCantidadP.Text = producto.Cantidad.ToString();

            // Asignar la categoría del producto al ComboBox (usando SelectedItem en lugar de Text)
            comboBoxCategoriaP.SelectedItem = producto.Categoria;
        }
        // Función para actualizar el DataGridView con los productos encontrados
        private void ActualizarTabla(List<Producto> productos)
        {
            // Limpiar el DataGridView antes de agregar los nuevos productos
            //dataGridView3.Rows.Clear();

            // Agregar los productos al DataGridView
           /* foreach (var producto in productos)
            {
                dataGridView3.Rows.Add(producto.ProductoID, producto.Nombre, producto.Precio, producto.Cantidad, producto.Categoria);
            }*/
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Obtener el texto del cuadro de búsqueda y eliminar espacios innecesarios
            string nombreBuscado = textBoxNameP.Text.Trim();

            // Verificar si el nombre es vacío, si es así, limpiar el DataGridView
            if (string.IsNullOrWhiteSpace(nombreBuscado))
            {
                dataGridView1.DataSource = null;  // Limpiar la tabla si no hay texto en la búsqueda
                return;
            }

            // Filtrar los productos según el nombre ingresado
            var productosFiltrados = Logica.ObtenerListaProductos()
                .Where(p => p.Nombre.ToLower().Contains(nombreBuscado.ToLower()))
                .ToList();

            // Si hay productos que coinciden, los mostramos en el DataGridView
            if (productosFiltrados.Count > 0)
            {
                dataGridView1.DataSource = productosFiltrados;
            }
            else
            {
                // Si no se encuentran productos, mostramos un mensaje (opcional)
                //MessageBox.Show("No se encontraron productos que coincidan con la búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;  // Limpiar el DataGridView si no hay coincidencias
            }
        }

        private void TextBoxCantidadP_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el campo está vacío, en ese caso no realizar ninguna validación
            if (string.IsNullOrWhiteSpace(textBoxCantidadP.Text))
            {
                return;
            }

            // Intentar parsear el valor ingresado como un número entero
            if (!int.TryParse(textBoxCantidadP.Text, out int cantidad))
            {
                // Si no es un número válido, mostrar un mensaje de error
                MessageBox.Show("Por favor ingrese una cantidad válida (un número entero).", "Cantidad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCantidadP.SelectAll();  // Seleccionar todo el texto para facilitar la corrección
                return;
            }

            // Verificar si la cantidad es un valor positivo
            if (cantidad < 0)
            {
                MessageBox.Show("La cantidad no puede ser negativa.", "Cantidad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCantidadP.SelectAll();  // Seleccionar todo el texto para facilitar la corrección
            }
            // Verificar si la cantidad está dentro de un rango específico
            else if (cantidad < 1 || cantidad > 1000)
            {
                MessageBox.Show("La cantidad debe estar entre 1 y 1000.", "Cantidad Fuera de Rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxCantidadP.SelectAll();  // Seleccionar todo el texto para facilitar la corrección
            }
            else
            {
                // Si la cantidad es válida, puedes proceder con la lógica que desees
                // Por ejemplo, actualizar el producto o almacenar el valor
            }
        }

        private void comboBoxCategoriaP_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay una categoría seleccionada
            if (comboBoxCategoriaP.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una categoría.");
                return;
            }

            // Obtener la categoría seleccionada
            string categoriaSeleccionada = comboBoxCategoriaP.SelectedItem.ToString();

            // Filtrar los productos por la categoría seleccionada
            var productosFiltradosPorCategoria = Logica.ObtenerListaProductos()
                .Where(p => p.Categoria.ToLower() == categoriaSeleccionada.ToLower())
                .ToList();

            // Verificar si se encontraron productos en la categoría seleccionada
            if (productosFiltradosPorCategoria.Count > 0)
            {
                // Mostrar los productos filtrados en el DataGridView
                dataGridView3.DataSource = productosFiltradosPorCategoria;
            }
            else
            {
                // Si no se encontraron productos para la categoría seleccionada, mostrar un mensaje
                MessageBox.Show("No se encontraron productos en esta categoría.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView3.DataSource = null;  // Limpiar el DataGridView si no hay productos
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            // Verifica si hay productos en la lista antes de actualizar el DataGridView
            if (Logica.ObtenerListaProductos().Count > 0)
            {
                // Mostrar los productos en el DataGridView
                dataGridView3.DataSource = null; // Limpiar antes de actualizar
                dataGridView3.DataSource = Logica.ObtenerListaProductos();
            }
            else
            {
                MessageBox.Show("No hay productos registrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void TextBoxIdP_TextChanged(object sender, EventArgs e)
        {
            // Obtener el ID del producto ingresado
            string idProducto = textBoxIdP.Text.Trim();

            // Validar que el campo no esté vacío
            if (string.IsNullOrWhiteSpace(idProducto))
            {
                LimpiarCampos();  // Limpiar los campos si el ID está vacío
                CargarProductoEnDataGridView3(); // Mostrar todos los productos por defecto
                return;
            }

            // Convertir el texto del ID a un entero (manejo de errores si no es un número válido)
            int id;
            bool esNumero = int.TryParse(idProducto, out id);

            if (!esNumero)
            {
                LimpiarCampos(); // Limpiar si no es un número
                CargarProductoEnDataGridView3(); // Mostrar todos los productos si no es un número
                return;
            }

            // Buscar el producto por ID
            Producto productoEncontrado = Logica.ObtenerListaProductos().FirstOrDefault(p => p.ProductoID == id);

            // Limpiar los campos antes de realizar una nueva búsqueda
            LimpiarCampos();

            if (productoEncontrado != null)
            {
                // Si el producto existe, mostrar los datos en los campos correspondientes
                MostrarProductoEnCampos(productoEncontrado);

                // Mostrar solo el producto encontrado en el DataGridView
                CargarProductoEnDataGridView3(new List<Producto> { productoEncontrado });

                // Opcional: Si deseas que se seleccione el producto en la grilla después de la búsqueda
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    if ((int)row.Cells["ProductoID"].Value == productoEncontrado.ProductoID)
                    {
                        row.Selected = true;  // Seleccionar la fila del producto encontrado
                        break; // Terminar el ciclo una vez que se ha encontrado y seleccionado la fila
                    }
                }
            }
            else
            {
                // Si no se encuentra el producto, limpiar campos y mostrar un mensaje
                LimpiarCampos();
                CargarProductoEnDataGridView3();  // Mostrar todos los productos si no se encuentra
            }
        }

        private void CargarProductoEnDataGridView3(List<Producto> productosFiltrados)
        {
            // Limpiar el DataGridView
            dataGridView3.DataSource = null;

            // Si no se pasa una lista de productos filtrados, cargar todos los productos por defecto
            if (productosFiltrados == null)
            {
                productosFiltrados = Logica.ObtenerListaProductos();  // Obtener todos los productos
            }

            // Asignar la lista de productos (filtrados o completos) al DataGridView
            dataGridView3.DataSource = productosFiltrados;
        }

      
        private void textBoxPrecioP_TextChanged(object sender, EventArgs e)
        {
            // Verificar si el texto no está vacío
            if (string.IsNullOrWhiteSpace(textBoxPrecioP.Text))
            {
                return;  // No hacer nada si el campo está vacío
            }

            // Verificar si el texto es un número decimal válido
            if (!decimal.TryParse(textBoxPrecioP.Text, out decimal precio))
            {
                // Si no es un número válido, mostrar un mensaje
                MessageBox.Show("Por favor ingrese un precio válido. Asegúrese de que el precio sea un número decimal.", "Precio Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Limpiar el campo o tomar la acción que desees (en este caso no limpiar para no perder el input del usuario)
                textBoxPrecioP.SelectAll();  // Selecciona todo el texto para facilitar la corrección
            }
            else
            {
                // Si es un número válido, puedes realizar las acciones necesarias, por ejemplo, actualizar el producto
                // Aquí podrías continuar con el valor de 'precio' si es necesario
            }
        }

        public void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se haya hecho clic en una celda y que no sea la cabecera
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener la lista de productos ya cargada
                var productosListados = Logica.ObtenerListaProductos();

                // Si la lista está vacía, agregar los productos predeterminados
                if (productosListados.Count == 0)
                {
                    Logica.ListaProductos();  // Agregar los productos predeterminados
                    productosListados = Logica.ObtenerListaProductos();  // Obtener la lista después de agregar los productos
                }

                // Obtener la fila seleccionada y su producto
                DataGridViewRow filaSeleccionada = dataGridView3.Rows[e.RowIndex];
                Producto productoSeleccionado = (Producto)filaSeleccionada.DataBoundItem;

                // Asignar los valores de las propiedades del producto a los controles correspondientes
                textBoxIdP.Text = productoSeleccionado.ProductoID.ToString();  // ID
                textBoxNameP.Text = productoSeleccionado.Nombre;              // Nombre
                textBoxPrecioP.Text = productoSeleccionado.Precio.ToString(); // Precio
                textBoxCantidadP.Text = productoSeleccionado.Cantidad.ToString();  // Cantidad
                comboBoxCategoriaP.SelectedItem = productoSeleccionado.Categoria; // Categoría
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private bool primeraActualizacion = true; // Variable para controlar la primera actualización
        private bool firtsActuClie = true;
        private object cliente;
        private object listaClientes;
        private object clientes;

        public int idVenta { get; private set; }
        public List<Venta> ventasFiltradas { get; private set; }
        public object GestionClientes { get; private set; }

        private void btnGuardarP_Click(object sender, EventArgs e)
        
        {
            if (cv <= 0)
            {
                if (primeraActualizacion)
                {
                    // Llenar la lista de productos si está vacía
                    Logica.ListaProductos();
                    primeraActualizacion = true;
                }
                dataGridView3.DataSource = null;
                dataGridView3.DataSource = Logica.ObtenerListaProductos();
                cv++;
            }

            if(cvv == 0)
            {
                MessageBox.Show("Tabla actualizado correctamente");
                cvv++;
                return;
            }else if
            (string.IsNullOrWhiteSpace(textBoxNameP.Text) || string.IsNullOrWhiteSpace(textBoxPrecioP.Text) || string.IsNullOrWhiteSpace(textBoxCantidadP.Text) || comboBoxCategoriaP.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Crear un objeto del producto
            //Producto nuevoProducto = new Producto()
            Producto nuevoProducto = new Producto()
            {
                ProductoID = id,
                Nombre = textBoxNameP.Text,
                Categoria = comboBoxCategoriaP.SelectedItem.ToString(),
                Precio = decimal.Parse(textBoxPrecioP.Text),
                Cantidad = int.Parse(textBoxCantidadP.Text)
            };
            id++;

            // Llamar a la lógica para agregar el producto
            Logica.AgregarProducto(nuevoProducto);

            // Limpiar campos después de agregar
            LimpiarCampos();

            // Actualizar el DataGridView con todos los productos
            CargarProductoEnDataGridView3();

            //MessageBox.Show("Producto agregado exitosamente.");

            

            // Cargar la lista actualizada en el DataGridView3
            
        }
        

      
        private void button1_Click(object sender, EventArgs e)
        {

            // Verificar si hay una fila seleccionada
            if (dataGridView3.SelectedRows.Count > 0)
            {
                // Obtener el ID del producto seleccionado
                if (dataGridView3.SelectedRows[0].Cells["ProductoID"].Value is int productoId)
                {
                    // Confirmar eliminación con el usuario
                    var resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                    if (resultado == DialogResult.Yes)
                    {
                        // Eliminar el producto de la lista de productos
                        bool eliminado = GestionProductos.EliminarProducto(productoId);

                        Console.WriteLine("VARIABLE ELIMINADO: " + eliminado);

                        if (eliminado)
                        {
                            // Actualizar el DataGridView
                            ActualizarTabla(Logica.productos);
                            MessageBox.Show("Producto eliminado exitosamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el producto. Verifica que existe en la lista.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El ID del producto seleccionado no es válido.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.");
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

     
        private void button7_Click(object sender, EventArgs e)
        {
            string telefonoBusqueda = textBox7.Text.Trim(); // Obtener el texto del textbox

            if (!string.IsNullOrEmpty(telefonoBusqueda))
            {
                // Llamar al método ObtenerListaClientesPorTelefono para obtener los clientes filtrados
                var clientesFiltrados = Logica.ObtenerListadeClientesPorTelefono(telefonoBusqueda);

                // Actualizar la lista de clientes en el DataGridView o en el control correspondiente
                dataGridView4.DataSource = clientesFiltrados;
            }
            else
            {
                // Si el campo de búsqueda está vacío, mostrar todos los clientes
                dataGridView4.DataSource = Logica.ObtenerListaClientes();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // Intentar convertir el texto a un número entero
            if (int.TryParse(textBox6.Text, out int clienteID)) ;

          
            
            else
         
                // Si el texto no es un número válido
                MessageBox.Show("Por favor ingresa un ID de cliente válido.");
            }
        


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se haya hecho clic en una celda válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView2.Rows[e.RowIndex];

                // Obtener el ID de la venta de la fila seleccionada
                int idVentaSeleccionado = (int)filaSeleccionada.Cells[0].Value;  // Suponemos que la primera columna es el ID de la venta

                // Aquí puedes realizar una búsqueda en la base de datos o lista para obtener la venta y mostrar los detalles (cliente, total, etc.)

                // Ejemplo: Si tuvieras una lista de ventas, podrías filtrar por el ID de venta seleccionado
                Venta ventaSeleccionada = Logica.ObtenerVentaPorId(idVentaSeleccionado);

                // Mostrar los detalles de la venta en algún lugar de tu interfaz (por ejemplo, en un MessageBox o en controles de texto)
                MessageBox.Show($"Venta ID: {ventaSeleccionada.IdVenta}, Cliente: {ventaSeleccionada.ClienteNombre}, Total: {ventaSeleccionada.TotalVenta}");
            }
        }
        private void CargarVentasEnDataGridView2()
        {
            // Obtener la lista de ventas
            List<Venta> ventasListadas = Logica.ObtenerListaVentas();  // Supongamos que tienes un método que devuelve todas las ventas

            // Asignar la lista de ventas al DataGridView
            dataGridView2.DataSource = ventasListadas;
        }

        // Aquí una clase de ejemplo para representar las ventas (ajusta esto según tu modelo real)
        public class Venta
        {
            public int IdVenta { get; set; }
            public string ClienteNombre { get; set; }
            public decimal TotalVenta { get; set; }
        }

        // Y el método de lógica para obtener las ventas (ajusta según tus datos)
        public static List<Venta> ObtenerListaVentas()
        {
            return new List<Venta>
    {
        new Venta { IdVenta = 1234, ClienteNombre = "Juan Pérez", TotalVenta = 200.50m },
        new Venta { IdVenta = 1235, ClienteNombre = "María López", TotalVenta = 150.00m }
    };
        }



        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que no se haga clic en una celda del encabezado
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];

                // Obtener el ID del cliente desde la celda correspondiente
                string idCliente = row.Cells["ClienteID"].Value.ToString();
                string nombreCliente = row.Cells["Nombre"].Value.ToString();
                string direccionCliente = row.Cells["Direccion"].Value.ToString();
                string telefonoCliente = row.Cells["Telefono"].Value.ToString();

                // Asignar los valores al TextBox (o a otros controles si es necesario)
                textBox6.Text = idCliente;
                // Si tienes otros controles para mostrar el nombre, dirección y teléfono, puedes asignar esos también.
            }
        
     
         
            // Asignar la lista de clientes como la fuente de datos del DataGridView
            dataGridView4.DataSource = clientes;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            /*string busqueda = textBox5.Text.Trim(); // Obtener el texto que el usuario escribe y eliminar espacios al principio y al final

            if (!string.IsNullOrEmpty(busqueda))
            {
                Console.WriteLine("Estoy en busqueda clientes");
                // Filtrar la lista de clientes usando el texto ingresado en el TextBox
                var resultados = Logica.ObtenerListadeClientesPorTelefono(busqueda);

                // Mostrar los resultados de la búsqueda en un control, como un DataGridView, ListBox, etc.
                // Supongamos que tienes un DataGridView llamado dataGridViewClientes
                dataGridView4.DataSource = resultados;
            }
            else
            {
                // Si no hay texto en el TextBox, mostrar la lista completa de clientes
                dataGridView4.DataSource = Logica.ObtenerListaClientes();
            }*/
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            /*string telefonoBusqueda = textBox7.Text.Trim(); // Obtener el texto de búsqueda del teléfono

            if (!string.IsNullOrEmpty(telefonoBusqueda))
            {
                // Filtrar clientes que tengan un teléfono que contenga el texto ingresado
                var clientesFiltrados = Logica.ObtenerListaClientes()
                    .Where(cliente => cliente.Telefono.Contains(telefonoBusqueda))
                    .ToList();

                // Actualizar la lista de clientes en el DataGridView o en el control correspondiente
                dataGridView4.DataSource = clientesFiltrados;
            }
            else
            {
                // Si el campo de búsqueda está vacío, mostrar todos los clientes
                dataGridView4.DataSource = Logica.ObtenerListaClientes();
            }*/
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

            string telefonoBusqueda = textBox7.Text.Trim(); // Obtener el texto de búsqueda y quitar espacios innecesarios

            /*if (!string.IsNullOrEmpty(telefonoBusqueda))
            {
                // Filtrar clientes que tengan un teléfono que contenga el texto ingresado
                var clientesFiltrados = Logica.ObtenerListadeClientesPorTelefono(telefonoBusqueda);

                // Actualizar el DataGridView o el control que estés utilizando para mostrar los resultados
                dataGridView4.DataSource = clientesFiltrados;
            }
            else
            {
                // Si el campo de búsqueda está vacío, mostrar todos los clientes
                dataGridView4.DataSource = Logica.ObtenerListaClientes();
            }*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Obtener los datos ingresados en los TextBox
            string nombreCliente = textBox5.Text.Trim();
            string direccion = textBox7.Text.Trim();
            string telefono = textBox8.Text.Trim();

            // Verificar que todos los campos tengan datos
            if (string.IsNullOrEmpty(nombreCliente) || string.IsNullOrEmpty(direccion) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            Cliente addCliente = new Cliente()
            {
                ClienteID = idV,
                NombreC = nombreCliente,
                Direccion = direccion,
                Telefono = telefono
            };

            idV++;


            Logica.AgregarClientesPredeterminados(addCliente);

            // Limpiar los campos de los TextBox
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();

            // Actualizar el DataGridView con la nueva lista de clientes
            //dataGridView4.DataSource = null;  // Limpiar el DataGridView
            dataGridView4.DataSource = listaClientes;  // Asignar la lista actualizada

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cv <= 0)
            {
                if (firtsActuClie)
                {
                    // Llenar la lista de productos si está vacía
                    Logica.ListaClientes();
                    firtsActuClie = false;
                }
                dataGridView4.DataSource = null;
                dataGridView4.DataSource = Logica.ObtenerListaClientes();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que se haya hecho clic en una celda válida
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                // Obtener el producto asociado a esa fila
                Producto productoSeleccionado = (Producto)filaSeleccionada.DataBoundItem;

                // Mostrar solo los datos seleccionados en el ListBox
                listBox1.Items.Clear();  // Limpiar cualquier elemento previo
                listBox1.Items.Add($"ID: {productoSeleccionado.ProductoID}, Nombre: {productoSeleccionado.Nombre}, Precio: {productoSeleccionado.Precio}, Cantidad: {productoSeleccionado.Cantidad}");
            }
        }
       
        private List<Producto> ObtenerProductos()
        {
            throw new NotImplementedException();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Verificar que haya un producto seleccionado en el ListBox
            if (listBox1.SelectedItem != null)
            {
                // Eliminar el producto seleccionado del ListBox
                listBox1.Items.Remove(listBox1.SelectedItem);

               
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal total = 0;

            // Recorrer los elementos del ListBox y sumar los precios de los productos seleccionados
            foreach (var item in listBox1.Items)
            {
                // Suponemos que el formato del item es algo como "ID: 1, Nombre: ProductoA, Precio: 100, Cantidad: 2"
                string[] partes = item.ToString().Split(',');

                decimal precio = decimal.Parse(partes[2].Split(':')[1].Trim());
                int cantidad = int.Parse(partes[3].Split(':')[1].Trim());

                total += precio * cantidad;  // Sumar el total de la venta
            }

            // Mostrar el total en el textBox12
            textBox12.Text = total.ToString("F2");  // Muestra el total con dos decimales
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Verificar que haya un producto seleccionado en el ListBox
            if (listBox1.SelectedItem != null)
            {
                // Eliminar el producto seleccionado
                listBox1.Items.Remove(listBox1.SelectedItem);


            }
            else
            {
                // Si no hay un producto seleccionado, mostrar un mensaje de advertencia
                MessageBox.Show("Por favor, seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            // Obtener el nombre del cliente ingresado en textBox10
            string nombreCliente = textBox10.Text.Trim();

            // Filtrar las ventas en base al nombre del cliente
            var ventasFiltradas = ObtenerVentasPorCliente(nombreCliente);

            // Actualizar el DataGridView o cualquier otro control que muestre las ventas
            dataGridView2.DataSource = ventasFiltradas;
        }

        // Método para obtener las ventas filtradas por nombre de cliente
        private List<Venta> ObtenerVentasPorCliente(string nombreCliente)
        {
            // Llamar a la lógica para obtener todas las ventas
            var todasLasVentas = Logica.ObtenerListadeVentas();

            // Filtrar las ventas que coinciden con el nombre del cliente
            

            return ventasFiltradas;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int idVenta = new Random().Next(1000, 9999);  // Generar un ID aleatorio entre 1000 y 9999

            // Mostrar el ID de venta en textBox9
            textBox9.Text = idVenta.ToString();
        }

        // Método para generar el ID de la venta de forma incremental (puedes mejorar esto)
        private int GenerarIDVenta()
        {  
            return idVenta;
        }
    }
}

