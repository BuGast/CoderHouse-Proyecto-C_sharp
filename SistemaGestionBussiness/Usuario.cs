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
}