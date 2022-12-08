using Spotify.API.DTOs;

namespace Spotify.API.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<PlaylistDTO>? Adicionar(PlaylistDTO dto);
        Task? Atualizar(PlaylistDTO dto);
        Task? Deletar(int id);
        Task<List<PlaylistDTO>>? GetTodos();
        Task<List<PlaylistDTO>>? GetTodosNaoAdm();
        Task<PlaylistDTO>? GetById(int id);
        Task<List<PlaylistDTO>>? GetByUsuarioId(int id);
    }
}
