using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class MusicaBanda
    {
        [Key]
        public int MusicaBandaId { get; set; }

        // Fk (De lá pra cá);
        public int MusicaId { get; set; }
        public Musica? Musicas { get; set; }

        // Fk (De lá pra cá);
        public int BandaId { get; set; }
        public Banda? Bandas { get; set; }

        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
