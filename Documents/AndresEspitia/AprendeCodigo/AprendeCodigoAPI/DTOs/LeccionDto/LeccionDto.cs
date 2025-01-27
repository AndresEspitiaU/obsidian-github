namespace AprendeCodigoAPI.DTOs.LeccionDto
{
    public record LeccionDto
    {
        public int LeccionId { get; init; }
        public int CursoId { get; init; }
        public string Titulo { get; init; }
        public string Descripcion { get; init; }
        public int OrdenLeccion { get; init; }
        public string ContenidoMarkdown { get; init; }
        public string MetadatosJSON { get; init; }
        public string CodigoEjemplos { get; init; }
        public List<string> Tags { get; init; }
    }
}
