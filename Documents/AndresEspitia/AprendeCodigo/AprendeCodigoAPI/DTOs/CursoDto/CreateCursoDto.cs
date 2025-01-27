using System.ComponentModel.DataAnnotations;

namespace AprendeCodigoAPI.DTOs.CursoDto
{
    public record CreateCursoDto
    {
        [Required]
        public int CategoriaId { get; init; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; init; }

        [Required]
        public string Descripcion { get; init; }

        [Required]
        [StringLength(20)]
        public string Nivel { get; init; }

        public string? ImagenUrl { get; init; }
    }
}
