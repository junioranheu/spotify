using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
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

        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
