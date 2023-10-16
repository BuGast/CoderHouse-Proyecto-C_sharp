using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;
using SistemaGestionBussiness;


namespace SistemaGestionBussiness
{
    public static class ProductoBusiness
    {
        public static List<Producto> ObtenerProducto(int id)
        {
            return ProductoData.ObtenerProducto(id);
        }
        public static List<Producto> ListarProductos()
        {
            return ProductoData.ListarProductos();
        }
        public static void CrearProducto(Producto producto)
        {
            ProductoData.CrearProducto(producto);
        }
        public static void ModificarProducto(Producto productoModificado)
        {
            ProductoData.ModificarProducto(productoModificado);
        }
        public static void EliminarProducto(Producto productoAEliminar)
        {
            ProductoData.EliminarProducto(productoAEliminar);
        }
    }
}
