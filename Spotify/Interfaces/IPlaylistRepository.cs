using Spotify.Models;

namespace Spotify.Interfaces
{
    public interface IPlaylistRepository
    {
        Task<List<Playlist>> GetTodos();
        Task<Playlist> GetPorId(int id);
        Task<int> PostCriar(Playlist playlist);
        Task<int> PostAtualizar(Playlist playlist);
        Task<int> PostDeletar(int id);
    }
}
