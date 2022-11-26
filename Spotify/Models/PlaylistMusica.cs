using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Models
{
    public class PlaylistMusica
    {
        [Key]
        public int PlaylistMusicaId { get; set; }

        // Fk (De lá pra cá);
        public int PlaylistId { get; set; }
        public Playlist? Playlists { get; set; }

        // Fk (De lá pra cá);
        public int MusicaId { get; set; }
        public Musica? Musicas { get; set; }

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
