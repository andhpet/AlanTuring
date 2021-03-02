using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlanTuring.Models;
using AlanTuring.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlanTuring.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Alan_TuringContext dataContext;
        private readonly IMailer _mailer;
        public UserController(Alan_TuringContext DataContext, IMailer mailer)
        {
            dataContext = DataContext;
            _mailer = mailer;
        }

        #region Create
        /// <summary>
        /// Adds new user
        /// </summary>
        /// <param name="item"></param>
        /// <returns>User object</returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUserItem(User item)
        {
            var userExists = (from elm in dataContext.Users
                              where elm.Mail == item.Mail
                              select elm).Any();
            if (userExists)
            {
                return Conflict();
            }
            else
            {
                dataContext.Users.Add(item);
                await dataContext.SaveChangesAsync();

                ///After saving Item object in data context Send email to user 
                bool isMailSent = await _mailer.SendEmailAsync(item.Mail, "Weather Report", "Detailed Weather Report");

                if (isMailSent)
                {
                    return CreatedAtAction(nameof(GetUserItem), new { id = item.Id }, item);
                }
                else
                {
                    dataContext.Users.Remove(item);
                    await dataContext.SaveChangesAsync();

                    return BadRequest();
                }
            }
        }
        #endregion

        #region Read
        /// <summary>
        /// Get all users
        /// https://localhost:44321/User
        /// </summary>
        /// <returns>Returns all users available</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserItems()
        {
            return await dataContext.Users.ToListAsync();
        }
        #endregion

        #region ReadById
        /// <summary>
        /// Get user by id
        /// https://localhost:44321/User/{id}/
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns user object with given id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserItem(int id)
        {
            var user = await dataContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        #endregion

        #region Update
        /// <summary>
        /// Change user proparties based on user id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>Status code: 204 - No Content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserItem(int id, User item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            dataContext.Entry(item).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();

            return Ok();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Changes the user status to 'false', which means that the user cannot log in until the status changes back to 'true'.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Status code: 204 - No Content
        /// Status code: 404 - Not Found
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableUserItem(int id)
        {
            var user = await dataContext.Users.FindAsync(id);

            if (id != user?.Id)
            {
                return NotFound();
            }

            user.Status = false;
            await dataContext.SaveChangesAsync();

            return NoContent();
        }
        #endregion
    }
}