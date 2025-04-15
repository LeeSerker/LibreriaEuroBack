using LibreriaEuro.DTO;
using LibreriaEuro.Entidades;
using LibreriaEuro.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEuro.Servicios
{
    public class LibroService : ILibroService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IAutorRepository _autorRepository;

        public LibroService(ILibroRepository libroRepository, IAutorRepository autorRepository)
        {
            _libroRepository = libroRepository;
            _autorRepository = autorRepository;
        }

        public Task<List<LibroDTO>> ObtenerLibrosPorAutor(string rutAutor)
        {
            // Retorna una lista vacía por defecto
            return Task.FromResult(new List<LibroDTO>());
        }

        public async Task<string> CrearLibro(LibroDTO libroDTO)
        {

            var autorExiste = await _autorRepository.ExisteAutorPorRut(libroDTO.RutAutor);

            if (!autorExiste)
            {
                return "AutorNoExiste";
            }

            var libros = await _libroRepository.ObtenerLibrosPorAutor(libroDTO.RutAutor);
            var cantidadLibros = libros.Count;

            if (cantidadLibros > 9)
            {
                return "TopeLibros";
            }

            var libro = new Libro
            {
                Titulo = libroDTO.Titulo,
                Anno = libroDTO.Anno,
                Genero = libroDTO.Genero,
                NumeroDePaginas = libroDTO.NumeroDePaginas,
                RutAutor = libroDTO.RutAutor
            };

            await _libroRepository.CrearLibro(libro);
            return "OK";
        }

        public async Task<List<LibroDTO>> ObtenerTodosLibros()
        {
            var libros = await _libroRepository.ObtenerTodosLibros();

            return libros.Select(libro => new LibroDTO
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                Anno = libro.Anno,
                Genero = libro.Genero,
                NumeroDePaginas = libro.NumeroDePaginas,
                RutAutor = libro.RutAutor
            }).ToList();
        }

        public async Task<bool> ActualizarLibro(int id, LibroDTO libro)
        {
            var libroActualizar = await _libroRepository.ObtenerLibroPorId(id);
            if (libroActualizar == null)
            {
                return false;
            }

            libroActualizar.Titulo = libro.Titulo;
            libroActualizar.Anno = libro.Anno;
            libroActualizar.Genero = libro.Genero;
            libroActualizar.NumeroDePaginas = libro.NumeroDePaginas;
            libroActualizar.RutAutor = libro.RutAutor;

            var resultado = await _libroRepository.ActualizarLibro(libroActualizar);
            return resultado;

        }

        public async Task<bool> EliminarLibro(int id)
        {
            var libroEliminar = await _libroRepository.ObtenerLibroPorId(id);
            if (libroEliminar == null)
            {
                return false;
            }

            var resultado = await _libroRepository.EliminarLibro(id);

            return resultado;
        }
        public async Task<List<LibroDTO>> BuscarLibros(string? rutAutor, string? nombreAutor, string? titulo, int? anno)
        {
            var query = _libroRepository.ObtenerTodosLibrosAutor();

            if (!string.IsNullOrEmpty(rutAutor))
                query = query.Where(l => l.RutAutor.Contains(rutAutor));

            if (!string.IsNullOrEmpty(nombreAutor))
                query = query.Where(l => l.Autor.NombreCompleto.Contains(nombreAutor));

            if (!string.IsNullOrEmpty(titulo))
                query = query.Where(l => l.Titulo.Contains(titulo));

            if (anno.HasValue)
                query = query.Where(l => l.Anno == anno.Value);

            var libros = await query.ToListAsync();
            
            return libros.Select(l => new LibroDTO
            {
                Titulo = l.Titulo,
                Anno = l.Anno,
                Genero = l.Genero,
                NumeroDePaginas = l.NumeroDePaginas,
                RutAutor = l.RutAutor
            }).ToList();
        }

    }
}
