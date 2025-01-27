using AprendeCodigoAPI.DTOs.CategoriaDto;
using AprendeCodigoAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprendeCodigoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppCodeContext _context;
        private readonly IMapper _mapper;

        public CategoriasController(AppCodeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategorias()
        {
            var categorias = await _context.CategoriasCursos.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CategoriaDto>>(categorias));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaDto>> GetCategoria(int id)
        {
            var categoria = await _context.CategoriasCursos.FindAsync(id);
            if (categoria == null) return NotFound();
            return Ok(_mapper.Map<CategoriaDto>(categoria));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CategoriaDto>> CreateCategoria(CreateCategoriaDto dto)
        {
            var categoria = _mapper.Map<CategoriasCurso>(dto);
            _context.CategoriasCursos.Add(categoria);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategoria), new { id = categoria.CategoriaId }, _mapper.Map<CategoriaDto>(categoria));
        }
    }

}
