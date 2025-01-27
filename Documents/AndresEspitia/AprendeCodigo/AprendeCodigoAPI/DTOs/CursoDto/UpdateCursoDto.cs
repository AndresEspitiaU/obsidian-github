using System.ComponentModel.DataAnnotations;

namespace AprendeCodigoAPI.DTOs.CursoDto
{
    public record UpdateCursoDto
    {
        [StringLength(100)]
        public string? Titulo { get; init; }
        public string? Descripcion { get; init; }
        [StringLength(20)]
        public string? Nivel { get; init; }
        public string? ImagenUrl { get; init; }
        public bool? Estado { get; init; }
    }
}
