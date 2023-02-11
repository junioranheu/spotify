using Microsoft.AspNetCore.Mvc.Filters;
using Spotify.API.DTOs;
using Spotify.API.Interfaces;
using System.Security.Claims;

namespace Spotify.API.Filters
{
    public class SuccessHandlingFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogRepository _logRepository;

        public SuccessHandlingFilterAttribute(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            try
            {
                var actionExecutedContext = await next();
                var request = filterContext.HttpContext.Request;
                var response = filterContext.HttpContext.Response;

                LogDTO dto = new()
                {
                    TipoRequisicao = request.Method ?? "",
                    Endpoint = request.Path.Value ?? "",
                    Query = request.QueryString.ToString() ?? "",
                    StatusResposta = response.StatusCode > 0 ? response.StatusCode : 0,
                    UsuarioNome = GetUsuarioNome(actionExecutedContext),
                    UsuarioId = GetUsuarioId(actionExecutedContext)
                };

                await _logRepository.Adicionar(dto);
            }
            catch (Exception ex)
            {

            }
        }

        private static string GetUsuarioNome(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return filterContext.HttpContext.User?.FindFirstValue(ClaimTypes.Name) ?? "";
            }

            return "";
        }

        private static int GetUsuarioId(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                return Convert.ToInt32(filterContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier));
            }

            return 0;
        }
    }
}
