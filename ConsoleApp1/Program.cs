using ConsoleApp1;
using System;

class Program
{
    static void Main(string[] args)
    {
        Inventario inventario = new Inventario();

        Console.WriteLine("Digitalize los datos de los productos:");
        for (int i = 0; i < 3; i++)
        {
            string nombre;
            decimal precio;

            do
            {
                Console.Write("Digitalize el nombre del producto ");
                nombre = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(nombre));

            do
            {
                Console.Write("Digitalize el precio del producto (debe ser un número positivo, sea serio ve): ");
            } while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0);

            inventario.AgregarProducto(new Producto(nombre, precio));
        }

        Console.Write("Digitalize el precio mínimo para poder filtrar productos: ");
        decimal precioMinimo = decimal.Parse(Console.ReadLine());
        var productosFiltrados = inventario.FiltrarPorPrecio(precioMinimo);
        Console.WriteLine("\nProductos filtrados por precio:");
        foreach (var producto in productosFiltrados)
        {
            producto.MostrarInformacion();
        }

        Console.Write("La actualización de precio - Digitalize el nombre del producto para actualizar: ");
        string nombreActualizar = Console.ReadLine();
        Console.Write("Digitalize el nuevo precio: ");
        decimal nuevoPrecio = decimal.Parse(Console.ReadLine());
        bool actualizado = inventario.ActualizarPrecio(nombreActualizar, nuevoPrecio);
        Console.WriteLine(actualizado ? "Precio actualizado correctamente." : "Producto no encontrado.");

        Console.Write("\nEliminación de producto - Digitalize el nombre del producto que quiere eliminar: ");
        string nombreEliminar = Console.ReadLine();
        bool eliminado = inventario.EliminarProducto(nombreEliminar);
        Console.WriteLine(eliminado ? "Producto eliminado correctamente." : "Producto no encontrado.");

        Console.WriteLine("\nConteo y agrupación de productos por rango de precio:");
        var gruposDeProductos = inventario.ContarAgruparProductosPorRango();
        foreach (var grupo in gruposDeProductos)
        {
            Console.WriteLine($"{grupo.Key}: {grupo.Value} productos");
        }

        Console.WriteLine("\nReporte resumido del inventario:");
        inventario.GenerarReporte();

            Console.WriteLine("Digitalizar un nuevo producto al inventario:");
        string nuevoNombre;
        decimal nuevoPrecioProducto;

        do
        {
            Console.Write("Digitalizar el nombre del nuevo producto: ");
            nuevoNombre = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(nuevoNombre));

        do
        {
            Console.Write("Digitalizar el precio del nuevo producto (debe ser positivo): ");
        } while (!decimal.TryParse(Console.ReadLine(), out nuevoPrecioProducto) || nuevoPrecioProducto <= 0);

        Producto nuevoProducto = new Producto(nuevoNombre, nuevoPrecioProducto);
        inventario.AgregarProducto(nuevoProducto);
        Console.WriteLine("El producto fue agregado con éxito:");
        nuevoProducto.MostrarInformacion();

        Console.WriteLine("¡Felicidades el programa ha sido completado con mucho éxito!");
    }
}

