using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.DTOs
{
    public class AlbumMusicaDTO : _RetornoApiDTO
    {
        [Key]
        public int AlbumMusicaId { get; set; }

        // Fk (De lá pra cá);
        public int AlbumId { get; set; }
        public AlbumDTO? Albuns { get; set; }

        // Fk (De lá pra cá);
        public int MusicaId { get; set; }
        public MusicaDTO? Musicas { get; set; }

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
