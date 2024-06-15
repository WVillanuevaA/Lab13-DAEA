﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab13S13.Models;

namespace Lab13S13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly DbSemana13 _context;

        public DetailsController(DbSemana13 context)
        {
            _context = context;
        }

        // GET: api/Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Details>>> GetDetails()
        {
          if (_context.Details == null)
          {
              return NotFound();
          }
            return await _context.Details.ToListAsync();
        }

        // GET: api/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Details>> GetDetails(int id)
        {
          if (_context.Details == null)
          {
              return NotFound();
          }
            var details = await _context.Details.FindAsync(id);

            if (details == null)
            {
                return NotFound();
            }

            return details;
        }

        // PUT: api/Details/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetails(int id, Details details)
        {
            if (id != details.DetailsID)
            {
                return BadRequest();
            }

            _context.Entry(details).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailsExists(id))
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

        // POST: api/Details
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Details>> PostDetails(Details details)
        {
          if (_context.Details == null)
          {
              return Problem("Entity set 'DbSemana13.Details'  is null.");
          }
            _context.Details.Add(details);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetails", new { id = details.DetailsID }, details);
        }

        // DELETE: api/Details/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetails(int id)
        {
            if (_context.Details == null)
            {
                return NotFound();
            }
            var details = await _context.Details.FindAsync(id);
            if (details == null)
            {
                return NotFound();
            }

            _context.Details.Remove(details);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetailsExists(int id)
        {
            return (_context.Details?.Any(e => e.DetailsID == id)).GetValueOrDefault();
        }
    }
}
