﻿using Microsoft.AspNetCore.Mvc;
using Spotify.API.DTOs;
using Spotify.API.Enums;
using Spotify.API.Filters;
using Spotify.API.Interfaces;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Controllers
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

        [HttpPost("adicionar")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador, UsuarioTipoEnum.Usuario)]
        public async Task<ActionResult<bool>> Adicionar(MusicaAdicionarDTO dto)
        {
            var newMusicaId = await _musicaRepository.Adicionar(dto);

            // Verificar se o usuário inseriu a música via arquivo ou URL do youtube;
            if (!String.IsNullOrEmpty(dto.Mp3Base64))
            {
                var file = Base64ToFile(dto.Mp3Base64);
            }
            else if (!String.IsNullOrEmpty(dto.UrlYoutube))
            {
                bool teste = await YoutubeToMp3(GetDescricaoEnum(CaminhosUploadEnum.UploadProtegidoMusica), dto.UrlYoutube, newMusicaId.ToString());
            }

            return Ok(true);
        }

        [HttpPut("atualizar")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
        public async Task<ActionResult<bool>> Atualizar(MusicaDTO dto)
        {
            await _musicaRepository.Atualizar(dto);
            return Ok(true);
        }

        [HttpDelete("deletar/{id}")]
        [CustomAuthorize(UsuarioTipoEnum.Administrador)]
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

        [HttpGet("porPlaylist/{id}")]
        public async Task<ActionResult<MusicaDTO>> GetPorPlaylist(int id)
        {
            var porId = await _musicaRepository.GetPorPlaylist(id);

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

        [HttpGet("porPalavraChave/{palavraChave}")]
        public async Task<ActionResult<List<MusicaDTO>>> GetPorPalavraChave(string palavraChave)
        {
            var porPalavra = await _musicaRepository.GetPorPalavraChave(palavraChave);

            if (porPalavra == null)
            {
                return NotFound();
            }

            return Ok(porPalavra);
        }
    }
}