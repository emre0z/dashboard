using AutoMapper;
using DashboardApp.Contexts;
using DashboardApp.Data.Entity;
using DashboardApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLController : ControllerBase
    {
        private readonly DashboardDb _context;
        private readonly IMapper _mapper;

        public URLController(DashboardDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllURLs()
        {
            var urls = _context.URLs.ToList();
            var urlDtos = _mapper.Map<List<UrlDto>>(urls);
            return Ok(urlDtos);
        }

        [HttpGet("subtopic/{subTopicId}")]
        public IActionResult GetURLsBySubTopicId(int subTopicId)
        {
            var urls = _context.URLs.Where(u => u.SubTopicId == subTopicId).ToList();
            var urlDtos = _mapper.Map<List<UrlDto>>(urls);
            return Ok(urlDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetURLById(int id)
        {
            var url = _context.URLs.Find(id);
            if (url == null)
            {
                return NotFound();
            }

            var urlDto = _mapper.Map<UrlDto>(url);
            return Ok(urlDto);
        }

        [HttpPost]
        public IActionResult CreateURL([FromBody] UrlDto newUrlDto)
        {
            if (newUrlDto == null)
            {
                return BadRequest();
            }

            var url = _mapper.Map<URL>(newUrlDto);
            _context.URLs.Add(url);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetURLById), new { id = url.Id }, newUrlDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, [FromBody] UrlDto updatedUrlDto)
        {
            if (updatedUrlDto == null || updatedUrlDto.Id != id)
            {
                return BadRequest("Geçersiz URL ID'si.");
            }

            var url = _context.URLs.FirstOrDefault(u => u.Id == id);
            if (url == null)
            {
                return NotFound($"ID {id} ile eşleşen bir URL bulunamadı.");
            }

            _mapper.Map(updatedUrlDto, url);
            _context.URLs.Update(url);
            _context.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteURL(int id)
        {
            var url = _context.URLs.Find(id);
            if (url == null)
            {
                return NotFound();
            }

            _context.URLs.Remove(url);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
