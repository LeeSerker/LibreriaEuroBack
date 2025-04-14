using LibreriaEuro.Entidades;
using LibreriaEuro.Interfaces;
using LibreriaEuro.Data;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEuro.Repositorios
{
    public class AutorRepository : IAutorRepository
    {
        private readonly LibreroDbContext _context;

        public AutorRepository(LibreroDbContext context)
        {
            _context = context;
        }

        public async Task CrearAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Autor>> ObtenerTodosAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<bool> ActualizarAutor(Autor autor)
        {
            _context.Autores.Update(autor);
            var cambiosOk = await _context.SaveChangesAsync();
            return cambiosOk > 0;
        }

        public async Task<bool> EliminarAutor(int id)
        {
            var cambiosOk = 0;
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                cambiosOk = await _context.SaveChangesAsync();
            }

            return cambiosOk > 0;
        }

        public async Task<Autor?> ObtenerAutorPorId(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task<bool> ExisteAutorPorRut(string rutAutor)
        {
            return await _context.Autores.AnyAsync(a => a.Rut == rutAutor);
        }

    }
}