using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class CategoriasCurso
{
    public int CategoriaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Curso> Cursos { get; set; } = new List<Curso>();
}
