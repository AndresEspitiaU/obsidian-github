using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string? Username { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? HashPassword { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<ComentariosLeccion> ComentariosLeccions { get; set; } = new List<ComentariosLeccion>();

    public virtual ICollection<IntentosEjercicio> IntentosEjercicios { get; set; } = new List<IntentosEjercicio>();

    public virtual ICollection<ProgresoLeccione> ProgresoLecciones { get; set; } = new List<ProgresoLeccione>();

    public virtual ICollection<UsuariosCurso> UsuariosCursos { get; set; } = new List<UsuariosCurso>();

    public virtual ICollection<ComentariosLeccion> Comentarios { get; set; } = new List<ComentariosLeccion>();
}
