using System.ComponentModel.DataAnnotations;

namespace AprendeCodigoAPI.DTOs.CategoriaDto
{
    public record CreateCategoriaDto
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; init; }

        [Required]
        public string Descripcion { get; init; }
    }
}
