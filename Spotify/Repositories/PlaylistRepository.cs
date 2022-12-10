using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spotify.API.Data;
using Spotify.API.DTOs;
using Spotify.API.Enums;
using Spotify.API.Interfaces;
using Spotify.API.Models;
using static Spotify.Utils.Biblioteca;

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

        public async Task<PlaylistDTO>? Adicionar(PlaylistDTO dto)
        {
            Playlist playlist = _map.Map<Playlist>(dto);

            await _context.AddAsync(playlist);
            await _context.SaveChangesAsync();

            // Atualizar foto;
            playlist.Foto = $"{playlist.PlaylistId}{GerarStringAleatoria(5, true)}.webp";
            _context.Update(playlist);
            await _context.SaveChangesAsync();

            PlaylistDTO dtoResultado = _map.Map<PlaylistDTO>(playlist);
            return dtoResultado;
        }

        public async Task<PlaylistDTO?>? Atualizar(PlaylistDTO dto)
        {
            var byId = await _context.Playlists.
                       Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Musicas).ThenInclude(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                       Where(p => p.PlaylistId == dto.PlaylistId).AsNoTracking().FirstOrDefaultAsync();

            if (byId is null)
            {
                PlaylistDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.NaoEncontrado, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.NaoEncontrado) };
                return erro;
            }

            PlaylistDTO oldDTO = _map.Map<PlaylistDTO>(byId);
     
            oldDTO.Nome = dto.Nome;
            oldDTO.Sobre = dto.Sobre;
            oldDTO.FotoAnterior = oldDTO.Foto;
            oldDTO.Foto = $"{oldDTO.PlaylistId}{GerarStringAleatoria(5, true)}.webp";
            oldDTO.CorDominante = dto.CorDominante;

            Playlist old = _map.Map<Playlist>(oldDTO);
            _context.Update(old);
            await _context.SaveChangesAsync();

            return oldDTO;
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

        public async Task<List<PlaylistDTO>>? GetTodosNaoAdm()
        {
            var todos = await _context.Playlists.
                        Include(u => u.Usuarios).
                        Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Musicas).ThenInclude(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                        Include(u => u.Usuarios).
                        OrderBy(n => n.Nome).
                        Where(u => u.UsuarioId != 1).AsNoTracking().ToListAsync();

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

        public async Task<List<PlaylistDTO>>? GetByUsuarioId(int id)
        {
            var byId = await _context.Playlists.
                       Include(u => u.Usuarios).
                       Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Musicas).ThenInclude(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                       Where(u => u.UsuarioId == id).
                       OrderByDescending(dr => dr.DataRegistro).AsNoTracking().ToListAsync();

            List<PlaylistDTO> dto = _map.Map<List<PlaylistDTO>>(byId);
            return dto;
        }
    }
}
