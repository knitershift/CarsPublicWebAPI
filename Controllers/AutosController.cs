using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarsAPI.Models;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutosController : ControllerBase
    {
        private readonly AutoDbContext _context;

        public AutosController(AutoDbContext context)
        {
            _context = context;
        }

        // GET: api/Autos
        [HttpGet]
        public IEnumerable<Auto> GetAutos()
        {
            return _context.Autos;
        }

        // GET: api/Autos/5
        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetAuto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var auto = await _context.Autos.FindAsync(id);

            if (auto == null)
            {
                return NotFound();
            }

            return Ok(auto);
        }

        // PUT: api/Autos/5
        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> PutAuto([FromRoute] int id, [FromBody] Auto auto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != auto.Id)
            {
                return BadRequest();
            }

            _context.Entry(auto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Autos
        [HttpPost]
        public async Task<IActionResult> PostAuto([FromBody] Auto auto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Autos.Add(auto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuto", new { id = auto.Id }, auto);
        }

        // DELETE: api/Autos/5
        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteAuto([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var auto = await _context.Autos.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }

            _context.Autos.Remove(auto);
            await _context.SaveChangesAsync();

            return Ok(auto);
        }

        private bool AutoExists(int id)
        {
            return _context.Autos.Any(e => e.Id == id);
        }
    }
}