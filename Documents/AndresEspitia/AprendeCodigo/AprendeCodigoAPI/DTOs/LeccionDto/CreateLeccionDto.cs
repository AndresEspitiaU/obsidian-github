using System.ComponentModel.DataAnnotations;

namespace AprendeCodigoAPI.DTOs.LeccionDto
{
    public record CreateLeccionDto
    {
        [Required]
        public int CursoId { get; init; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; init; }

        [Required]
        public string Descripcion { get; init; }

        [Required]
        public int OrdenLeccion { get; init; }

        [Required]
        public string ContenidoMarkdown { get; init; }

        public string? MetadatosJSON { get; init; }
        public string? CodigoEjemplos { get; init; }
        public List<int>? TagIds { get; init; }
    }
}
