using LibreriaEuro.DTO;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaEuro.Interfaces
{
    public interface ILibroService
    {

        Task<List<LibroDTO>> ObtenerLibrosPorAutor(string rutAutor);
        Task<string> CrearLibro(LibroDTO libro);
        Task<List<LibroDTO>> ObtenerTodosLibros();
        Task<bool> ActualizarLibro(int id, LibroDTO libro);
        Task<bool> EliminarLibro(int id);
        Task<List<LibroDTO>> BuscarLibros(string? rutAutor, string? nombreAutor, string? titulo, int? anno);

    }
}
