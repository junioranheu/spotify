﻿using Microsoft.AspNetCore.Mvc;
using static Spotify.Utils.Biblioteca;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadProtegidoController : BaseController<UploadProtegidoController>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadProtegidoController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getArquivoProtegidoBase64/nomePasta={nomePasta}&nomeArquivo={nomeArquivo}")]
        public async Task<ActionResult<Tuple<string, string>>> GetArquivoProtegidoBase64(string nomePasta, string nomeArquivo)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string wwwPath = _webHostEnvironment.WebRootPath ?? _webHostEnvironment.ContentRootPath;
            string caminho = $"{wwwPath}/UploadProtegido/{nomePasta}/{nomeArquivo}";

            if (!String.IsNullOrEmpty(caminho))
            {
                if (System.IO.File.Exists(caminho))
                {
                    Byte[] bytes = await System.IO.File.ReadAllBytesAsync(caminho);
                    string arquivoBase64 = Convert.ToBase64String(bytes);
                    string extensaoArquivo = GetMimeType(caminho);

                    if (String.IsNullOrEmpty(arquivoBase64) || String.IsNullOrEmpty(extensaoArquivo))
                    {
                        return Problem();
                    }

                    // Gerar o base64 final;
                    string arquivoBase64Final = $"data:{extensaoArquivo};base64,{arquivoBase64}";

                    // Parar o Stopwatch;
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;

                    return new Tuple<string, string>(arquivoBase64Final, elapsedMs.ToString());
                }
                else
                {
                    return NotFound();
                }
            }

            return NotFound();
        }

        // Como "stremar" um arquivo - https://stackoverflow.com/a/56875627;
        [HttpGet("getArquivoProtegidoStream/nomePasta={nomePasta}&nomeArquivo={nomeArquivo}")]
        public async Task<ActionResult> GetArquivoProtegidoStream(string nomePasta, string nomeArquivo)
        {
            string wwwPath = _webHostEnvironment.WebRootPath ?? _webHostEnvironment.ContentRootPath;
            string caminho = $"{wwwPath}/UploadProtegido/{nomePasta}/{nomeArquivo}";

            if (!String.IsNullOrEmpty(caminho))
            {
                if (System.IO.File.Exists(caminho))
                {
                    Byte[] bytes = await System.IO.File.ReadAllBytesAsync(caminho);

                    if (bytes.Length == 0)
                    {
                        return Problem();
                    }

                    return new FileContentResult(bytes, "application/octet-stream");
                }
                else
                {
                    return NotFound();
                }
            }

            return NotFound();
        }
    }
}
