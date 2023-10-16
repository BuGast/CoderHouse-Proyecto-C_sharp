using SistemaGestionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionBussiness;

namespace SistemaGestionBussiness
{
    public static class ProductoVendidoBusiness
    {
        public static List<ProductoVendido> ObtenerProductoVendido(int id)
        {
            return ProductoVendidoData.ObtenerProductoVendido(id);
        }
        public static List<ProductoVendido> ListarProductoVendido()
        {
            return ProductoVendidoData.ListarProductoVendido();
        }
        public static void CrearProductoVendido(ProductoVendido productovendido)
        {
            ProductoVendidoData.CrearProductoVendido(productovendido);
        }
        public static void ModificarProductoVendido(ProductoVendido productovendido)
        {
            ProductoVendidoData.ModificarProductoVendido(productovendido);
        }
        public static void EliminarProductoVendido(ProductoVendido productovendido)
        {
            ProductoVendidoData.EliminarProductoVendido(productovendido);
        }
    }
}
