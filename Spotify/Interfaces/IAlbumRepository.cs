using Spotify.API.DTOs;

namespace Spotify.API.Interfaces
{
    public interface IAlbumRepository
    {
        Task? Adicionar(AlbumDTO dto);
        Task? Atualizar(AlbumDTO dto);
        Task? Deletar(int id);
        Task<List<AlbumDTO>>? GetTodos();
        Task<AlbumDTO>? GetById(int id);
    }
}
