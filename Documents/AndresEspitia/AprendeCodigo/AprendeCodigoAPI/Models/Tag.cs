using System;
using System.Collections.Generic;

namespace AprendeCodigoAPI.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Leccione> Leccions { get; set; } = new List<Leccione>();
}
