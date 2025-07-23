using EasyKeep.Data;
using EasyKeep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyKeep.Controllers
{
    [Route("api/asset")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AssetController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assets = await _context.Assets.ToListAsync();
            return Ok(assets);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset == null)
            {
                return NotFound();
            }
            return Ok(asset);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Asset? asset)
        {
            if (asset == null)
            {
                return BadRequest("Asset cannot be null");
            }
            
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = asset.Id }, asset);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Asset asset)
        {
            if (id != asset.Id)
            {
                return BadRequest("Asset ID mismatch");
            }
            
            var existingAsset = await _context.Assets.FindAsync(id);
            if (existingAsset == null)
            {
                return NotFound();
            }
            
            existingAsset.AssetCode = asset.AssetCode;
            existingAsset.Name = asset.Name;
            existingAsset.Description = asset.Description;
            existingAsset.Category = asset.Category;
            existingAsset.Location = asset.Location;
            existingAsset.Status = asset.Status;

            _context.Assets.Update(existingAsset);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
