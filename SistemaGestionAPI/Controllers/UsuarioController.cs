using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuario")]
        public IEnumerable<Usuario> Get()
        {
            return UsuarioBusiness.ListarUsuarios().ToArray();
        }

        [HttpDelete(Name = "BajaUsuario")]
        public void Delete([FromBody] Usuario usuarioAEliminar)
        {
            UsuarioBusiness.EliminarUsuario(usuarioAEliminar);
        }

        [HttpPut(Name = "ModificarUsuario")]
        public void Put([FromBody] Usuario usuarioModificado)
        {
            UsuarioBusiness.ModificarUsuario(usuarioModificado);
        }

        [HttpPost(Name = "AltaUsuario")]
        public void Post([FromBody] Usuario usuario)
        {
            UsuarioBusiness.CrearUsuario(usuario);
        }
    }
}
