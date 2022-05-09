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
    public class TblusersController : ControllerBase
    {
        private readonly DBuserContext _context;

        public TblusersController(DBuserContext context)
        {
            _context = context;
        }

        // GET: api/Tblusers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tbluser>>> GetTbluser()
        {
            return await _context.Tbluser.ToListAsync();
        }

        // GET: api/Tblusers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tbluser>> GetTbluser(int id)
        {
            var tbluser = await _context.Tbluser.FindAsync(id);

            if (tbluser == null)
            {
                return NotFound();
            }

            return tbluser;
        }

        // PUT: api/Tblusers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbluser(int id, Tbluser tbluser)
        {
            if (id != tbluser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(tbluser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbluserExists(id))
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

        // POST: api/Tblusers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tbluser>> PostTbluser(Tbluser tbluser)
        {
            _context.Tbluser.Add(tbluser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbluser", new { id = tbluser.UserId }, tbluser);
        }

        // DELETE: api/Tblusers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tbluser>> DeleteTbluser(int id)
        {
            var tbluser = await _context.Tbluser.FindAsync(id);
            if (tbluser == null)
            {
                return NotFound();
            }

            _context.Tbluser.Remove(tbluser);
            await _context.SaveChangesAsync();

            return tbluser;
        }

        private bool TbluserExists(int id)
        {
            return _context.Tbluser.Any(e => e.UserId == id);
        }
    }
}
