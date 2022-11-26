using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string? Nome { get; set; } = null;
        public string? Sobre { get; set; } = null;
        public string? Foto { get; set; } = null;
        public DateTime DataLancamento { get; set; } = HorarioBrasilia();

        // Fk (De lá pra cá);
        public int BandaId { get; set; }
        [JsonIgnore]
        public Banda? Bandas { get; set; }

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();

        // Fk (De cá pra lá);
        [JsonIgnore]
        public List<AlbumMusica>? AlbunsMusicas { get; set; }
    }
}
