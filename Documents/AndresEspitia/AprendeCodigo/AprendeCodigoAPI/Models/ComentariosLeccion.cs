using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class ComentariosLeccion
{
    public int ComentarioId { get; set; }

    public int? LeccionId { get; set; }

    public int? UsuarioId { get; set; }

    public string? Contenido { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? ParentId { get; set; }

    public int? Likes { get; set; }

    public virtual ICollection<ComentariosLeccion> InverseParent { get; set; } = new List<ComentariosLeccion>();

    public virtual Leccione? Leccion { get; set; }

    public virtual ComentariosLeccion? Parent { get; set; }

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
