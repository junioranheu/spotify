using Microsoft.AspNetCore.Mvc;
using Spotify.API.DTOs;
using Spotify.API.Interfaces;

namespace Spotify.API.Controllers
{
    public class AutenticarController : BaseController<AutenticarController>
    {
        private readonly IAutenticarService _autenticarService;

        public AutenticarController(IAutenticarService autenticarService)
        {
            _autenticarService = autenticarService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDTO>> Login(UsuarioSenhaDTO dto)
        {
            var authResultado = await _autenticarService.Login(dto);
            return Ok(authResultado);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioDTO>> Registrar(UsuarioSenhaDTO dto)
        {
            var authResultado = await _autenticarService.Registrar(dto);
            return Ok(authResultado);
        }

        [HttpPost("refreshToken")]
        public async Task<ActionResult<UsuarioDTO>> RefreshToken(UsuarioSenhaDTO dto)
        {
            var authResultado = await _autenticarService.RefreshToken(dto.Token, dto.RefreshToken);
            return Ok(authResultado);
        }
    }
}
