using Panaderia.Enums;

namespace Panaderia.Models
{
    static public class Sistema
    {
        static List<Producto> productos = new();
        static string ArchivoProductos = "productos.txt";

        static public void AgregarProducto()
        {
            Console.Write("Ingresar nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingresar el precio del producto: ");
            double precio = double.Parse(Console.ReadLine());

            Console.WriteLine("Seleccionar tipo de Categoria:");
            foreach (var tipo in Enum.GetValues(typeof(CategoriaProducto)))
            {
                Console.WriteLine($"{(int)tipo}. {tipo}");
            }
            int seleccion = int.Parse(Console.ReadLine());
            CategoriaProducto categoria = (CategoriaProducto)seleccion;

            Producto producto = new Producto(nombre, precio, categoria);
            productos.Add(producto);
            GuardarProducto(producto);
        }

        static public void MostrarProductos()
        {
            if (productos.Count > 0)
            {
                Console.WriteLine("Nombre -- Precio -- Categoria");
                foreach (var prod in productos)
                {
                    Console.WriteLine(prod);
                }
            }
            else { Console.WriteLine("No hay productos disponibles"); }
        }

        static public void ActualizarProducto(string nombre)
        {
            var producto = productos.Find(p => p.Nombre == nombre);

            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado.");
            }
            else
            {
                Console.Write("Ingresar el precio: ");
                double precio = double.Parse(Console.ReadLine());

                Console.WriteLine("Seleccionar tipo de Categoria:");
                foreach (var tipo in Enum.GetValues(typeof(CategoriaProducto)))
                {
                    Console.WriteLine($"{(int)tipo}. {tipo}");
                }
                int seleccion = int.Parse(Console.ReadLine());
                CategoriaProducto categoria = (CategoriaProducto)seleccion;

                producto.Precio = precio;
                producto.Categoria = categoria;
                GuardarDatos();
            }
        }

        static public void EliminarProducto(string nombre)
        {
            var producto = productos.Find(p => p.Nombre == nombre);

            if (producto == null)
            {
                Console.WriteLine("Producto no encontrado.");
            }
            else
            {
                productos.Remove(producto);
                Console.WriteLine("Producto eliminado.");
                GuardarDatos();
            }
        }

        static public void CalcularValorInventario()
        {
            double total = 0;

            foreach (var prod in productos)
            {
                total = total + prod.Precio;
            }

            Console.WriteLine($"Valora total del inventario: {total:C}");
        }

        static void GuardarProducto(Producto producto)
        {
            using StreamWriter writer = new StreamWriter(ArchivoProductos, true);
            writer.WriteLine(producto);
        }

        static void GuardarDatos()
        {
            using StreamWriter writer = new StreamWriter(ArchivoProductos);
            foreach (var p in productos)
            {
                writer.WriteLine(p);
            }
        }

        static public void CargarDatos()
        {
            if(File.Exists(ArchivoProductos))
            {
                foreach (var linea in File.ReadLines(ArchivoProductos))
                {
                    string[] d = linea.Split(", ");

                    string nombre = d[0];
                    double precio = double.Parse(d[1]);
                    CategoriaProducto categoria = (CategoriaProducto)Enum.Parse(typeof(CategoriaProducto), d[2]);                 

                    Producto p = new Producto(nombre, precio, categoria);
                    productos.Add(p);
                }
            }
        }
    }
}
