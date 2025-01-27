using AprendeCodigoAPI.DTOs.CursoDto;
using AprendeCodigoAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprendeCodigoAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly AppCodeContext _context;
        private readonly IMapper _mapper;

        public CursosController(AppCodeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoDto>>> GetCursos()
        {
            var cursos = await _context.Cursos.Include(c => c.Categoria).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CursoDto>>(cursos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDto>> GetCurso(int id)
        {
            var curso = await _context.Cursos.Include(c => c.Categoria)
                .FirstOrDefaultAsync(c => c.CursoId == id);

            if (curso == null) return NotFound();
            return Ok(_mapper.Map<CursoDto>(curso));
        }

        [HttpPost]
        public async Task<ActionResult<CursoDto>> CreateCurso(CreateCursoDto cursoDto)
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCurso), new { id = curso.CursoId }, _mapper.Map<CursoDto>(curso));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurso(int id, UpdateCursoDto cursoDto)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound();

            _mapper.Map(cursoDto, curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound();

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
