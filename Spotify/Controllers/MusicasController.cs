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
    public class MusicasController : BaseController<MusicasController>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMusicaRepository _musicaRepository;

        public MusicasController(IWebHostEnvironment webHostEnvironment, IMusicaRepository musicaRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _musicaRepository = musicaRepository;
        }

        [HttpPost("adicionar")]
        [AuthorizeFilter(UsuarioTipoEnum.Administrador, UsuarioTipoEnum.Usuario)]
        public async Task<ActionResult<MusicaDTO>> Adicionar(MusicaAdicionarDTO dto)
        {
            dto.UsuarioId = Convert.ToInt32(User?.FindFirstValue(ClaimTypes.NameIdentifier));
            var newMusica = await _musicaRepository.Adicionar(dto);

            // Verificar se o usuário inseriu a música via arquivo ou URL do youtube;
            Tuple<bool, string>? resultadoUpload = null;
            if (!String.IsNullOrEmpty(dto.Mp3Base64))
            {
                var file = Base64ToFile(dto.Mp3Base64);
                resultadoUpload = await UparArquivo(file, $"{newMusica.MusicaId}.mp3", GetDescricaoEnum(CaminhosUploadEnum.UploadProtegidoMusica), $"{newMusica.MusicaId}.mp3", _webHostEnvironment);

                if (!resultadoUpload.Item1)
                {
                    newMusica.Erro = true;
                    newMusica.CodigoErro = (int)CodigosErrosEnum.ErroInternoUploadArquivo;
                    newMusica.MensagemErro = GetDescricaoEnum(CodigosErrosEnum.ErroInternoUploadArquivo);
                }
            }
            else if (!String.IsNullOrEmpty(dto.UrlYoutube))
            {
                resultadoUpload = await YoutubeToMp3(GetDescricaoEnum(CaminhosUploadEnum.UploadProtegidoMusica), dto.UrlYoutube, newMusica?.MusicaId.ToString());

                if (!resultadoUpload.Item1)
                {
                    newMusica.Erro = true;
                    newMusica.CodigoErro = (int)CodigosErrosEnum.ErroInternoConversaoYoutube;
                    newMusica.MensagemErro = GetDescricaoEnum(CodigosErrosEnum.ErroInternoConversaoYoutube);
                }
            }

            // Verificar o tamanho (quantidade de segundos) o áudio tem;
            if (!String.IsNullOrEmpty(resultadoUpload?.Item2))
            {
                await _musicaRepository.AtualizarDuracaoMusica(newMusica.MusicaId, resultadoUpload.Item2);
            }
          
            return Ok(newMusica);
        }

        [HttpPut("atualizar")]
        [AuthorizeFilter(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<bool>> Atualizar(MusicaDTO dto)
        {
            await _musicaRepository.Atualizar(dto);
            return Ok(true);
        }

        [HttpDelete("deletar/{id}")]
        [AuthorizeFilter(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<int>> Deletar(int id)
        {
            await _musicaRepository.Deletar(id);
            return Ok(true);
        }

        [HttpGet("todos")]
        public async Task<ActionResult<List<MusicaDTO>>> GetTodos()
        {
            var todos = await _musicaRepository.GetTodos();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicaDTO>> GetById(int id)
        {
            var porId = await _musicaRepository.GetById(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }

        [HttpGet("byPlaylistId/{id}")]
        public async Task<ActionResult<MusicaDTO>> GetByPlaylistId(int id)
        {
            var porId = await _musicaRepository.GetByPlaylistId(id);

            if (porId == null)
            {
                return NotFound();
            }

            return Ok(porId);
        }

        [HttpPost("incrementarOuvinte")]
        public async Task<ActionResult<bool>> PostIncrementarOuvinte(int id)
        {
            var isOk = await _musicaRepository.PostIncrementarOuvinte(id);

            if (isOk < 1)
            {
                return NotFound();
            }

            return Ok(true);
        }

        [HttpGet("byPalavraChave/{palavraChave}")]
        public async Task<ActionResult<List<MusicaDTO>>> GetByPalavraChave(string palavraChave)
        {
            var porPalavra = await _musicaRepository.GetByPalavraChave(palavraChave);

            if (porPalavra == null)
            {
                return NotFound();
            }

            return Ok(porPalavra);
        }

        [HttpPost("adicionarMusicaEmPlaylists")]
        [AuthorizeFilter(UsuarioTipoEnum.Administrador, UsuarioTipoEnum.Usuario)]
        public async Task<ActionResult<bool>> AdicionarMusicaEmPlaylists(MusicaAdicionarDTO dto)
        {
            dto.UsuarioId = Convert.ToInt32(User?.FindFirstValue(ClaimTypes.NameIdentifier));
            var isOk = await _musicaRepository.AdicionarMusicaEmPlaylists(dto);

            return Ok(isOk);
        }
    }
}