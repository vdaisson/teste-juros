using CalculaJuros.Domain.Interfaces;
using CalculaJuros.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;

namespace CalculaJuros.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService _service;
        private readonly ICalculaJurosConfiguration _config;

        public CalculaJurosController(ICalculaJurosService service, ICalculaJurosConfiguration config)
        {
            _service = service;
            _config = config;
        }

        /// <summary>
        /// Realiza o cálculo de juros compostos
        /// </summary>
        /// <param name="valorInicial"></param>
        /// <param name="meses"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<string> Get(double valorInicial, int meses)
        {
            var result = await _service.CalculaAsync(valorInicial, meses);
            return result.ToString("F2", CultureInfo.GetCultureInfo(_config.Culture).NumberFormat);
        }
    }
}
