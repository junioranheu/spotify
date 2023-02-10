using Spotify.API.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Spotify.API.DTOs
{
    public class LogDTO
    {
        [Key]
        public int LogId { get; set; }
        public string? TipoRequisicao { get; set; } = null;
        public string? Endpoint { get; set; } = null;
        public string? Query { get; set; } = null;
        public int? StatusResposta { get; set; } = 0;

        // Fk (De lá pra cá);
        public int? UsuarioId { get; set; } = 0;
        [JsonIgnore]
        public Usuario? Usuarios { get; set; }
    }
}
