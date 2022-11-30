using Microsoft.AspNetCore.Mvc;
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

            if (String.IsNullOrEmpty(caminho) || !System.IO.File.Exists(caminho))
            {
                return NotFound();
            }

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

        // Como "streamar" e disponibilizar um arquivo para download - https://stackoverflow.com/a/56875627;
        [HttpGet("getArquivoProtegidoStream/nomePasta={nomePasta}&nomeArquivo={nomeArquivo}")]
        public async Task<ActionResult> GetArquivoProtegidoStream(string nomePasta, string nomeArquivo)
        {
            string wwwPath = _webHostEnvironment.WebRootPath ?? _webHostEnvironment.ContentRootPath;
            string caminho = $"{wwwPath}/UploadProtegido/{nomePasta}/{nomeArquivo}";

            if (String.IsNullOrEmpty(caminho) || !System.IO.File.Exists(caminho))
            {
                return NotFound();
            }

            Byte[] bytes = await System.IO.File.ReadAllBytesAsync(caminho);

            if (bytes.Length == 0)
            {
                return Problem();
            }

            var conteudo = new FileContentResult(bytes, contentType: "application/octet-stream")
            {
                EnableRangeProcessing = false,
                FileDownloadName = nomeArquivo
            };

            return conteudo;
        }

        // Como "streamar" um arquivo - https://stackoverflow.com/a/59209398;
        [HttpGet("getArquivoProtegidoStreamBuffer/nomePasta={nomePasta}&nomeArquivo={nomeArquivo}")]
        public IActionResult getArquivoProtegidoStreamBuffer(string nomePasta, string nomeArquivo)
        {
            string wwwPath = _webHostEnvironment.WebRootPath ?? _webHostEnvironment.ContentRootPath;
            string caminho = $"{wwwPath}/UploadProtegido/{nomePasta}/{nomeArquivo}";

            if (String.IsNullOrEmpty(caminho) || !System.IO.File.Exists(caminho))
            {
                return NotFound();
            }

            var bufferSize = 1024;
            var fileStream = new FileStream(caminho, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize);

            return File(fileStream, "audio/mpeg", enableRangeProcessing: true);
        }

        // https://stackoverflow.com/questions/66505799/streaming-a-video-in-chunks-to-the-client (Só funciona no monolítico);
    }
}
