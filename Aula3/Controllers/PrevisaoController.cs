using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula3.Services;
using Aula3.Interfaces;
using Aula3.models;

namespace Aula3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrevisaoController : Controller
    {
        private readonly PrevisaoService _previsaoService;

        public PrevisaoController(PrevisaoService ps) 
        {
            _previsaoService = ps;
        }
     
        private DateTime Today { set; get; }

        [HttpGet]
        [Route("India")]
        public ActionResult<string> Index()
        {
            Today = DateTime.Now;

            var obj = _previsaoService.GetCurrentTimeNow();

            return BadRequest(obj);
        }

        [HttpGet]
        [Route("tempo-local")]
        public async Task<WeatherForecastDetail> GetCurrentNow()
        {
            return await _previsaoService.GetMyTimeAsync();
        }

        [HttpGet]
        [Route("{City}/{State}")]
        public async Task<WeatherForecastDetail> GetTimeCity(string City, string State)
        {
            return await _previsaoService.GetTimeMyCityAsync(City, State);
        }
    }
}
