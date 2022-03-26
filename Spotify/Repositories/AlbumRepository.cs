using Microsoft.EntityFrameworkCore;
using Spotify.Data;
using Spotify.Interfaces;
using Spotify.Models;

namespace Spotify.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public readonly Context _context;

        public AlbumRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Album>> GetTodos()
        {
            var itens = await _context.Albuns.
                Include(b => b.Bandas).
                Include(a => a.AlbunsMusicas).ThenInclude(m => m.Musicas).
                OrderBy(m => m.Nome).AsNoTracking().ToListAsync();

            return itens;
        }

        public async Task<Album> GetPorId(int id)
        {
            var item = await _context.Albuns.
                Include(b => b.Bandas).
                Include(a => a.AlbunsMusicas).ThenInclude(m => m.Musicas).
                Where(m => m.AlbumId == id).AsNoTracking().FirstOrDefaultAsync();

            return item;
        }

        public async Task<int> PostCriar(Album album)
        {
            _context.Add(album);
            var isOk = await _context.SaveChangesAsync();

            return isOk;
        }

        public async Task<int> PostAtualizar(Album album)
        {
            int isOk;

            try
            {
                _context.Update(album);
                isOk = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isOk;
        }

        public async Task<int> PostDeletar(int id)
        {
            var dados = await _context.Albuns.FindAsync(id);

            if (dados == null)
            {
                throw new Exception("Registro com o id " + id + " não foi encontrado");
            }

            _context.Albuns.Remove(dados);
            var isOk = await _context.SaveChangesAsync();

            return isOk;
        }

        private async Task<bool> IsExiste(int id)
        {
            return await _context.Albuns.AnyAsync(m => m.AlbumId == id);
        }
    }
}
