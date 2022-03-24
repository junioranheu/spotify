using Microsoft.EntityFrameworkCore;
using Spotify.Data;
using Spotify.Interfaces;
using Spotify.Models;

namespace Spotify.Repositories
{
    public class MusicaRepository : IMusicaRepository
    {
        public readonly Context _context;

        public MusicaRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<Musica>> GetTodos()
        {
            var estabelecimentosBd = await _context.Musicas.
                OrderBy(m => m.Nome).AsNoTracking().ToListAsync();

            return estabelecimentosBd;
        }

        public async Task<Musica> GetPorId(int id)
        {
            var musicaBd = await _context.Musicas.
                Where(m => m.MusicaId == id).AsNoTracking().FirstOrDefaultAsync();

            return musicaBd;
        }

        public async Task<int> PostCriar(Musica musica)
        {
            _context.Add(musica);
            var isOk = await _context.SaveChangesAsync();

            return isOk;
        }

        public async Task<int> PostAtualizar(Musica musica)
        {
            int isOk;

            try
            {
                _context.Update(musica);
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
            var dados = await _context.Musicas.FindAsync(id);

            if (dados == null)
            {
                throw new Exception("Registro com o id " + id + " não foi encontrado");
            }

            _context.Musicas.Remove(dados);
            var isOk = await _context.SaveChangesAsync();

            return isOk;
        }

        private async Task<bool> IsExiste(int id)
        {
            return await _context.Musicas.AnyAsync(m => m.MusicaId == id);
        }
    }
}
