using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
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

        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
