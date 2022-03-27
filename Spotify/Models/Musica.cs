using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Spotify.Models
{
    public class Musica
    {
        [Key]
        public int MusicaId { get; set; }
        public string? Nome { get; set; }
        public int Ouvintes { get; set; }
        public DateTime DataLancamento { get; set; }
        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<MusicaBanda> MusicasBandas { get; set; }

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<AlbumMusica> AlbunsMusicas { get; set; }
    }
}
