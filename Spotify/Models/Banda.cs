using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class Banda
    {
        [Key]
        public int BandaId { get; set; }
        public string? Nome { get; set; }
        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }

        // Fk (De cá pra lá);
        public ICollection<MusicaBanda> MusicasBandas { get; set; }

        // Fk (De cá pra lá);
        public ICollection<BandaArtista> BandasArtistas { get; set; }
    }
}
