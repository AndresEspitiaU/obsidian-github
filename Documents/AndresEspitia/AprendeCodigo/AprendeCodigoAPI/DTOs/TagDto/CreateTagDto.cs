using System.ComponentModel.DataAnnotations;

namespace AprendeCodigoAPI.DTOs.TagDto
{
    public record CreateTagDto
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; init; }
    }
}
