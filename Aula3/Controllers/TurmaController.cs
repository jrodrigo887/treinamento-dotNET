using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : Controller
    {

        [HttpGet]
        [Route("get")]
        public IActionResult Index()
        {
            return Ok("Olá gente");
        }
    }
}
