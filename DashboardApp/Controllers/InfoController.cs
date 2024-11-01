using DashboardApp.Contexts;
using DashboardApp.Data.Entity;
using Microsoft.AspNetCore.Mvc;


namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly DashboardDb _context;

        public InfoController(DashboardDb context)
        {
            _context = context;
        }

        // GET: api/Info
        [HttpGet]
        public IActionResult GetAllInfos()
        {
            var infos = _context.Infos.ToList();
            return Ok(infos);
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
            return Ok(info);
        }

        // POST: api/Info
        [HttpPost]
        public IActionResult CreateInfo([FromBody] Info newInfo)
        {
            if (newInfo == null)
            {
                return BadRequest();
            }

            newInfo.CreatedDate = DateTime.Now;
            newInfo.CreatedUser = "User1";

            _context.Infos.Add(newInfo);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetInfoById), new { id = newInfo.Id }, newInfo);
        }

        // PUT: api/Info/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateInfo(int id, [FromBody] Info updatedInfo)
        {
            if (updatedInfo == null || updatedInfo.Id != id)
            {
                return BadRequest();
            }

            var info = _context.Infos.Find(id);
            if (info == null)
            {
                return NotFound();
            }

            info.Content = updatedInfo.Content;
            info.InfoKey = updatedInfo.InfoKey;
            info.UpdateDate = DateTime.Now;
            info.UpdateUser = "User1";

            _context.Infos.Update(info);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Info/{id}
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
