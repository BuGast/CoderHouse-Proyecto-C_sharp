using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVenta")]
        public IEnumerable<Venta> Get()
        {
            return VentaBusiness.ListarVenta().ToArray();
        }

        [HttpDelete(Name = "BajaVenta")]
        public void Delete([FromBody] Venta ventaAEliminar)
        {
            VentaBusiness.EliminarVenta(ventaAEliminar);
        }

        [HttpPut(Name = "ModificarVenta")]
        public void Put([FromBody] Venta ventaModificada)
        {
            VentaBusiness.ModificarVenta(ventaModificada);
        }

        [HttpPost(Name = "AltaVenta")]
        public void Post([FromBody] Venta venta)
        {
            VentaBusiness.CrearVenta(venta);
        }
    }
}
