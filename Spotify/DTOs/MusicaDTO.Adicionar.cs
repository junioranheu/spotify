namespace Spotify.API.DTOs
{
    public class MusicaAdicionarDTO : MusicaDTO
    {
        public string? Mp3Base64 { get; set; } = null;
        public string? UrlYoutube { get; set; } = null;
    }
}
