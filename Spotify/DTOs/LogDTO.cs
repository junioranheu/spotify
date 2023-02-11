using System.ComponentModel.DataAnnotations;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.DTOs
{
    public class LogDTO
    {
        [Key]
        public int LogId { get; set; }
        public string? TipoRequisicao { get; set; } = null;
        public string? Endpoint { get; set; } = null;
        public string? QueryString { get; set; } = null;
        public string? Parametros { get; set; } = null;
        public int? StatusResposta { get; set; } = 0;

        public string? UsuarioNome { get; set; } = null;
        public int? UsuarioId { get; set; } = 0;

        public bool IsAtivo { get; set; } = true;
        public DateTime DataRegistro { get; set; } = HorarioBrasilia();
    }
}
