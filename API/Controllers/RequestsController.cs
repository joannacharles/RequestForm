using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestsController : ControllerBase
    {
        private readonly DataContext _context;
        public RequestsController(DataContext context)
        {
            this._context=context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppRequest>>> GetRequests()
        {
            var requests = await _context.Requests.OrderBy(r => r.DueDate).ToListAsync();
            return Ok(requests);
        }
        [HttpPost]
        public async Task<ActionResult> CreateRequest(AppRequest model)
        {
            try
            {
            
            _context.Add(model);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRequestById), new { id = model.Id }, model);
;
            }
            catch(Exception E){
                  return BadRequest(new { errors = E.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppRequest>> GetRequestById(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }
    }
}