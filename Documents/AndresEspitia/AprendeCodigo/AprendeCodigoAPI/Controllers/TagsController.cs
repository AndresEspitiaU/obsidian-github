using AprendeCodigoAPI.DTOs.TagDto;
using AprendeCodigoAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AprendeCodigoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : ControllerBase
    {
        private readonly AppCodeContext _context;
        private readonly IMapper _mapper;

        public TagsController(AppCodeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDto>>> GetTags()
        {
            var tags = await _context.Tags.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TagDto>>(tags));
        }

        [HttpPost]
        public async Task<ActionResult<TagDto>> CreateTag(CreateTagDto dto)
        {
            var tagExists = await _context.Tags.AnyAsync(t => t.Nombre == dto.Nombre);
            if (tagExists) return BadRequest("Tag already exists");

            var tag = _mapper.Map<Tag>(dto);
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTags), new { id = tag.TagId }, _mapper.Map<TagDto>(tag));
        }
    }

}
