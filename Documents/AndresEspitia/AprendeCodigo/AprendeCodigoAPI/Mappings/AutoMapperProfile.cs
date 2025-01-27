using AprendeCodigoAPI.DTOs.CategoriaDto;
using AprendeCodigoAPI.DTOs.CursoDto;
using AprendeCodigoAPI.DTOs.LeccionDto;
using AprendeCodigoAPI.DTOs.TagDto;
using AprendeCodigoAPI.Models;
using AutoMapper;

namespace AprendeCodigoAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Cursos
            CreateMap<Curso, CursoDto>();
            CreateMap<CreateCursoDto, Curso>();
            CreateMap<UpdateCursoDto, Curso>();

            // Categorias
            CreateMap<CategoriasCurso, CategoriaDto>();
            CreateMap<CreateCategoriaDto, CategoriasCurso>();
            CreateMap<UpdateCategoriaDto, CategoriasCurso>();

            // Lecciones
            CreateMap<Leccione, LeccionDto>()
           .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(t => t.Nombre)));
            CreateMap<CreateLeccionDto, Leccione>();
            CreateMap<UpdateLeccionDto, Leccione>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Tags
            CreateMap<Tag, TagDto>();
            CreateMap<CreateTagDto, Tag>();
            CreateMap<UpdateTagDto, Tag>();
        }
    }
}
