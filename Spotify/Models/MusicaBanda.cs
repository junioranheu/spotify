using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Models
{
    public class MusicaBanda
    {
        [Key]
        public int MusicaBandaId { get; set; }

        // Fk (De lá pra cá);
        public int MusicaId { get; set; }
        public Musica? Musicas { get; set; }

        // Fk (De lá pra cá);
        public int BandaId { get; set; }
        public Banda? Bandas { get; set; }

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}

