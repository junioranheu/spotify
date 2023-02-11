using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spotify.API.Data;
using Spotify.API.DTOs;
using Spotify.API.Interfaces;
using Spotify.API.Models;

namespace Spotify.API.Repositories
{
    public sealed class LogRepository : ILogRepository
    {
        public readonly Context _context;
        private readonly IMapper _map;

        public LogRepository(Context context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task? Adicionar(LogDTO dto)
        {
            Log log = _map.Map<Log>(dto);

            await _context.AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LogDTO>>? GetTodos()
        {
            var todos = await _context.Logs.
                        OrderBy(l => l.DataRegistro).AsNoTracking().ToListAsync();

            List<LogDTO> dto = _map.Map<List<LogDTO>>(todos);
            return dto;
        }

        public async Task<LogDTO>? GetById(int id)
        {
            var byId = await _context.Logs.
                       Where(l => l.LogId == id).AsNoTracking().FirstOrDefaultAsync();

            LogDTO dto = _map.Map<LogDTO>(byId);
            return dto;
        }
    }
}
