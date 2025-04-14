using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaEuro.Entidades;

public class Libro
{
    [Key]
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public int Anno { get; set; }

    public string Genero { get; set; } = null!;

    public int NumeroDePaginas { get; set; }

    [ForeignKey("Autor")]
    public string RutAutor { get; set; } = null!;    

    public Autor? Autor { get; set; }
}
