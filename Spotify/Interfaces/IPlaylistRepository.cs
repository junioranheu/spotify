using Spotify.API.DTOs;

namespace Spotify.API.Interfaces
{
    public interface IPlaylistRepository
    {
        Task? Adicionar(PlaylistDTO dto);
        Task? Atualizar(PlaylistDTO dto);
        Task? Deletar(int id);
        Task<List<PlaylistDTO>>? GetTodos();
        Task<PlaylistDTO>? GetById(int id);
    }
}
