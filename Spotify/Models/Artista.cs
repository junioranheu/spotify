using System.ComponentModel.DataAnnotations;

namespace Spotify.Models
{
    public class Artista
    {
        [Key]
        public int ArtistaId { get; set; }
        public string? Nome { get; set; }
        public int IsAtivo { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
