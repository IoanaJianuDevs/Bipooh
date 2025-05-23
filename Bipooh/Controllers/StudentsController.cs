﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bipooh.DataAccessLayer;
using Bipooh.Handler;
using Bipooh.Models;

namespace Bipooh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentContext _context;
        private APIRequestHandler aPIRequestHandler;
        School school = null;
        public StudentsController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentItems()
        {
          if (_context.StudentItems == null)
          {
              return NotFound();
          }
            return await _context.StudentItems.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(long id)
        {
          if (_context.StudentItems == null)
          {
              return NotFound();
          }
            var student = await _context.StudentItems.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(long id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
          if (_context.StudentItems == null)
          {
              return Problem("Entity set 'StudentContext.StudentItems'  is null.");
          }
          if(!string.IsNullOrEmpty(student.SchoolName)) 
            {
                aPIRequestHandler = new APIRequestHandler();
                school = aPIRequestHandler.SearchSchoolByName(student.SchoolName);  
                school.StudentID = student.Id;
            }
            _context.StudentItems.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(long id)
        {
            if (_context.StudentItems == null)
            {
                return NotFound();
            }
            var student = await _context.StudentItems.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.StudentItems.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(long id)
        {
            return (_context.StudentItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
