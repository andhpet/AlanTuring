using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlanTuring.Models;
using AlanTuring.Services;

namespace AlanTuring.Controllers
{
    [Route("/api")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Alan_TuringContext dataContext;
        private readonly IMailer mailer;

        public UsersController(Alan_TuringContext dataContext, IMailer mailer)
        {
            this.dataContext = dataContext;
            this.mailer = mailer;
        }

        #region RegisterUser
        /// <summary>
        /// Adds new user
        /// </summary>
        /// <param name="applicant"></param>
        /// <returns>User object</returns>
        [Route("RegisterUser")]
        [HttpPost]
        public async Task<ActionResult<User>> RegisterUser(User applicant)
        {
            var userExists = (from elm in dataContext.Users
                              where elm.Mail == applicant.Mail
                              select elm).Any();
            if (userExists)
            {
                return Conflict();
            }
            else
            {
                dataContext.Users.Add(applicant);
                await dataContext.SaveChangesAsync();

                ///After saving Item object in data context Send email to user 
                //bool isMailSent = await mailer.SendEmailAsync(applicant.Mail, "Weather Report", "Detailed Weather Report");

                //if (isMailSent)
                //{
                //    return CreatedAtAction(nameof(GetUser), new { id = applicant.Id }, applicant);
                //}
                //else
                //{
                //    dataContext.Users.Remove(applicant);
                //    await dataContext.SaveChangesAsync();
                //    return CreatedAtAction(nameof(GetUser), new { id = applicant.Id }, applicant);

                //    // return BadRequest();
                //}

                return Ok();
            }
        }
        #endregion

        #region GetAllUsers
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>Returns all users available</returns>
        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await dataContext.Users.ToListAsync();
        }
        #endregion

        #region GetUser
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns user object with given id</returns>
        [Route("GetUser")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUser(User user)
        {
            var person = await dataContext.Users.FindAsync(user.Id);
            if (person == null)
            {
                return NotFound();
            }
            return person;
        }
        ///delete this method after adding filter functionality for get all users method
        #endregion

        #region UpdateUser
        /// <summary>
        /// Change user proparties based on user id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>Status code: 204 - No Content</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User item)
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

        #region DisableUser
        /// <summary>
        /// Changes the user status to 'false', which means that the user cannot log in until the status changes back to 'true'.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Status code: 204 - No Content
        /// Status code: 404 - Not Found
        /// </returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DisableUser(int id)
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