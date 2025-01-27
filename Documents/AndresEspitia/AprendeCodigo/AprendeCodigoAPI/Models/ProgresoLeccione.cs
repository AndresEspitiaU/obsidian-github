using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class ProgresoLeccione
{
    public int UsuarioId { get; set; }

    public int LeccionId { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaCompletado { get; set; }

    public virtual Leccione Leccion { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
