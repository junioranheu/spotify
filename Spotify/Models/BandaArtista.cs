using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class BandaArtista
    {
        [Key]
        public int BandaArtistaId { get; set; }

        // Fk (De lá pra cá);
        public int BandaId { get; set; }
        public Banda? Bandas { get; set; }

        // Fk (De lá pra cá);
        public int ArtistaId { get; set; }
        public Artista? Artistas { get; set; }

        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
