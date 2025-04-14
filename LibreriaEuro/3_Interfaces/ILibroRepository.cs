using LibreriaEuro.DTO;
using LibreriaEuro.Entidades;

namespace LibreriaEuro.Interfaces
{
    public interface ILibroRepository
    {
        Task<List<Libro>> ObtenerTodosLibros();
        Task CrearLibro(Libro libro);
        Task<bool> ActualizarLibro(Libro libro);
        Task<bool> EliminarLibro(int id);
        Task<List<Libro>> ObtenerLibrosPorAutor(string rutAutor);
        Task<Libro?> ObtenerLibroPorId(int id);
        IQueryable<Libro> ObtenerTodosLibrosAutor();
        Task<List<Libro>> BuscarLibros(string? rutAutor, string? nombreAutor, string? titulo, int? anno);
    }
}
