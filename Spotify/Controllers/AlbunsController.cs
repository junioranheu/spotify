using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spotify.Interfaces;
using Spotify.Models;

namespace Spotify.Controllers
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

        [HttpGet("todos")]
        public async Task<ActionResult<List<Album>>> GetTodos()
        {
            var todos = await _albumRepository.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetPorId(int id)
        {
            var porId = await _albumRepository.GetPorId(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }

        [HttpPost("criar")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<bool>> PostCriar(Album album)
        {
            var isOk = await _albumRepository.PostCriar(album);

            if (isOk < 1)
            {
                return NotFound();
            }

            return Ok(true);
        }

        [HttpPost("atualizar")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<bool>> PostAtualizar(Album album)
        {
            var isOk = await _albumRepository.PostAtualizar(album);

            if (isOk < 1)
            {
                return NotFound();
            }

            return Ok(true);
        }

        [HttpPost("deletar")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<int>> PostDeletar(int id)
        {
            var isOk = await _albumRepository.PostDeletar(id);

            if (isOk < 1)
            {
                return NotFound();
            }

            return Ok(true);
        }
    }
}
