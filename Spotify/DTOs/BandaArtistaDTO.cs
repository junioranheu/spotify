using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.DTOs
{
    public class BandaArtistaDTO
    {
        [Key]
        public int BandaArtistaId { get; set; }

        // Fk (De lá pra cá);
        public int BandaId { get; set; }
        public BandaDTO? Bandas { get; set; }

        // Fk (De lá pra cá);
        public int ArtistaId { get; set; }
        public ArtistaDTO? Artistas { get; set; }

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
