using Microsoft.EntityFrameworkCore;
using Spotify.Data;
using Spotify.Interfaces;
using Spotify.Models;

namespace Spotify.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        public readonly Context _context;

        public PlaylistRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Playlist>> GetTodos()
        {
            var itens = await _context.Playlists.
                Include(u => u.Usuarios).
                Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Musicas).ThenInclude(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                Include(u => u.Usuarios).
                OrderBy(n => n.Nome).AsNoTracking().ToListAsync();

            return itens;
        }

        public async Task<Playlist> GetPorId(int id)
        {
            var item = await _context.Playlists.
                Include(u => u.Usuarios).
                Include(pm => pm.PlaylistsMusicas).ThenInclude(m => m.Musicas).ThenInclude(mb => mb.MusicasBandas).ThenInclude(b => b.Bandas).
                Where(p => p.PlaylistId == id).AsNoTracking().FirstOrDefaultAsync();

            return item;
        }

        public async Task<int> PostCriar(Playlist playlist)
        {
            _context.Add(playlist);
            var isOk = await _context.SaveChangesAsync();

            return isOk;
        }

        public async Task<int> PostAtualizar(Playlist playlist)
        {
            int isOk;

            try
            {
                _context.Update(playlist);
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
            var dados = await _context.Playlists.FindAsync(id);

            if (dados == null)
            {
                throw new Exception("Registro com o id " + id + " não foi encontrado");
            }

            _context.Playlists.Remove(dados);
            var isOk = await _context.SaveChangesAsync();

            return isOk;
        }

        private async Task<bool> IsExiste(int id)
        {
            return await _context.Playlists.AnyAsync(p => p.PlaylistId == id);
        }
    }
}
