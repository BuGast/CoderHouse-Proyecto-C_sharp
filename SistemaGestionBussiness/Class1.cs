using SistemaGestionData;
using SistemaGestionEntities;
using SistemaGestionBussiness;

namespace SistemaGestionBussiness
{
    public static class UsuarioBusiness
    {
        public static List<Usuario> ObtenerUsuario(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }
        public static List<Usuario> ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }
        public static void CrearUsuario(Usuario usuario)
        {
            UsuarioData.CrearUsuario(usuario);
        }
        public static void ModificarUsuario(Usuario usuarioModificado)
        {
            UsuarioData.ModificarUsuario(usuarioModificado);
        }
        public static void EliminarUsuario(Usuario usuarioAEliminar)
        {
            UsuarioData.EliminarUsuario(usuarioAEliminar);
        }
    }
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
    public static class VentaBusiness
    {
        public static List<Venta> ObtenerVenta(int id)
        {
            return VentaData.ObtenerVenta(id);
        }
        public static List<Venta> ListarVenta()
        {
            return VentaData.ListarVenta();
        }
        public static void CrearVenta(Venta venta)
        {
            VentaData.CrearVenta(venta);
        }
        public static void ModificarVenta(Venta ventaModificada)
        {
            VentaData.ModificarVenta(ventaModificada);
        }
        public static void EliminarVenta(Venta ventaAEliminar)
        {
            VentaData.EliminarVenta(ventaAEliminar);
        }
    }
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