using Spotify.Models;

namespace Spotify.Interfaces
{
    public interface IAlbumRepository
    {
        Task<List<Album>> GetTodos();
        Task<Album> GetPorId(int id);
        Task<int> PostCriar(Album album);
        Task<int> PostAtualizar(Album album);
        Task<int> PostDeletar(int id);
    }
}
