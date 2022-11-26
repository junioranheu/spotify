using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spotify.API.Data;
using Spotify.API.DTOs;
using Spotify.API.Interfaces;
using Spotify.API.Models;

namespace Spotify.API.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public readonly Context _context;
        private readonly IMapper _map;

        public AlbumRepository(Context context, IMapper map)
        {
            _context = context;
            _map = map;
        }

        public async Task? Adicionar(AlbumDTO dto)
        {
            Album album = _map.Map<Album>(dto);

            await _context.AddAsync(album);
            await _context.SaveChangesAsync();
        }

        public async Task? Atualizar(AlbumDTO dto)
        {
            Album album = _map.Map<Album>(dto);

            _context.Update(album);
            await _context.SaveChangesAsync();
        }

        public async Task? Deletar(int id)
        {
            var dados = await _context.Albuns.FindAsync(id);

            if (dados == null)
            {
                throw new Exception("Registro com o id " + id + " não foi encontrado");
            }

            _context.Albuns.Remove(dados);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AlbumDTO>>? GetTodos()
        {
            var todos = await _context.Albuns.
                        Include(b => b.Bandas).
                        Include(a => a.AlbunsMusicas).ThenInclude(m => m.Musicas).
                        OrderBy(n => n.Nome).AsNoTracking().ToListAsync();

            List<AlbumDTO> dto = _map.Map<List<AlbumDTO>>(todos);
            return dto;
        }

        public async Task<AlbumDTO>? GetById(int id)
        {
            var byId = await _context.Albuns.
                       Include(b => b.Bandas).
                       Include(a => a.AlbunsMusicas).ThenInclude(m => m.Musicas).
                       Where(m => m.AlbumId == id).AsNoTracking().FirstOrDefaultAsync();

            AlbumDTO dto = _map.Map<AlbumDTO>(byId);
            return dto;
        }
    }
}
