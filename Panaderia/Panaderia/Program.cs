using Panaderia.Models;

namespace Panaderia
{
    public class Program
    {
        static void Main()
        {
            Sistema.CargarDatos();
            int opcion;

            do
            {
                Console.WriteLine("\n     --- Menu ---");
                Console.WriteLine("1. Agregar nuevo producto.");
                Console.WriteLine("2. Mostrar productos.");
                Console.WriteLine("3. Actualizar detalles del producto.");
                Console.WriteLine("4. Eliminar producto.");
                Console.WriteLine("5. Calcular el valor del inventario.");
                Console.WriteLine("6. Salir");


                Console.Write("Opcion: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n");
                        Sistema.AgregarProducto();
                        break;

                    case 2:
                        Console.WriteLine("\n");
                        Sistema.MostrarProductos();
                        break;

                    case 3:
                        Console.WriteLine("\n");
                        Console.Write("Ingresar nombre del producto a actualizar: ");
                        string nombre = Console.ReadLine();
                        Sistema.ActualizarProducto(nombre);
                        break;

                    case 4:
                        Console.Write("Ingresar nombre del producto a eliminar: ");
                        string nombre2 = Console.ReadLine();
                        Sistema.EliminarProducto(nombre2);
                        break;
                    case 5:
                        Console.WriteLine("\n");
                        Sistema.CalcularValorInventario();
                        break;
                }
            } while (opcion != 6);
        }
    }
}
