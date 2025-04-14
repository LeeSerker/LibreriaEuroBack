using System.ComponentModel.DataAnnotations;

namespace LibreriaEuro.Entidades;

public class Autor
{
    //[Key]
    //public int Id { get; set; }
    public string Rut { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string CiudadOrigen { get; set; } = null!;

    public string Mail { get; set; } = null!;


    public List<Libro>? Libros { get; set; }
}
