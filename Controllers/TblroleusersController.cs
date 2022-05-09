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
    public class TblroleusersController : ControllerBase
    {
        private readonly DBuserContext _context;

        public TblroleusersController(DBuserContext context)
        {
            _context = context;
        }

        // GET: api/Tblroleusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblroleuser>>> GetTblroleuser()
        {
            return await _context.Tblroleuser.ToListAsync();
        }

        // GET: api/Tblroleusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tblroleuser>> GetTblroleuser(int id)
        {
            var tblroleuser = await _context.Tblroleuser.FindAsync(id);

            if (tblroleuser == null)
            {
                return NotFound();
            }

            return tblroleuser;
        }

        // PUT: api/Tblroleusers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblroleuser(int id, Tblroleuser tblroleuser)
        {
            if (id != tblroleuser.UserRoleId)
            {
                return BadRequest();
            }

            _context.Entry(tblroleuser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblroleuserExists(id))
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

        // POST: api/Tblroleusers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tblroleuser>> PostTblroleuser(Tblroleuser tblroleuser)
        {
            _context.Tblroleuser.Add(tblroleuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblroleuser", new { id = tblroleuser.UserRoleId }, tblroleuser);
        }

        // DELETE: api/Tblroleusers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tblroleuser>> DeleteTblroleuser(int id)
        {
            var tblroleuser = await _context.Tblroleuser.FindAsync(id);
            if (tblroleuser == null)
            {
                return NotFound();
            }

            _context.Tblroleuser.Remove(tblroleuser);
            await _context.SaveChangesAsync();

            return tblroleuser;
        }

        private bool TblroleuserExists(int id)
        {
            return _context.Tblroleuser.Any(e => e.UserRoleId == id);
        }
    }
}
