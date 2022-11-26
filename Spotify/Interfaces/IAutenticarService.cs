using Spotify.API.DTOs;

namespace Spotify.API.Interfaces
{
    public interface IAutenticarService
    {
        Task<UsuarioDTO>? Registrar(UsuarioSenhaDTO dto);
        Task<UsuarioDTO>? Login(UsuarioSenhaDTO dto);
        Task<UsuarioDTO> RefreshToken(string token, string refreshToken);
    }
}
