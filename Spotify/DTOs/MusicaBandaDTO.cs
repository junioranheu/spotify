using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.DTOs
{
    public class MusicaBandaDTO
    {
        [Key]
        public int MusicaBandaId { get; set; }

        // Fk (De lá pra cá);
        public int MusicaId { get; set; }
        public MusicaDTO? Musicas { get; set; }

        // Fk (De lá pra cá);
        public int BandaId { get; set; }
        public BandaDTO? Bandas { get; set; }

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
