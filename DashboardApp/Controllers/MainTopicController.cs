using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DashboardApp.Contexts;
using DashboardApp.Data.Entity;
using DashboardApp.DTOs;

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

        // GET: api/MainTopic
        [HttpGet]
        public IActionResult GetAllMainTopics()
        {
            var mainTopics = _context.MainTopics.ToList();
            var mainTopicDtos = _mapper.Map<List<MainTopicDto>>(mainTopics);
            return Ok(mainTopicDtos);
        }

        // GET: api/MainTopic/{id}
        [HttpGet("{id}")]
        public IActionResult GetMainTopicById(int id)
        {
            var mainTopic = _context.MainTopics.Find(id);
            if (mainTopic == null)
            {
                return NotFound();
            }

            var mainTopicDto = _mapper.Map<MainTopicDto>(mainTopic);
            return Ok(mainTopicDto);
        }

        // POST: api/MainTopic
        [HttpPost]
        public IActionResult CreateMainTopic([FromBody] MainTopicDto newMainTopicDto)
        {
            if (newMainTopicDto == null)
            {
                return BadRequest();
            }

            var newMainTopic = _mapper.Map<MainTopic>(newMainTopicDto);
            newMainTopic.CreatedDate = DateTime.Now;
            newMainTopic.CreatedUser = "User1";

            _context.MainTopics.Add(newMainTopic);
            _context.SaveChanges();

            var mainTopicDto = _mapper.Map<MainTopicDto>(newMainTopic);
            return CreatedAtAction(nameof(GetMainTopicById), new { id = mainTopicDto.Id }, mainTopicDto);
        }

        // PUT: api/MainTopic/{id}
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
            mainTopic.UpdateDate = DateTime.Now;
            mainTopic.UpdateUser = "User1";

            _context.MainTopics.Update(mainTopic);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/MainTopic/{id}
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
