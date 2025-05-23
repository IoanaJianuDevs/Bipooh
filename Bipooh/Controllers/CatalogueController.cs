using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bipooh.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Bipooh.Services;
using Bipooh.DataAccessLayer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bipooh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {

        private readonly CatalogueContext _context;
        public CatalogueController(CatalogueContext context) { _context = context; }

        // GET: api/<CatalogueController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET api/<CatalogueController>/5
        [HttpGet("{name}")]
        public async Task<ActionResult<List<Catalogue>>> GetCatalogueByStudentName(string name)
        {

            if (_context.CatalogueItems == null)
            {
                return NotFound();
            }

            var catalogue = await _context.CatalogueItems.Include(c => c.students.Where(c => (bool)c.FirstName.StartsWith(name) || (bool)c.LastName.StartsWith(name))).ToListAsync();
            return Ok(catalogue);
        }

        // POST: api/Catalogues
       // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Catalogue>> PostCatalogue(Catalogue catalogue)
        {
            if (_context.CatalogueItems == null)
            {
                return Problem("Entity set 'CatalogueContext.CatalogueItems'  is null.");
            }

            _context.CatalogueItems.Add(catalogue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalog", new { id = catalogue.Id }, catalogue);
        }
    }
}
