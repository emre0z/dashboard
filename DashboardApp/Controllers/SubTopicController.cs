using AutoMapper;
using DashboardApp.Contexts;
using DashboardApp.Data.Entity;
using DashboardApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTopicController : ControllerBase
    {
        private readonly DashboardDb _context;
        private readonly IMapper _mapper;

        public SubTopicController(DashboardDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/SubTopic
        [HttpGet]
        public IActionResult GetAllSubTopics()
        {
            var subTopics = _context.SubTopics.ToList();
            var subTopicDtos = _mapper.Map<List<SubTopicDto>>(subTopics);
            return Ok(subTopicDtos);
        }

        // GET: api/SubTopic/{id}
        [HttpGet("{id}")]
        public IActionResult GetSubTopicById(int id)
        {
            var subTopic = _context.SubTopics.Find(id);
            if (subTopic == null)
            {
                return NotFound();
            }

            var subTopicDto = _mapper.Map<SubTopicDto>(subTopic);
            return Ok(subTopicDto);
        }

        // POST: api/SubTopic
        [HttpPost]
        public IActionResult CreateSubTopic([FromBody] SubTopicDto newSubTopicDto)
        {
            if (newSubTopicDto == null)
            {
                return BadRequest();
            }

            var subTopic = _mapper.Map<SubTopic>(newSubTopicDto);
            subTopic.CreatedDate = DateTime.Now;
            subTopic.CreatedUser = "User1";

            _context.SubTopics.Add(subTopic);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSubTopicById), new { id = subTopic.Id }, newSubTopicDto);
        }

        // PUT: api/SubTopic/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSubTopic(int id, [FromBody] SubTopicDto updatedSubTopicDto)
        {
            if (updatedSubTopicDto == null || updatedSubTopicDto.Id != id)
            {
                return BadRequest();
            }

            var subTopic = _context.SubTopics.Find(id);
            if (subTopic == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedSubTopicDto, subTopic);
            subTopic.UpdateDate = DateTime.Now;
            subTopic.UpdateUser = "User1";

            _context.SubTopics.Update(subTopic);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
