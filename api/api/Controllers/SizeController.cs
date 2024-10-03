using api.Data;
using api.Dto;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SizeController : Controller
    {
        private readonly AppDbContext _context;
        public SizeController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SizeDto sizeDto)
        {
            if (string.IsNullOrEmpty(sizeDto.Name)) {
                return BadRequest("Tên không được để trống");
            }
            var newSize = new Size
            {
                Name = sizeDto.Name
            };
            _context.sizes.Add(newSize);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
