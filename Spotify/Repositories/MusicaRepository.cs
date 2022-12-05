using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spotify.API.Data;
using Spotify.API.DTOs;
using Spotify.API.Interfaces;
using Spotify.API.Models;

namespace Spotify.API.Repositories
{
    public class MusicaRepository : IMusicaRepository
    {
        public readonly Context _context;
        private readonly IMapper _map;

        public MusicaRepository(Context context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task<int> Adicionar(MusicaAdicionarDTO dto)
        {
            Musica musica = _map.Map<Musica>(dto);

            await _context.AddAsync(musica);
            await _context.SaveChangesAsync();

            return musica.MusicaId;
        }

        public async Task? Atualizar(MusicaDTO dto)
        {
            Musica musica = _map.Map<Musica>(dto);

            _context.Update(musica);
            await _context.SaveChangesAsync();

        }

        public async Task? Deletar(int id)
        {
            var dados = await _context.Musicas.FindAsync(id);

            if (dados == null)
            {
                throw new Exception("Registro com o id " + id + " não foi encontrado");
            }

            _context.Musicas.Remove(dados);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MusicaDTO>>? GetTodos()
        {
            var todos = await _context.Musicas.
                        Include(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                        ThenInclude(ba => ba.BandasArtistas).ThenInclude(a => a.Artistas).
                        Include(am => am.AlbunsMusicas).ThenInclude(a => a.Albuns).
                        OrderBy(n => n.Nome).AsNoTracking().ToListAsync();

            List<MusicaDTO> dto = _map.Map<List<MusicaDTO>>(todos);
            return dto;
        }

        public async Task<MusicaDTO>? GetById(int id)
        {
            var byId = await _context.Musicas.
                       Include(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                       ThenInclude(ba => ba.BandasArtistas).ThenInclude(a => a.Artistas).
                       Include(am => am.AlbunsMusicas).ThenInclude(a => a.Albuns).
                       Where(m => m.MusicaId == id).AsNoTracking().FirstOrDefaultAsync();

            MusicaDTO dto = _map.Map<MusicaDTO>(byId);
            return dto;
        }

        public async Task<List<MusicaDTO>>? GetPorPlaylist(int id)
        {
            var todos = await _context.Musicas.
                        Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Playlists).

                        Include(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                        ThenInclude(ba => ba.BandasArtistas).ThenInclude(a => a.Artistas).
                        Include(am => am.AlbunsMusicas).ThenInclude(a => a.Albuns).

                        Where(p => p.IsAtivo == true && p.PlaylistsMusicas.All(z => z.PlaylistId == id)).AsNoTracking().ToListAsync();

            List<MusicaDTO> dto = _map.Map<List<MusicaDTO>>(todos);
            return dto;
        }

        public async Task<int>? PostIncrementarOuvinte(int id)
        {
            int isOk;

            try
            {
                var musica = await _context.Musicas.Where(m => m.MusicaId == id).AsNoTracking().FirstOrDefaultAsync();

                if (musica == null)
                {
                    throw new Exception($"Nenhuma música foi encontrada com o id {id}");
                }

                musica.Ouvintes += 1;

                _context.Update(musica);
                isOk = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isOk;
        }

        public async Task<List<MusicaDTO>>? GetPorPalavraChave(string palavraChave)
        {
            var todos = await _context.Musicas.
                        Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Playlists).
                        Include(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).ThenInclude(ba => ba.BandasArtistas).ThenInclude(a => a.Artistas).
                        Include(am => am.AlbunsMusicas).ThenInclude(a => a.Albuns).

                        Where(p => p.IsAtivo == true
                        && (
                            p.Nome.Contains(palavraChave) || // Nome da música;
                            p.MusicasBandas.All(z => z.Bandas.Nome.Contains(palavraChave)) // Nome da banda;
                        )).AsNoTracking().ToListAsync();

            List<MusicaDTO> dto = _map.Map<List<MusicaDTO>>(todos);
            return dto;
        }
    }
}
