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
        Task<List<MusicaDTO>>? GetByPlaylistId(int id);
        Task<int>? PostIncrementarOuvinte(int id);
        Task<List<MusicaDTO>>? GetByPalavraChave(string palavraChave);
        Task<bool>? AtualizarDuracaoMusica(int id, string caminhoArquivo);
    }
}
