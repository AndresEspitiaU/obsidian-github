namespace AprendeCodigoAPI.DTOs.LeccionDto
{
    public record UpdateLeccionDto
    {
        public string? Titulo { get; init; }
        public string? Descripcion { get; init; }
        public int? OrdenLeccion { get; init; }
        public string? ContenidoMarkdown { get; init; }
        public string? MetadatosJSON { get; init; }
        public string? CodigoEjemplos { get; init; }
        public List<int>? TagIds { get; init; }
    }
}
