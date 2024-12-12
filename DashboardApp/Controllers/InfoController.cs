using AutoMapper;
using DashboardApp.Contexts;
using DashboardApp.Data.Entity;
using DashboardApp.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly DashboardDb _context;
        private readonly IMapper _mapper;

        public InfoController(DashboardDb context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllInfos()
        {
            var infos = _context.Infos.ToList();
            var infoDtos = _mapper.Map<List<InfoDto>>(infos);
            return Ok(infoDtos);
        }

        [HttpGet("subtopic/{subTopicId}")]
        public IActionResult GetInfosBySubTopicId(int subTopicId)
        {
            var infos = _context.Infos.Where(i => i.SubTopicId == subTopicId).ToList();
            var infoDtos = _mapper.Map<List<InfoDto>>(infos);
            return Ok(infoDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetInfoById(int id)
        {
            var info = _context.Infos.Find(id);
            if (info == null)
            {
                return NotFound();
            }

            var infoDto = _mapper.Map<InfoDto>(info);
            return Ok(infoDto);
        }

        [HttpPost]
        public IActionResult CreateInfo([FromBody] InfoDto newInfoDto)
        {
            if (newInfoDto == null)
            {
                return BadRequest();
            }

            var info = _mapper.Map<Info>(newInfoDto);
            _context.Infos.Add(info);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetInfoById), new { id = info.Id }, newInfoDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInfo(int id, [FromBody] InfoDto updatedInfoDto)
        {
            if (updatedInfoDto == null || updatedInfoDto.Id != id)
            {
                return BadRequest();
            }

            var info = _context.Infos.Find(id);
            if (info == null)
            {
                return NotFound();
            }

            _mapper.Map(updatedInfoDto, info);
            _context.Infos.Update(info);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInfo(int id)
        {
            var info = _context.Infos.Find(id);
            if (info == null)
            {
                return NotFound();
            }

            _context.Infos.Remove(info);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
