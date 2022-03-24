using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class MusicaArtista
    {
        [Key]
        public int MusicaArtistaId { get; set; }

        // Fk (De lá pra cá);
        public int MusicaId { get; set; }
        public Musica? Musicas { get; set; }

        // Fk (De lá pra cá);
        public int ArtistaId { get; set; }
        public Artista? Artistas { get; set; }

        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
