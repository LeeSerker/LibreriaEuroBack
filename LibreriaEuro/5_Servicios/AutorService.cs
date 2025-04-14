using LibreriaEuro.DTO;
using LibreriaEuro.Entidades;
using LibreriaEuro.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEuro.Servicios
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task CrearAutor(AutorDTO autorDTO)
        {
            var autor = new Autor
            {
                Rut = autorDTO.Rut,
                NombreCompleto = autorDTO.NombreCompleto,
                FechaNacimiento = autorDTO.FechaNacimiento,
                CiudadOrigen = autorDTO.CiudadOrigen,
                Mail = autorDTO.Mail
            };

            await _autorRepository.CrearAutor(autor);
        }

        public async Task<List<AutorDTO>> ObtenerTodosAutores()
        {
            // Retorna una lista vacía por defecto
            //return Task.FromResult(new List<LibroDTO>());
            var autores = await _autorRepository.ObtenerTodosAutores();

            return autores.Select(autor => new AutorDTO
            {
                //Id = autor.Id,
                Rut = autor.Rut,
                NombreCompleto = autor.NombreCompleto,
                FechaNacimiento = autor.FechaNacimiento,
                CiudadOrigen = autor.CiudadOrigen,
                Mail = autor.Mail
            }).ToList();
        }

        public async Task<bool> ActualizarAutor(int id, AutorDTO autor)
        {
            var autorActualizar = await _autorRepository.ObtenerAutorPorId(id);
            if (autorActualizar == null)
            {
                return false;
            }

            autorActualizar.Rut = autor.Rut;
            autorActualizar.NombreCompleto = autor.NombreCompleto;
            autorActualizar.FechaNacimiento = autor.FechaNacimiento;
            autorActualizar.CiudadOrigen = autor.CiudadOrigen;
            autorActualizar.Mail = autor.Mail;

            var resultado = await _autorRepository.ActualizarAutor(autorActualizar);
            return resultado;

        }

        public async Task<bool> EliminarAutor(int id)
        {
            var autorEliminar = await _autorRepository.ObtenerAutorPorId(id);
            if (autorEliminar == null)
            {
                return false;
            }

            var resultado = await _autorRepository.EliminarAutor(id);

            return resultado;
        }
    }
}