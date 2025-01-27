using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class RecursosLeccion
{
    public int RecursoId { get; set; }

    public int? LeccionId { get; set; }

    public string? Tipo { get; set; }

    public string? Titulo { get; set; }

    public string? Url { get; set; }

    public string? Descripcion { get; set; }

    public virtual Leccione? Leccion { get; set; }
}
