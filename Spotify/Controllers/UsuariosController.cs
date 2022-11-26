using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Spotify.API.DTOs;
using Spotify.API.Enums;
using Spotify.API.Interfaces;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : BaseController<UsuariosController>
    {
        private readonly IUsuarioRepository _usuarios;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarios = usuarioRepository;
        }

        [HttpPut("atualizar")]
        [Authorize]
        public async Task<ActionResult<UsuarioDTO>> Atualizar(UsuarioSenhaDTO dto)
        {
            var isMesmoUsuario = await IsUsuarioSolicitadoMesmoDoToken(dto.UsuarioId);

            if (!isMesmoUsuario)
            {
                UsuarioDTO erro = new()
                {
                    Erro = true,
                    CodigoErro = (int)CodigosErrosEnum.NaoAutorizado,
                    MensagemErro = GetDescricaoEnum(CodigosErrosEnum.NaoAutorizado)
                };

                return erro;
            }

            var usuario = await _usuarios.Atualizar(dto);
            return Ok(usuario);
        }

        [HttpGet("todos")]
        public async Task<ActionResult<List<UsuarioDTO>>> GetTodos()
        {
            var itens = await _usuarios.GetTodos();

            if (itens == null)
            {
                return NotFound();
            }

            return itens;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetById(int id)
        {
            var byId = await _usuarios.GetById(id);

            if (byId == null)
            {
                return NotFound();
            }

            return byId;
        }
    }
}
