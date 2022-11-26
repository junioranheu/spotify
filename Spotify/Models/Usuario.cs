using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string? NomeCompleto { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? NomeUsuarioSistema { get; set; } = null;
        public string? Senha { get; set; } = null;

        // Fk (De lá pra cá);
        public int UsuarioTipoId { get; set; }
        public UsuarioTipo? UsuariosTipos { get; set; }

        public string? Foto { get; set; } = null;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
        public DateTime DataOnline { get; set; }
        public bool IsAtivo { get; set; } = true;
        public bool IsPremium { get; set; } = false;
        public bool IsVerificado { get; set; } = false;

        // Fk (De cá pra lá);
        public List<Playlist>? Playlists { get; set; }
    }
}
