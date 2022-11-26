using Microsoft.EntityFrameworkCore;
using Spotify.API.Models;

namespace Spotify.API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            //
        }

        // Outros;
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        // Usuários e afins;
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioTipo> UsuariosTipos { get; set; }

        // Outros;
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<BandaArtista> BandasArtistas { get; set; }
        public DbSet<Banda> Bandas { get; set; }  
        public DbSet<MusicaBanda> MusicasBandas { get; set; }
        public DbSet<Musica> Musicas { get; set; }

        // Albuns e afins;
        public DbSet<Album> Albuns { get; set; }
        public DbSet<AlbumMusica> AlbunsMusicas { get; set; }

        // Playlists;
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<PlaylistMusica> PlaylistsMusicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
