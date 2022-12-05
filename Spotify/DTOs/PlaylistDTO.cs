using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.DTOs
{
    public class PlaylistDTO : _RetornoApiDTO
    {
        [Key]
        public int PlaylistId { get; set; }
        public string? Nome { get; set; } = null;
        public string? Sobre { get; set; } = null;
        public string? Foto { get; set; } = null;
        public string? CorDominante { get; set; } = null;

        // Fk (De lá pra cá);
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public UsuarioDTO? Usuarios { get; set; }

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();

        // Fk (De cá pra lá);
        [JsonIgnore]
        public List<PlaylistMusicaDTO>? PlaylistsMusicas { get; set; }
    }
}
