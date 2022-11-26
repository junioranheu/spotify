using Microsoft.AspNetCore.Mvc;
using Spotify.API.DTOs;
using Spotify.API.Enums;
using Spotify.API.Filters;
using Spotify.API.Interfaces;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbunsController : BaseController<AlbunsController>
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbunsController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        [HttpPost("adicionar")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<bool>> Adicionar(AlbumDTO dto)
        {
            await _albumRepository.Adicionar(dto);
            return Ok(true);
        }

        [HttpPut("atualizar")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<bool>> Atualizar(AlbumDTO dto)
        {
            await _albumRepository.Atualizar(dto);
            return Ok(true);
        }

        [HttpDelete("deletar/{id}")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<int>> Deletar(int id)
        {
            await _albumRepository.Deletar(id);
            return Ok(true);
        }

        [HttpGet("todos")]
        public async Task<ActionResult<List<AlbumDTO>>> GetTodos()
        {
            var todos = await _albumRepository.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumDTO>> GetById(int id)
        {
            var porId = await _albumRepository.GetById(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }
    }
}
