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

        // GET: api/URL
        [HttpGet]
        public IActionResult GetAllURLs()
        {
            var urls = _context.URLs.ToList();
            var urlDtos = _mapper.Map<List<UrlDto>>(urls);
            return Ok(urlDtos);
        }

        // GET: api/URL/{id}
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

        // POST: api/URL
        [HttpPost]
        public IActionResult CreateURL([FromBody] UrlDto newUrlDto)
        {
            if (newUrlDto == null)
            {
                return BadRequest();
            }

            var url = _mapper.Map<URL>(newUrlDto);
            url.CreatedDate = DateTime.Now;
            url.CreatedUser = "User1";

            _context.URLs.Add(url);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetURLById), new { id = url.Id }, newUrlDto);
        }

        // PUT: api/URL/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, [FromBody] UrlDto updatedUrlDto)
        {
            if (updatedUrlDto == null || updatedUrlDto.Id != id)
            {
                return BadRequest();
            }

            var url = _context.URLs.Find(id);
            if (url == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedUrlDto, url);
            url.UpdateDate = DateTime.Now;
            url.UpdateUser = "User1";

            _context.URLs.Update(url);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

