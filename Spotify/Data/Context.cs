using Microsoft.EntityFrameworkCore;
using Spotify.Models;

namespace Spotify.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            //
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioTipo> UsuariosTipos { get; set; }
        public DbSet<UsuarioInformacao> UsuariosInformacoes { get; set; }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<BandaArtista> BandasArtistas { get; set; }
        public DbSet<Banda> Bandas { get; set; }  
        public DbSet<MusicaBanda> MusicasBandas { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<AlbumMusica> AlbunsMusicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
