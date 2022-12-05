using Spotify.API.DTOs;

namespace Spotify.API.Interfaces
{
    public interface IMusicaRepository
    {
        Task<MusicaDTO>? Adicionar(MusicaAdicionarDTO dto);
        Task? Atualizar(MusicaDTO dto);
        Task? Deletar(int id);
        Task<List<MusicaDTO>>? GetTodos();
        Task<MusicaDTO>? GetById(int id);
        Task<List<MusicaDTO>>? GetPorPlaylist(int id);
        Task<int>? PostIncrementarOuvinte(int id);
        Task<List<MusicaDTO>>? GetPorPalavraChave(string palavraChave);
    }
}
