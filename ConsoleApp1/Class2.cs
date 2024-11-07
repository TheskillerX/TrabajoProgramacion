using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;

public class Inventario
{
    private List<Producto> productos;

    public Inventario()
    {
        productos = new List<Producto>();
    }

    public void AgregarProducto(Producto producto)
    {
        productos.Add(producto);
    }

    public IEnumerable<Producto> FiltrarPorPrecio(decimal precioMinimo)
    {
        return productos.Where(p => p.Precio > precioMinimo).OrderBy(p => p.Precio);
    }

    public bool ActualizarPrecio(string nombre, decimal nuevoPrecio)
    {
        var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (producto != null)
        {
            producto.Precio = nuevoPrecio;
            return true;
        }
        return false;
    }

    public bool EliminarProducto(string nombre)
    {
        var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        if (producto != null)
        {
            productos.Remove(producto);
            return true;
        }
        return false;
    }

    public Dictionary<string, int> ContarAgruparProductosPorRango()
    {
        var grupos = productos.GroupBy(p =>
            p.Precio < 100 ? "Menor a 100" :
            p.Precio <= 500 ? "Entre 100 y 500" :
            "Mayor a 500")
            .ToDictionary(g => g.Key, g => g.Count());

        return grupos;
    }

    public void GenerarReporte()
    {
        Console.WriteLine($"El  total de productos es: {productos.Count}");
        Console.WriteLine($"El precio promedio es: {productos.Average(p => p.Precio):C}");

        var productoMasCaro = productos.OrderByDescending(p => p.Precio).FirstOrDefault();
        var productoMasBarato = productos.OrderBy(p => p.Precio).FirstOrDefault();

        Console.WriteLine($"El producto más caro: {productoMasCaro?.Nombre} - {productoMasCaro?.Precio:C}");
        Console.WriteLine($"El producto más barato: {productoMasBarato?.Nombre} - {productoMasBarato?.Precio:C}");
    }
}
