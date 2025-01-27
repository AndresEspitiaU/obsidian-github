using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class Leccione
{
    public int LeccionId { get; set; }

    public int? CursoId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int OrdenLeccion { get; set; }

    public string? ContenidoMarkdown { get; set; }

    public string? MetadatosJson { get; set; }

    public string? CodigoEjemplos { get; set; }

    public virtual ICollection<ComentariosLeccion> ComentariosLeccions { get; set; } = new List<ComentariosLeccion>();

    public virtual Curso? Curso { get; set; }

    public virtual ICollection<Ejercicio> Ejercicios { get; set; } = new List<Ejercicio>();

    public virtual ICollection<ProgresoLeccione> ProgresoLecciones { get; set; } = new List<ProgresoLeccione>();

    public virtual ICollection<RecursosLeccion> RecursosLeccions { get; set; } = new List<RecursosLeccion>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
