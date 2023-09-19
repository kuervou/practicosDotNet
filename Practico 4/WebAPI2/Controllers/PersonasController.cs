using BusinessLayer.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IBL_Personas _BL;

        public PersonasController(IBL_Personas bl)
        {
            _BL = bl;
        }

        // GET: api/<PersonasController>
        [ProducesResponseType(typeof(List<Persona>), 200)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_BL.Get());
        }

        // GET api/<PersonasController>/documento123
        [HttpGet("{documento}")]
        public IActionResult Get(string documento)
        {
            var persona = _BL.Get(documento);
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post([FromBody] Persona persona)
        {
            if (persona == null)
            {
                return BadRequest();
            }

            try
            {
                _BL.Insert(persona);
                return CreatedAtAction(nameof(Get), new { documento = persona.Documento }, persona);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<PersonasController>/documento123
        [HttpPut("{documento}")]
        public IActionResult Put(string documento, [FromBody] Persona persona)
        {
            if (persona == null || persona.Documento != documento)
            {
                return BadRequest();
            }

            var existingPersona = _BL.Get(documento);
            if (existingPersona == null)
            {
                return NotFound();
            }

            try
            {
                _BL.Update(persona);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<PersonasController>/documento123
        [HttpDelete("{documento}")]
        public IActionResult Delete(string documento)
        {
            var persona = _BL.Get(documento);
            if (persona == null)
            {
                return NotFound();
            }

            _BL.Delete(documento);
            return Ok();
        }
    }

}
