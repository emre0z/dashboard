using DashboardApp.Contexts;
using DashboardApp.Data.Entity;
using Microsoft.AspNetCore.Mvc;


namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class URLController : ControllerBase
    {
        private readonly DashboardDb _context;

        public URLController(DashboardDb context)
        {
            _context = context;
        }

        // GET: api/URL
        [HttpGet]
        public IActionResult GetAllURLs()
        {
            var urls = _context.URLs.ToList();
            return Ok(urls);
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
            return Ok(url);
        }

        // POST: api/URL
        [HttpPost]
        public IActionResult CreateURL([FromBody] URL newURL)
        {
            if (newURL == null)
            {
                return BadRequest();
            }

            newURL.CreatedDate = DateTime.Now;
            newURL.CreatedUser = "User1";

            _context.URLs.Add(newURL);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetURLById), new { id = newURL.Id }, newURL);
        }

        // PUT: api/URL/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateURL(int id, [FromBody] URL updatedURL)
        {
            if (updatedURL == null || updatedURL.Id != id)
            {
                return BadRequest();
            }

            var url = _context.URLs.Find(id);
            if (url == null)
            {
                return NotFound();
            }

            url.Content = updatedURL.Content;
            url.UpdateDate = DateTime.Now;
            url.UpdateUser = "User1";

            _context.URLs.Update(url);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/URL/{id}
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

