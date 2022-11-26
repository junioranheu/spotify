using System.ComponentModel;

namespace Spotify.API.Enums
{
    public enum UsuarioTipoEnum
    {
        Administrador = 1,

        [Description("Usuário")]
        Usuario = 2
    }
}
