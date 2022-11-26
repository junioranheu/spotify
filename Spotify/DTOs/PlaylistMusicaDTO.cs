using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.DTOs
{
    public class PlaylistMusicaDTO
    {
        [Key]
        public int PlaylistMusicaId { get; set; }

        // Fk (De lá pra cá);
        public int PlaylistId { get; set; }
        public PlaylistDTO? Playlists { get; set; }

        // Fk (De lá pra cá);
        public int MusicaId { get; set; }
        public MusicaDTO? Musicas { get; set; }

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
