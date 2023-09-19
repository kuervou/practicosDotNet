using BusinessLayer.IBLs;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace WebAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly IBL_Vehiculos _bl;

        public VehiculosController(IBL_Vehiculos bl)
        {
            _bl = bl;
        }

        // GET: api/<VehiculosController>
        [ProducesResponseType(typeof(List<Vehiculo>), 200)]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bl.GetAllVehiculos());
        }

        // GET api/<VehiculosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var vehiculo = _bl.GetVehiculoById(id);
            if (vehiculo == null)
                return NotFound();

            return Ok(vehiculo);
        }

        // POST api/<VehiculosController>
        [HttpPost]
        public IActionResult Post([FromBody] Vehiculo vehiculo)
        {
            if (vehiculo == null)
                return BadRequest("El vehículo no puede ser nulo.");

            _bl.AddVehiculo(vehiculo);
            return CreatedAtAction(nameof(Get), new { id = vehiculo.Id }, vehiculo);
        }

        // PUT api/<VehiculosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Vehiculo vehiculo)
        {
            if (vehiculo == null || vehiculo.Id != id)
                return BadRequest();

            var existingVehiculo = _bl.GetVehiculoById(id);
            if (existingVehiculo == null)
                return NotFound();

            _bl.UpdateVehiculo(vehiculo);
            return NoContent();
        }

        // DELETE api/<VehiculosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var vehiculo = _bl.GetVehiculoById(id);
            if (vehiculo == null)
                return NotFound();

            _bl.DeleteVehiculo(id);
            return NoContent();
        }
    }
}
