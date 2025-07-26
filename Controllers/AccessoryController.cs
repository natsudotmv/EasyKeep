using EasyKeep.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyKeep.Models;

namespace EasyKeep.Controllers
{
    [Route("api/accessory")]
    [ApiController]
    public class AccessoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public AccessoryController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accessories = await _context.Accessories.ToListAsync();
            return Ok(accessories);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var accessory = await _context.Accessories.FindAsync(id);
            if (accessory == null)
            {
                return NotFound();
            }
            return Ok(accessory);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Accessory? accessory)
        {
            if (accessory == null)
            {
                return BadRequest("Accessory cannot be null");
            }
            
            _context.Accessories.Add(accessory);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = accessory.Id }, accessory);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Accessory accessory)
        {
            if (id != accessory.Id)
            {
                return BadRequest("Accessory ID mismatch");
            }
            
            var existingAccessory = await _context.Accessories.FindAsync(id);
            if (existingAccessory == null)
            {
                return NotFound();
            }
            
            existingAccessory.Name = accessory.Name;
            existingAccessory.Description = accessory.Description;
            existingAccessory.CreatedBy = accessory.CreatedBy;
            existingAccessory.CreatedAt = accessory.CreatedAt;
            existingAccessory.AssetId = accessory.AssetId;

            _context.Accessories.Update(existingAccessory);
            await _context.SaveChangesAsync();
            
            return Ok(existingAccessory);
        }
    }
}
