using Deportivo.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Deportivo.Web.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ACalendarController : ControllerBase
    {
        private readonly DataContext _context;

        public ACalendarController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Fulleventos()
        {
            var events = await _context.eventos.Select(e => new
            {
                id = e.id,
                title = e.title,
                description = e.Description,
                start = e.start.ToString("yyyy-MM-ddTHH:mm:ss"),
                end = e.end.ToString("yyyy-MM-ddTHH:mm:ss"),
                Alldays = false
            }).ToListAsync();
            return new JsonResult(events);
        }
    }
}
