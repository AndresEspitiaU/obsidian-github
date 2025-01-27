using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class Curso
{
    public int CursoId { get; set; }

    public int? CategoriaId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Nivel { get; set; }

    public string? ImagenUrl { get; set; }

    public bool? Estado { get; set; }

    public virtual CategoriasCurso? Categoria { get; set; }

    public virtual ICollection<Leccione> Lecciones { get; set; } = new List<Leccione>();

    public virtual ICollection<UsuariosCurso> UsuariosCursos { get; set; } = new List<UsuariosCurso>();
}
