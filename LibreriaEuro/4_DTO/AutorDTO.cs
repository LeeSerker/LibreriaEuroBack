namespace LibreriaEuro.DTO
{
    public class AutorDTO
    {

        public string Rut { get; set; } = null!;

        public string NombreCompleto { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        public string CiudadOrigen { get; set; } = null!;

        public string Mail { get; set; } = null!;
    }
}
