using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class TiposEjercicio
{
    public int TipoEjercicioId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Ejercicio> Ejercicios { get; set; } = new List<Ejercicio>();
}
