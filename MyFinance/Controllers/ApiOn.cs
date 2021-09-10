using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiOn : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Sim";
        }
    }
}
