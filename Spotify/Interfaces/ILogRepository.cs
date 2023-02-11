using Spotify.API.DTOs;

namespace Spotify.API.Interfaces
{
    public interface ILogRepository
    {
        Task? Adicionar(LogDTO dto);
        Task<LogDTO>? GetById(int id);
        Task<List<LogDTO>>? GetTodos();
    }
}