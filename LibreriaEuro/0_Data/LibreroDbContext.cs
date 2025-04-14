using System;
using System.Collections.Generic;
using LibreriaEuro.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LibreriaEuro.Data;

public partial class LibreroDbContext : DbContext
{
    public LibreroDbContext()
    {
    }

    public LibreroDbContext(DbContextOptions<LibreroDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autores { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:pry-001.database.windows.net,1433;Initial Catalog=Librero;Encrypt=True;TrustServerCertificate=False;Authentication=Active Directory Default");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Rut);

            entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            entity.Property(e => e.Rut).HasMaxLength(10);
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.RutAutor).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
