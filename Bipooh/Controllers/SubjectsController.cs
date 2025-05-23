using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bipooh.DataAccessLayer;

namespace Bipooh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly SubjectContext _context;

        public SubjectsController(SubjectContext context)
        {
            _context = context;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjectsItems()
        {
          if (_context.SubjectsItems == null)
          {
              return NotFound();
          }
            return await _context.SubjectsItems.ToListAsync();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(long id)
        {
          if (_context.SubjectsItems == null)
          {
              return NotFound();
          }
            var subject = await _context.SubjectsItems.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(long id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            _context.Entry(subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
          if (_context.SubjectsItems == null)
          {
              return Problem("Entity set 'SubjectContext.SubjectsItems'  is null.");
          }
            _context.SubjectsItems.Add(subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(long id)
        {
            if (_context.SubjectsItems == null)
            {
                return NotFound();
            }
            var subject = await _context.SubjectsItems.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            _context.SubjectsItems.Remove(subject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectExists(long id)
        {
            return (_context.SubjectsItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
