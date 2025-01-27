namespace AprendeCodigoAPI.DTOs.CategoriaDto
{
    public record CategoriaDto
    {
        public int CategoriaId { get; init; }
        public string Nombre { get; init; }
        public string Descripcion { get; init; }
        public int TotalCursos { get; init; }
    }
}
