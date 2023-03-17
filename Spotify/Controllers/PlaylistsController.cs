using Microsoft.AspNetCore.Mvc;
using Spotify.API.DTOs;
using Spotify.API.Enums;
using Spotify.API.Filters;
using Spotify.API.Interfaces;
using System.Security.Claims;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : BaseController<PlaylistsController>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistsController(IWebHostEnvironment webHostEnvironment, IPlaylistRepository playlistRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _playlistRepository = playlistRepository;
        }

        [HttpPost("adicionar")]
        [AuthorizeFilter(UsuarioTipoEnum.Administrador, UsuarioTipoEnum.Usuario)]
        public async Task<ActionResult<PlaylistDTO>> Adicionar(PlaylistDTO dto)
        {
            string fotoBase64 = dto.Foto;
            dto.UsuarioId = Convert.ToInt32(User?.FindFirstValue(ClaimTypes.NameIdentifier));
            var newPlaylist = await _playlistRepository.Adicionar(dto);

            // Atualizar físicamente o arquivo;
            if (!String.IsNullOrEmpty(fotoBase64))
            {
                var file = Base64ToFile(fotoBase64);
                await UparArquivo(file, newPlaylist.Foto, GetDescricaoEnum(CaminhosUploadEnum.UploadPlaylists), string.Empty, _webHostEnvironment);
            }

            return Ok(newPlaylist);
        }

        [HttpPut("atualizar")]
        [AuthorizeFilter(UsuarioTipoEnum.Administrador, UsuarioTipoEnum.Usuario)]
        public async Task<ActionResult<PlaylistDTO>> Atualizar(PlaylistDTO dto)
        {
            string fotoBase64 = dto.Foto;
            dto.UsuarioId = Convert.ToInt32(User?.FindFirstValue(ClaimTypes.NameIdentifier));
            var updatePlaylist = await _playlistRepository.Atualizar(dto);

            // Atualizar físicamente o arquivo;
            if (!String.IsNullOrEmpty(fotoBase64))
            {
                var file = Base64ToFile(fotoBase64);
                await UparArquivo(file, updatePlaylist.Foto, GetDescricaoEnum(CaminhosUploadEnum.UploadPlaylists), updatePlaylist.FotoAnterior, _webHostEnvironment);
            }

            return Ok(updatePlaylist);
        }

        [HttpDelete("deletar/{id}")]
        [AuthorizeFilter(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<int>> Deletar(int id)
        {
            await _playlistRepository.Deletar(id);
            return Ok(true);
        }

        [HttpGet("todos")]
        public async Task<ActionResult<List<PlaylistDTO>>> GetTodos()
        {
            var todos = await _playlistRepository.GetTodos();
            return Ok(todos);
        }

        [HttpGet("todosNaoAdm")]
        public async Task<ActionResult<List<PlaylistDTO>>> GetTodosNaoAdm()
        {
            var todos = await _playlistRepository.GetTodosNaoAdm();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistDTO>> GetById(int id)
        {
            var porId = await _playlistRepository.GetById(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }

        [HttpGet("byUsuarioId/{id}")]
        public async Task<ActionResult<List<PlaylistDTO>>> GetByUsuarioId(int id)
        {
            var porId = await _playlistRepository.GetByUsuarioId(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }
    }
}
