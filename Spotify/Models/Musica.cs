using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class Musica
    {
        [Key]
        public int MusicaId { get; set; }
        public string? Nome { get; set; }
        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }

        // Fk (De cá pra lá);
        public ICollection<MusicaArtista> MusicasArtistas { get; set; }

        // Fk (De cá pra lá);
        public ICollection<MusicaBanda> MusicasBandas { get; set; }
    }
}
