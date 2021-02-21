using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlanTuring.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlanTuring.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Alan_TuringContext _DB;
        public UserController(Alan_TuringContext DB)
        {
            _DB = DB;

            if (_DB.Users.Count() == 0)
            {
                // Create a new User if collection is empty,
                _DB.Users.Add(new User { Mail = "john.smith@email.com", Password = "0000" });
                _DB.SaveChanges();
            }
        }

        #region Create
        [HttpPost]
        public async Task<ActionResult<User>> PostUserItem(User item)
        {
            var check = (from elm in _DB.Users
                        where elm.Mail == item.Mail
                        select elm).Count();
            if (check > 0)
            {
                return Conflict();
            }
            else
            {
                _DB.Users.Add(item);
                await _DB.SaveChangesAsync();

                SendEmail.SendRegistrationEmail(item.Mail);

                return CreatedAtAction(nameof(GetUserItem), new { id = item.Id }, item);
            }
        }
        #endregion

        #region Read
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserItems()
        {
            return await _DB.Users.ToListAsync();
        }
        #endregion

        #region ReadById
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserItem(int id)
        {
            var user = await _DB.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserItem(int id, User item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _DB.Entry(item).State = EntityState.Modified;
            await _DB.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableUserItem(int id)
        {
            var user = await _DB.Users.FindAsync(id);

            if (id != user.Id)
            {
                return BadRequest();
            }

            user.Status = false;
            await _DB.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}