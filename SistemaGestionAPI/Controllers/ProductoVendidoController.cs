using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {

        [HttpGet(Name = "GetProductoVendido")]
        public IEnumerable<ProductoVendido> Get()
        {
            return ProductoVendidoBusiness.ListarProductoVendido().ToArray();
        }

        [HttpDelete(Name = "BajaProductoVendido")]
        public void Delete([FromBody] ProductoVendido productovendido)
        {
            ProductoVendidoBusiness.EliminarProductoVendido(productovendido);
        }

        [HttpPut(Name = "ModificarProductoVendido")]
        public void Put([FromBody] ProductoVendido productovendido)
        {
            ProductoVendidoBusiness.ModificarProductoVendido(productovendido);
        }

        [HttpPost(Name = "AltaProductoVendido")]
        public void Post([FromBody] ProductoVendido productovendido)
        {
            ProductoVendidoBusiness.CrearProductoVendido(productovendido);
        }

    }
}
