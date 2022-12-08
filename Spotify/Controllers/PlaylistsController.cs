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
        [CustomAuthorize(UsuarioTipoEnum.Administrador, UsuarioTipoEnum.Usuario)]
        public async Task<ActionResult<bool>> Adicionar(PlaylistDTO dto)
        {
            dto.UsuarioId = Convert.ToInt32(User?.FindFirstValue(ClaimTypes.NameIdentifier));
            var newPlaylist = await _playlistRepository.Adicionar(dto);

            // Atualizar físicamente o arquivo;
            if (!String.IsNullOrEmpty(dto.Foto))
            {
                var file = Base64ToFile(dto.Foto);
                await UparArquivo(file, newPlaylist.Foto, GetDescricaoEnum(CaminhosUploadEnum.UploadPlaylists), newPlaylist.Foto, _webHostEnvironment);
            }

            return Ok(true);
        }

        [HttpPut("atualizar")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<bool>> Atualizar(PlaylistDTO dto)
        {
            await _playlistRepository.Atualizar(dto);
            return Ok(true);
        }

        [HttpDelete("deletar/{id}")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
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
