using Spotify.API.DTOs;

namespace Spotify.API.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task? Adicionar(RefreshTokenDTO dto);
        Task<string>? GetRefreshTokenByUsuarioId(int usuarioId);
    }
}
