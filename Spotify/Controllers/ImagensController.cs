using Microsoft.AspNetCore.Mvc;

namespace Spotify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagensController : BaseController<ImagensController>
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImagensController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("getBase64PorCaminhoId")]
        public string GetBase64PorCaminhoId(string caminho)
        {
            // Parâmetro "caminho" = "capas/22.webp";
            string contentRootPath = _hostingEnvironment.ContentRootPath; // Vai até a raiz;
            string caminhoDestino = contentRootPath + "Upload/" + caminho; // Caminho de destino;

            if (!System.IO.File.Exists(caminhoDestino))
            {
                return string.Empty;
            }

            byte[] imageArray = System.IO.File.ReadAllBytes(caminhoDestino);
            string base64 = "data:image/gif;base64," + Convert.ToBase64String(imageArray);

            return base64;
        }
    }
}