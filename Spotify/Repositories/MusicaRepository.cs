using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NAudio.Wave;
using Spotify.API.Data;
using Spotify.API.DTOs;
using Spotify.API.Enums;
using Spotify.API.Interfaces;
using Spotify.API.Models;
using static Spotify.Utils.Biblioteca;

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

        public async Task<MusicaDTO> Adicionar(MusicaAdicionarDTO dto)
        {
            try
            {
                // #1 - Adicionar a música no BD;
                Musica musica = _map.Map<Musica>(dto);
                await _context.AddAsync(musica);
                await _context.SaveChangesAsync();

                // #2 - Adicionar a música nas playlists selecionadas;
                dto.MusicaId = musica.MusicaId;
                bool isOk = await AdicionarMusicaEmPlaylists(dto);

                MusicaDTO musicaDTO = _map.Map<MusicaDTO>(musica);
                return musicaDTO;
            }
            catch (Exception)
            {
                MusicaDTO erro = new() { Erro = true, CodigoErro = (int)CodigosErrosEnum.ErroInterno, MensagemErro = GetDescricaoEnum(CodigosErrosEnum.ErroInterno) };
                return erro;
            }
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

        public async Task<List<MusicaDTO>>? GetByPlaylistId(int id)
        {
            var todos = await _context.Musicas.
                        Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Playlists).

                        Include(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                        ThenInclude(ba => ba.BandasArtistas).ThenInclude(a => a.Artistas).
                        Include(am => am.AlbunsMusicas).ThenInclude(a => a.Albuns).

                        // Where(p => p.IsAtivo == true && p.PlaylistsMusicas.All(z => z.PlaylistId == id)).
                        Where(p => p.IsAtivo == true && p.PlaylistsMusicas.Any(z => z.PlaylistId == id)).
                        OrderBy(dr => dr.DataRegistro).AsNoTracking().ToListAsync();

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

        public async Task<List<MusicaDTO>>? GetByPalavraChave(string palavraChave)
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

        public async Task<bool>? AtualizarDuracaoMusica(int id, string caminhoMusica)
        {
            if (File.Exists(caminhoMusica))
            {
                try
                {
                    Mp3FileReader reader = new(caminhoMusica); // https://stackoverflow.com/a/34518350
                    TimeSpan duracao = reader.TotalTime;

                    var byId = await _context.Musicas.Where(m => m.MusicaId == id).FirstOrDefaultAsync();
                    byId.DuracaoSegundos = (int)duracao.TotalSeconds;

                    _context.Update(byId);
                    await _context.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;
        }

        public async Task<bool>? AdicionarMusicaEmPlaylists(MusicaAdicionarDTO dto)
        {
            try
            {
                Musica musica = _map.Map<Musica>(dto);

                if (dto.ListaPlaylists?.Count > 0)
                {
                    List<PlaylistMusica> pms = new();

                    foreach (var playlist in dto.ListaPlaylists)
                    {
                        PlaylistMusica pm = new()
                        {
                            PlaylistId = playlist,
                            MusicaId = musica.MusicaId
                        };

                        pms.Add(pm);
                    }

                    await _context.AddRangeAsync(pms);
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
