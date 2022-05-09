using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicleassignment4.Models;

namespace practicleassignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblrolesController : ControllerBase
    {
        private readonly DBuserContext _context;

        public TblrolesController(DBuserContext context)
        {
            _context = context;
        }

        // GET: api/Tblroles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblrole>>> GetTblrole()
        {
            return await _context.Tblrole.ToListAsync();
        }

        // GET: api/Tblroles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tblrole>> GetTblrole(int id)
        {
            var tblrole = await _context.Tblrole.FindAsync(id);

            if (tblrole == null)
            {
                return NotFound();
            }

            return tblrole;
        }

        // PUT: api/Tblroles/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblrole(int id, Tblrole tblrole)
        {
            if (id != tblrole.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(tblrole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblroleExists(id))
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

        // POST: api/Tblroles
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tblrole>> PostTblrole(Tblrole tblrole)
        {
            _context.Tblrole.Add(tblrole);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblroleExists(tblrole.RoleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblrole", new { id = tblrole.RoleId }, tblrole);
        }

        // DELETE: api/Tblroles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tblrole>> DeleteTblrole(int id)
        {
            var tblrole = await _context.Tblrole.FindAsync(id);
            if (tblrole == null)
            {
                return NotFound();
            }

            _context.Tblrole.Remove(tblrole);
            await _context.SaveChangesAsync();

            return tblrole;
        }

        private bool TblroleExists(int id)
        {
            return _context.Tblrole.Any(e => e.RoleId == id);
        }
    }
}
