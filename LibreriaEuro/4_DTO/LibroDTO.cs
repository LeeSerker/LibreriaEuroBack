namespace LibreriaEuro.DTO
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;

        public int Anno { get; set; }

        public string Genero { get; set; } = null!;

        public int NumeroDePaginas { get; set; }

        public string RutAutor { get; set; } = null!;
    }
}
