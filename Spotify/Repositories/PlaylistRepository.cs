using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spotify.API.Data;
using Spotify.API.DTOs;
using Spotify.API.Interfaces;
using Spotify.API.Models;

namespace Spotify.API.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        public readonly Context _context;
        private readonly IMapper _map;

        public PlaylistRepository(Context context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task? Adicionar(PlaylistDTO dto)
        {
            Playlist playlist = _map.Map<Playlist>(dto);

            await _context.AddAsync(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task? Atualizar(PlaylistDTO dto)
        {
            Playlist playlist = _map.Map<Playlist>(dto);

            _context.Update(playlist);
            await _context.SaveChangesAsync();
        }

        public async Task? Deletar(int id)
        {
            var dados = await _context.Playlists.FindAsync(id);

            if (dados == null)
            {
                throw new Exception("Registro com o id " + id + " não foi encontrado");
            }

            _context.Playlists.Remove(dados);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PlaylistDTO>>? GetTodos()
        {
            var todos = await _context.Playlists.
                        Include(u => u.Usuarios).
                        Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Musicas).ThenInclude(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                        Include(u => u.Usuarios).
                        OrderBy(n => n.Nome).AsNoTracking().ToListAsync();

            List<PlaylistDTO> dto = _map.Map<List<PlaylistDTO>>(todos);
            return dto;
        }

        public async Task<PlaylistDTO>? GetById(int id)
        {
            var byId = await _context.Playlists.
                       Include(u => u.Usuarios).
                       Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Musicas).ThenInclude(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                       Where(p => p.PlaylistId == id).AsNoTracking().FirstOrDefaultAsync();

            PlaylistDTO dto = _map.Map<PlaylistDTO>(byId);
            return dto;
        }

        public async Task<PlaylistDTO>? GetByUsuarioId(int id)
        {
            var byId = await _context.Playlists.
                       Include(u => u.Usuarios).
                       Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Musicas).ThenInclude(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                       Where(u => u.UsuarioId == id).AsNoTracking().FirstOrDefaultAsync();

            PlaylistDTO dto = _map.Map<PlaylistDTO>(byId);
            return dto;
        }
    }
}
