using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Spotify.Models
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }
        public string? Nome { get; set; }
        public string? Sobre { get; set; }
        public string? Foto { get; set; }

        // Fk (De lá pra cá);
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuarios { get; set; }

        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }

        // Fk (De cá pra lá);
        [JsonIgnore]
        public ICollection<PlaylistMusica> PlaylistsMusicas { get; set; }
    }
}
