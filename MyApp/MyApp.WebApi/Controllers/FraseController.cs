using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyApp.WebApi.Controllers
{
    [Route("api/frases")]
    public class FraseController : ControllerBase
    {
        // [HttpGet("{id}")]
        // [HttpGet("{id?}")]
        // [HttpGet("{id=9999}")]
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(new Frase() { Id = id, Texto = $"Frase {id}" });
        }

        [HttpGet]
        [Route("listar")]
        // [Produces("application/json")]
        public IActionResult Get()
        {
            var frases = new List<Frase>();
            frases.Add(new Frase() { Id = 1, Texto = "Olá mundo!" });
            frases.Add(new Frase() { Id = 2, Texto = "Hello World!" });
            return Ok(frases);
        }

        [HttpGet]
        [Route("filtro")]        
        public IActionResult Get([FromQuery] string param1, string param2)
        {
            return Ok(new { param1, param2 });
        }

        // [HttpPost, HttpPut]
        [AcceptVerbs("POST", "PUT")]
        public IActionResult PostAndPut([FromBody]Frase model)
        {
            return Ok(model);
        }

        [HttpPut]
        [Route("{id}/{cidade}")]
        public IActionResult Delete([FromRoute] int id, string cidade, [FromBody] Frase model)
        {
            return Ok(new { id, cidade, model });
        }

        [HttpPost]
        [Route("criar")]
        public IActionResult PostComValidacao([FromBody] Frase model)
        {
            if (ModelState.IsValid)
                return CreatedAtAction("GetById", new { id = model.Id }, model);
            else
                return BadRequest(ModelState);
        }
    }

    public class Frase
    {
        public int Id { get; set; }

        [MinLength(10)]
        public string Texto { get; set; }
    }
}
