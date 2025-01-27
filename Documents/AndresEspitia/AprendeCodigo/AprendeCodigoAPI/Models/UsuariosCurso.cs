using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class UsuariosCurso
{
    public int UsuarioId { get; set; }

    public int CursoId { get; set; }

    public DateTime? FechaInscripcion { get; set; }

    public DateTime? FechaCompletado { get; set; }

    public decimal? ProgresoTotal { get; set; }

    public string? Estado { get; set; }

    public virtual Curso Curso { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
