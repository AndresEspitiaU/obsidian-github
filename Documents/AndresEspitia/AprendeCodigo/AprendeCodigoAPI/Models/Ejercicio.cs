using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class Ejercicio
{
    public int EjercicioId { get; set; }

    public int? LeccionId { get; set; }

    public int? TipoEjercicioId { get; set; }

    public string? Titulo { get; set; }

    public string? Instrucciones { get; set; }

    public string? ConfiguracionJson { get; set; }

    public string? SolucionJson { get; set; }

    public virtual ICollection<IntentosEjercicio> IntentosEjercicios { get; set; } = new List<IntentosEjercicio>();

    public virtual Leccione? Leccion { get; set; }

    public virtual TiposEjercicio? TipoEjercicio { get; set; }
}
