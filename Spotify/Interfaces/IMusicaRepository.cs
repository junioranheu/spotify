using Spotify.Models;

namespace Spotify.Interfaces
{
    public interface IMusicaRepository
    {
        Task<List<Musica>> GetTodos();
        Task<Musica> GetPorId(int id);
        Task<List<Musica>> GetPorPlaylist(int id);
        Task<int> PostCriar(Musica musica);
        Task<int> PostAtualizar(Musica musica);
        Task<int> PostDeletar(int id);
        Task<int> PostIncrementarOuvinte(int musicaId);
        Task<List<Musica>> GetPorPalavraChave(string palavraChave);
    }
}
