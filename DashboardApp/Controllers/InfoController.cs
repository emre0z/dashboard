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

        // GET: api/Info
        [HttpGet]
        public IActionResult GetAllInfos()
        {
            List<Info> infos = _context.Infos.ToList();
            var infoDtos = _mapper.Map<List<InfoDto>>(infos);
            return Ok(infoDtos);
        }

        // GET: api/Info/{id}
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

        // POST: api/Info
        [HttpPost]
        public IActionResult CreateInfo([FromBody] InfoDto newInfoDto)
        {
            if (newInfoDto == null)
            {
                return BadRequest();
            }

            var info = _mapper.Map<Info>(newInfoDto);
            info.CreatedDate = DateTime.Now;
            info.CreatedUser = "User1";

            _context.Infos.Add(info);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetInfoById), new { id = info.Id }, newInfoDto);
        }

        // PUT: api/Info/{id}
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
            info.UpdateDate = DateTime.Now;
            info.UpdateUser = "User1";

            _context.Infos.Update(info);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

