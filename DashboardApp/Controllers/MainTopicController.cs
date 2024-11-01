using DashboardApp.Contexts;
using DashboardApp.Data.Entity;
using Microsoft.AspNetCore.Mvc;


namespace DashboardApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainTopicController : ControllerBase
    {
        private readonly DashboardDb _context;

        public MainTopicController(DashboardDb context)
        {
            _context = context;
        }
        //Bir sayfada ya da uygulama ekranında tüm MainTopic kayıtlarını listelemek istediğimizde kullanılır.
        // GET: api/MainTopic
        [HttpGet]
        public IActionResult GetAllMainTopics()
        {
            var mainTopics = _context.MainTopics.ToList();
            return Ok(mainTopics);
        }
        //Belirli bir MainTopic başlığına ilişkin detaylı bilgileri almak istediğimizde kullanılır.
        // GET: api/MainTopic/{id}
        [HttpGet("{id}")]
        public IActionResult GetMainTopicById(int id)
        {
            var mainTopic = _context.MainTopics.Find(id);
            if (mainTopic == null)
            {
                return NotFound();
            }
            return Ok(mainTopic);
        }
        //Yeni bir başlık eklemek veya sistemde yeni veri kayıtları oluşturmak istediğimizde kullanılır.
        // POST: api/MainTopic
        [HttpPost]
        public IActionResult CreateMainTopic([FromBody] MainTopic newMainTopic)
        {
            if (newMainTopic == null)
            {
                return BadRequest();
            }

            newMainTopic.CreatedDate = DateTime.Now;
            newMainTopic.CreatedUser = "User1"; // Kullanıcı adı oturumdan veya kimlik doğrulama ile alınabilir

            _context.MainTopics.Add(newMainTopic);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMainTopicById), new { id = newMainTopic.Id }, newMainTopic);
        }
        // Mevcut MainTopic verilerinin güncellenmesi gerektiğinde, örneğin başlık adında ya da içeriğinde bir değişiklik yapılması gerektiğinde kullanılır.
        // PUT: api/MainTopic/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMainTopic(int id, [FromBody] MainTopic updatedMainTopic)
        {
            if (updatedMainTopic == null || updatedMainTopic.Id != id)
            {
                return BadRequest();
            }

            var mainTopic = _context.MainTopics.Find(id);
            if (mainTopic == null)
            {
                return NotFound();
            }

            mainTopic.Tittle = updatedMainTopic.Tittle;
            mainTopic.UpdateDate = DateTime.Now;
            mainTopic.UpdateUser = "User1"; // Oturumdan alınabilir

            _context.MainTopics.Update(mainTopic);
            _context.SaveChanges();

            return NoContent();
        }
        //Artık geçerliliğini yitirmiş veya sistemden kaldırılması gereken MainTopic verilerini silmek için kullanılır.
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
