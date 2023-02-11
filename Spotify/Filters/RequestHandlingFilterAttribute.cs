using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Spotify.API.DTOs;
using Spotify.API.Interfaces;
using System.Security.Claims;

namespace Spotify.API.Filters
{
    public class RequestHandlingFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogRepository _logRepository;

        public RequestHandlingFilterAttribute(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContextExecuting, ActionExecutionDelegate next)
        {
            ActionExecutedContext filterContextExecuted = await next();
            HttpRequest request = filterContextExecuted.HttpContext.Request;
            HttpResponse response = filterContextExecuted.HttpContext.Response;

            LogDTO dto = new()
            {
                TipoRequisicao = request.Method ?? "",
                Endpoint = request.Path.Value ?? "",
                QueryString = request.QueryString.ToString() ?? "",
                Parametros = GetParametrosRequisicao(filterContextExecuting),
                StatusResposta = response.StatusCode > 0 ? response.StatusCode : 0,
                UsuarioNome = GetUsuarioNome(filterContextExecuted),
                UsuarioId = GetUsuarioId(filterContextExecuted)
            };

            await _logRepository.Adicionar(dto);
        }

        private static string GetParametrosRequisicao(ActionExecutingContext filterContextExecuting)
        {
            var parametros = filterContextExecuting.ActionArguments.FirstOrDefault().Value ?? null;
            return JsonConvert.SerializeObject(parametros) ?? string.Empty;
        }

        private static string GetUsuarioNome(ActionExecutedContext filterContextExecuted)
        {
            if (filterContextExecuted.HttpContext.User.Identity.IsAuthenticated)
            {
                return filterContextExecuted.HttpContext.User?.FindFirstValue(ClaimTypes.Name) ?? "";
            }

            return string.Empty;
        }

        private static int GetUsuarioId(ActionExecutedContext filterContextExecuted)
        {
            if (filterContextExecuted.HttpContext.User.Identity.IsAuthenticated)
            {
                return Convert.ToInt32(filterContextExecuted.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            return 0;
        }
    }
}
