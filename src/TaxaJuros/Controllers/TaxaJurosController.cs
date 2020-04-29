using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TaxaJuros.Domain.Interfaces.Configurations;
using TaxaJuros.Domain.Service.Interfaces;

namespace TaxaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosService _service;
        private readonly ITaxaJurosConfiguration _config;

        public TaxaJurosController(ITaxaJurosService service, ITaxaJurosConfiguration config)
        {
            _service = service;
            _config = config;
        }

        /// <summary>
        /// Busca a taxa de juros a ser usada nos cálculos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public string Get()
        {
            return _service.Get().ToString("F2", CultureInfo.GetCultureInfo(_config.Culture).NumberFormat);
        }
    }
}
