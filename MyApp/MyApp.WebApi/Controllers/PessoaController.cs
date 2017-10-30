using Microsoft.AspNetCore.Mvc;
using MyApp.Domain;
using MyApp.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.WebApi.Controllers
{
    [Route("api/pessoas")]
    public class PessoaController : ControllerBase
    {
        private readonly MyAppContext _contex;
        public PessoaController(MyAppContext contex)
        {
            _contex = contex;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_contex.Pessoas.FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pessoa entity)
        {
            _contex.Pessoas.Add(entity);
            _contex.SaveChanges();
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }
    }
}
