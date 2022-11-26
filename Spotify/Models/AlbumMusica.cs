using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Models
{
    public class AlbumMusica
    {
        [Key]
        public int AlbumMusicaId { get; set; }

        // Fk (De lá pra cá);
        public int AlbumId { get; set; }
        public Album? Albuns { get; set; }

        // Fk (De lá pra cá);
        public int MusicaId { get; set; }
        public Musica? Musicas { get; set; }

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
