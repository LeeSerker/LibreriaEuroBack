using LibreriaEuro.Entidades;
using LibreriaEuro.Interfaces;
using LibreriaEuro.Data;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEuro.Repositorios
{
    public class LibroRepository : ILibroRepository
    {
        private readonly LibreroDbContext _context;

        public LibroRepository(LibreroDbContext context)
        {
            _context = context;
        }

        public async Task CrearLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Libro>> ObtenerTodosLibros()
        {
            return await _context.Libros.ToListAsync();
        }

        public async Task<bool> ActualizarLibro(Libro libro)
        {
            _context.Libros.Update(libro);
            var cambiosOk = await _context.SaveChangesAsync();
            return cambiosOk > 0;
        }

        public async Task<bool> EliminarLibro(int id)
        {
            var cambiosOk = 0;
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                cambiosOk = await _context.SaveChangesAsync();
            }

            return cambiosOk > 0;
        }

        public async Task<List<Libro>> ObtenerLibrosPorAutor(string rutAutor)
        {
            return await _context.Libros
                .Where(libro => libro.RutAutor == rutAutor)
                .ToListAsync();
        }

        public async Task<Libro?> ObtenerLibroPorId(int id)
        {
            return await _context.Libros.FindAsync(id);
        }

        public IQueryable<Libro> ObtenerTodosLibrosAutor()
        {
            return _context.Libros.Include(l => l.Autor);
        }

        public async Task<List<Libro>> BuscarLibros(string? rutAutor, string? nombreAutor, string? titulo, int? anno)
        {
            var query = _context.Libros
                .Include(l => l.Autor)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(rutAutor))
                query = query.Where(l => l.RutAutor.Contains(rutAutor));

            if (!string.IsNullOrWhiteSpace(nombreAutor))
                query = query.Where(l => l.Autor.NombreCompleto.Contains(nombreAutor));

            if (!string.IsNullOrWhiteSpace(titulo))
                query = query.Where(l => l.Titulo.Contains(titulo));

            if (anno.HasValue)
                query = query.Where(l => l.Anno == anno.Value);

            return await query.ToListAsync();
        }

    }
}       
