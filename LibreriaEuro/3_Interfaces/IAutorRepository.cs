using LibreriaEuro.Entidades;

namespace LibreriaEuro.Interfaces
{
    public interface IAutorRepository
    {
        Task<List<Autor>> ObtenerTodosAutores();
        Task CrearAutor(Autor autor);
        Task<bool> ActualizarAutor(Autor autor);
        Task<bool> EliminarAutor(int id);
        Task<Autor?> ObtenerAutorPorId(int id);
        Task<bool> ExisteAutorPorRut(string rutAutor);
    }
}