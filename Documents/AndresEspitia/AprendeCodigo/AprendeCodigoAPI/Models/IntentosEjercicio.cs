using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class IntentosEjercicio
{
    public int IntentoId { get; set; }

    public int? UsuarioId { get; set; }

    public int? EjercicioId { get; set; }

    public DateTime? FechaIntento { get; set; }

    public string? RespuestaJson { get; set; }

    public bool? EsCorrecta { get; set; }

    public int? TiempoCompletado { get; set; }

    public virtual Ejercicio? Ejercicio { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
