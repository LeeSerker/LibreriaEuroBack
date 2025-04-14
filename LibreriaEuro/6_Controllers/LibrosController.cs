using Microsoft.AspNetCore.Mvc;
using LibreriaEuro.Interfaces;
using LibreriaEuro.DTO;

namespace LibreriaEuro.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibrosController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        //GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<List<LibroDTO>>> ObtenerTodosLibros()
        {
            var libros = await _libroService.ObtenerTodosLibros();
            return Ok(libros);
        }

        //POST api/Libros
        [HttpPost]
        public async Task<ActionResult> CrearLibro(LibroDTO libroDTO)
        {
            if (libroDTO == null)
                return BadRequest();

            var resultado = await _libroService.CrearLibro(libroDTO);

            if (resultado == "AutorNoExiste" || resultado == "TopeLibros") 
                return BadRequest(resultado);

            return CreatedAtAction(nameof(CrearLibro), new { libroDTO.Titulo }, libroDTO);
            
        }

        //PUT api/Libros/x
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarLibro(int id, [FromBody] LibroDTO libro)
        {
            var actualizado = await _libroService.ActualizarLibro(id, libro);
            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        //DELETE api/Libros/x
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarLibro(int id)
        {
            var eliminado = await _libroService.EliminarLibro(id);
            if (!eliminado)
                return NotFound();

            return NoContent();
        }


        [HttpGet("Buscar")]
        public async Task<ActionResult<List<LibroDTO>>> BuscarLibros(
        [FromQuery] string? rutAutor,
        [FromQuery] string? nombreAutor,
        [FromQuery] string? titulo,
        [FromQuery] int? anno)
        {
            var resultado = await _libroService.BuscarLibros(rutAutor, nombreAutor, titulo, anno);
            return Ok(resultado);
        }
    }
}
