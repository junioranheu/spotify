using AutoMapper;
using Spotify.API.DTOs;
using Spotify.API.Models;

namespace Spotify.API.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // Outros; 
            CreateMap<RefreshToken, RefreshTokenDTO>().ReverseMap();
            CreateMap<Log, LogDTO>().ReverseMap();

            // Usuário e afins;
            CreateMap<UsuarioTipo, UsuarioTipoDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioSenhaDTO>().ReverseMap();
            CreateMap<UsuarioSenhaDTO, UsuarioDTO>().ReverseMap();

            // Outros (Artista, Banda, Musica);
            CreateMap<Artista, ArtistaDTO>().ReverseMap();
            CreateMap<BandaArtista, BandaArtistaDTO>().ReverseMap();
            CreateMap<Banda, BandaDTO>().ReverseMap();
            CreateMap<MusicaBanda, MusicaBandaDTO>().ReverseMap();
            CreateMap<Musica, MusicaDTO>().ReverseMap();
            CreateMap<Musica, MusicaAdicionarDTO>().ReverseMap();

            // Albuns e afins;
            CreateMap<Album, AlbumDTO>().ReverseMap();
            CreateMap<AlbumMusica, AlbumMusicaDTO>().ReverseMap();

            // Playlists;
            CreateMap<Playlist, PlaylistDTO>().ReverseMap();
            CreateMap<PlaylistMusica, PlaylistMusicaDTO>().ReverseMap();
        }
    }
}
