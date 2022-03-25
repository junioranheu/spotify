using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spotify.Interfaces;
using Spotify.Models;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicasController : BaseController<MusicasController>
    {
        private readonly IMusicaRepository _musicaRepository;

        public MusicasController(IMusicaRepository musicaRepository)
        {
            _musicaRepository = musicaRepository;
        }

        [HttpGet("todos")]
        public async Task<ActionResult<List<Musica>>> GetTodos()
        {
            var todos = await _musicaRepository.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Musica>> GetPorId(int id)
        {
            var porId = await _musicaRepository.GetPorId(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }

        [HttpPost("criar")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<bool>> PostCriar(Musica musicaRepository)
        {
            var isOk = await _musicaRepository.PostCriar(musicaRepository);

            if (isOk < 1)
            {
                return NotFound();
            }

            return Ok(true);
        }

        [HttpPost("atualizar")]
        [Authorize(Roles = "1")]
        public async Task<ActionResult<bool>> PostAtualizar(Musica musicaRepository)
        {
            var isOk = await _musicaRepository.PostAtualizar(musicaRepository);

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
            var isOk = await _musicaRepository.PostDeletar(id);

            if (isOk < 1)
            {
                return NotFound();
            }

            return Ok(true);
        }
    }
}