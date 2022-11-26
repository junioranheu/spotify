using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Models
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

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
