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
        public async Task<ActionResult<IEnumerable<AppRequest>>> CreateRequest()
        {
            var requests = await _context.Requests.OrderBy(r => r.DueDate).ToListAsync();
            return Ok(requests);
        }
    }
}