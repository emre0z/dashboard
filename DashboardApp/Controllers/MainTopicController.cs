using AutoMapper;
using DashboardApp.Contexts;
using DashboardApp.Data.Entity;
using DashboardApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainTopicController : ControllerBase
    {
        private readonly DashboardDb _context;
        private readonly IMapper _mapper;

        public MainTopicController(DashboardDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMainTopics()
        {
            var mainTopics = _context.MainTopics
                                     .Include(mt => mt.SubTopics)
                                     .ToList();
            var mainTopicDtos = _mapper.Map<List<MainTopicDto>>(mainTopics);
            return Ok(mainTopicDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetMainTopicById(int id)
        {
            var mainTopic = _context.MainTopics
                                    .Include(mt => mt.SubTopics)
                                    .FirstOrDefault(mt => mt.Id == id);
            if (mainTopic == null)
            {
                return NotFound();
            }

            var mainTopicDto = _mapper.Map<MainTopicDto>(mainTopic);
            return Ok(mainTopicDto);
        }

        [HttpPost]
        public IActionResult CreateMainTopic([FromBody] MainTopicDto newMainTopicDto)
        
        {
            if (newMainTopicDto == null)
            {
                return BadRequest();
            }

            var mainTopic = _mapper.Map<MainTopic>(newMainTopicDto);
            _context.MainTopics.Add(mainTopic);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMainTopicById), new { id = mainTopic.Id }, newMainTopicDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMainTopic(int id, [FromBody] MainTopicDto updatedMainTopicDto)
        {
            if (updatedMainTopicDto == null || updatedMainTopicDto.Id != id)
            {
                return BadRequest();
            }

            var mainTopic = _context.MainTopics.Find(id);
            if (mainTopic == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedMainTopicDto, mainTopic);
            _context.MainTopics.Update(mainTopic);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMainTopic(int id)
        {
            var mainTopic = _context.MainTopics.Find(id);
            if (mainTopic == null)
            {
                return NotFound();
            }

            _context.MainTopics.Remove(mainTopic);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

