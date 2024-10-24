using Panaderia.Enums;

namespace Panaderia.Models
{
    public class Producto
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public CategoriaProducto Categoria { get; set; }

        public Producto(string nombre, double precio, CategoriaProducto categoria)
        {
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"{Nombre}, {Precio}, {Categoria}";
        }
    }
}
