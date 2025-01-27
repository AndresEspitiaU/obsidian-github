using AprendeCodigoAPI.DTOs.LeccionDto;
using AprendeCodigoAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprendeCodigoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeccionesController : ControllerBase
    {
        private readonly AppCodeContext _context;
        private readonly IMapper _mapper;

        public LeccionesController(AppCodeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeccionDto>>> GetLecciones(int cursoId)
        {
            var lecciones = await _context.Lecciones
                .Include(l => l.Tags)
                .Where(l => l.CursoId == cursoId)
                .OrderBy(l => l.OrdenLeccion)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<LeccionDto>>(lecciones));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeccionDto>> GetLeccion(int id)
        {
            var leccion = await _context.Lecciones
                .Include(l => l.Tags)
                .FirstOrDefaultAsync(l => l.LeccionId == id);

            if (leccion == null) return NotFound();
            return Ok(_mapper.Map<LeccionDto>(leccion));
        }

        [HttpPost]
        public async Task<ActionResult<LeccionDto>> CreateLeccion(CreateLeccionDto dto)
        {
            var leccion = _mapper.Map<Leccione>(dto);

            if (dto.TagIds != null)
            {
                var tags = await _context.Tags
                    .Where(t => dto.TagIds.Contains(t.TagId))
                    .ToListAsync();
                leccion.Tags = tags;
            }

            _context.Lecciones.Add(leccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLeccion), new { id = leccion.LeccionId }, _mapper.Map<LeccionDto>(leccion));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeccion(int id, UpdateLeccionDto dto)
        {
            var leccion = await _context.Lecciones
                .Include(l => l.Tags)
                .FirstOrDefaultAsync(l => l.LeccionId == id);

            if (leccion == null) return NotFound();

            _mapper.Map(dto, leccion);

            if (dto.TagIds != null)
            {
                leccion.Tags.Clear();
                var tags = await _context.Tags
                    .Where(t => dto.TagIds.Contains(t.TagId))
                    .ToListAsync();
                foreach (var tag in tags)
                {
                    leccion.Tags.Add(tag);
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeccion(int id)
        {
            var leccion = await _context.Lecciones.FindAsync(id);
            if (leccion == null) return NotFound();

            _context.Lecciones.Remove(leccion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
