using CalculaJuros.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculaJuros.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly ICalculaJurosConfiguration _config;

        public ShowMeTheCodeController(ICalculaJurosConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Busca a url do código do teste no GitHub
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public string Get()
        {
            return _config.ShowMeTheCodeUrl;
        }
    }
}