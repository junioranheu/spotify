using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Models
{
    public class Artista
    {
        [Key]
        public int ArtistaId { get; set; }
        public string? Nome { get; set; } = null;
        public string? Foto { get; set; } = null;

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();

        // Fk (De cá pra lá);
        public List<BandaArtista>? BandaArtistas { get; set; }
    }
}
