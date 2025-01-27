namespace AprendeCodigoAPI.DTOs.CursoDto
{
    public record CursoDto
    {
        public int CursoId { get; init; }
        public int CategoriaId { get; init; }
        public string Titulo { get; init; }
        public string Descripcion { get; init; }
        public string Nivel { get; init; }
        public string ImagenUrl { get; init; }
        public bool Estado { get; init; }
        public string CategoriaNombre { get; init; }
        public int TotalLecciones { get; init; }
    }
}
