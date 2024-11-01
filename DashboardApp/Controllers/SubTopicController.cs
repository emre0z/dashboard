using DashboardApp.Contexts;
using DashboardApp.Data.Entity;
using Microsoft.AspNetCore.Mvc;


namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTopicController : ControllerBase
    {
        private readonly DashboardDb _context;

        public SubTopicController(DashboardDb context)
        {
            _context = context;
        }

        // GET: api/SubTopic
        [HttpGet]
        public IActionResult GetAllSubTopics()
        {
            var subTopics = _context.SubTopics.ToList();
            return Ok(subTopics);
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
            return Ok(subTopic);
        }

        // POST: api/SubTopic
        [HttpPost]
        public IActionResult CreateSubTopic([FromBody] SubTopic newSubTopic)
        {
            if (newSubTopic == null)
            {
                return BadRequest();
            }

            newSubTopic.CreatedDate = DateTime.Now;
            newSubTopic.CreatedUser = "User1";

            _context.SubTopics.Add(newSubTopic);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSubTopicById), new { id = newSubTopic.Id }, newSubTopic);
        }

        // PUT: api/SubTopic/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateSubTopic(int id, [FromBody] SubTopic updatedSubTopic)
        {
            if (updatedSubTopic == null || updatedSubTopic.Id != id)
            {
                return BadRequest();
            }

            var subTopic = _context.SubTopics.Find(id);
            if (subTopic == null)
            {
                return NotFound();
            }

            subTopic.Tittle = updatedSubTopic.Tittle;
            subTopic.UpdateDate = DateTime.Now;
            subTopic.UpdateUser = "User1";

            _context.SubTopics.Update(subTopic);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/SubTopic/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteSubTopic(int id)
        {
            var subTopic = _context.SubTopics.Find(id);
            if (subTopic == null)
            {
                return NotFound();
            }

            _context.SubTopics.Remove(subTopic);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
