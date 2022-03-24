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

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<MusicaArtista> MusicasArtistas { get; set; }
        public DbSet<Banda> Bandas { get; set; }  
        public DbSet<MusicaBanda> MusicasBandas { get; set; }
        public DbSet<Musica> Musicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
