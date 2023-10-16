using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProducto")]
        public IEnumerable<Producto> Get()
        {
            return ProductoBusiness.ListarProductos().ToArray();
        }

        [HttpDelete(Name = "BajaProducto")]
        public void Delete([FromBody] Producto productoAEliminar)
        {
            ProductoBusiness.EliminarProducto(productoAEliminar);
        }

        [HttpPut(Name = "ModificarProducto")]
        public void Put([FromBody] Producto producto)
        {
            ProductoBusiness.ModificarProducto(producto);
        }

        [HttpPost(Name = "AltaProducto")]
        public void Post([FromBody] Producto producto)
        {
            ProductoBusiness.CrearProducto(producto);
        }
    }
}
