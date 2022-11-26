using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Models
{
    public class Musica
    {
        [Key]
        public int MusicaId { get; set; }
        public string? Nome { get; set; } = null;
        public int Ouvintes { get; set; } = 0;
        public int DuracaoSegundos { get; set; } = 0;
        public DateTime DataLancamento { get; set; } = HorarioBrasilia();

        public bool IsAtivo { get; set; } = true; 
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();

        // Fk (De cá pra lá);
        [JsonIgnore]
        public List<MusicaBanda>? MusicasBandas { get; set; }

        // Fk (De cá pra lá);
        [JsonIgnore]
        public List<AlbumMusica>? AlbunsMusicas { get; set; }

        // Fk (De cá pra lá);
        [JsonIgnore]
        public List<PlaylistMusica>? PlaylistsMusicas { get; set; }
    }
}
