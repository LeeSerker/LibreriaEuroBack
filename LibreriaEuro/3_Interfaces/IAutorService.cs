using LibreriaEuro.DTO;

namespace LibreriaEuro.Interfaces
{
    public interface IAutorService
    {
        Task<List<AutorDTO>> ObtenerTodosAutores();
        Task CrearAutor(AutorDTO autor);
        Task<bool> ActualizarAutor(int id, AutorDTO autor);
        Task<bool> EliminarAutor(int id);
    }
}