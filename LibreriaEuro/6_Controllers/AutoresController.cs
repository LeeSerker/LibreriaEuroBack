using Microsoft.AspNetCore.Mvc;
using LibreriaEuro.Interfaces;
using LibreriaEuro.DTO;

namespace LibreriaEuro.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutoresController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        //GET: api/Autores
        [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> ObtenerTodosAutores()
        {
            var autores = await _autorService.ObtenerTodosAutores();
            return Ok(autores);
        }

        //POST api/Autores
        [HttpPost]
        public async Task<ActionResult> CrearAutor( AutorDTO autorDTO)
        {
            if (autorDTO == null)
                return BadRequest();

            await _autorService.CrearAutor(autorDTO);
            return CreatedAtAction(nameof(CrearAutor), new { autorDTO.Rut }, autorDTO);
        }

        //PUT api/Autores/x
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarAutor(int id, [FromBody] AutorDTO autor)
        {
            var actualizado = await _autorService.ActualizarAutor(id, autor);
            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        //DELETE api/Libros/x
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarLibro(int id)
        {
            var eliminado = await _autorService.EliminarAutor(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}