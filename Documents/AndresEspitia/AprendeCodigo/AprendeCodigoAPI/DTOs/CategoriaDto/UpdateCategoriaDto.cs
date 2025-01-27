using System.ComponentModel.DataAnnotations;

namespace AprendeCodigoAPI.DTOs.CategoriaDto
{
    public record UpdateCategoriaDto
    {
        [StringLength(100)]
        public string? Nombre { get; init; }
        public string? Descripcion { get; init; }
    }
}
