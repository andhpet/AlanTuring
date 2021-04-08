using System;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AlanTuring.Models;

namespace AlanTuring.Controllers
{
    [Route("/api")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private readonly Alan_TuringContext dataContext;

        public LogInController(Alan_TuringContext dataContext)
        {
            this.dataContext = dataContext;
        }

        #region LogIn
        /// <summary>
        /// User log in 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User object and session Id</returns>
        [Route("LogIn")]
        [HttpPost]
        public ActionResult<User> LogIn(User user)
        {
            var currentUser = dataContext.Users.FirstOrDefault(u => user.Mail == u.Mail && user.Password == u.Password);

            if (currentUser != null)
            {
                var usersClaim = new List<Claim>()
                {
                    new Claim (ClaimTypes.Name, user.Mail)
                };

                var grandmaIntentity = new ClaimsIdentity(usersClaim, "Users Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIntentity });
                HttpContext.Session.SetString("SessionId", currentUser.Id.ToString());
                var sessionId = HttpContext.Session.GetString("SessionId");

                return Ok(sessionId);
            }

            return Unauthorized();
        }
        #endregion

        #region LogOut
        /// <summary>
        /// Log out and delete session
        /// </summary>
        /// <returns></returns>
        [Route("LogOut")]
        [HttpPost]
        public ActionResult<User> LogOut()
        {
            HttpContext.Session.Clear();
            return Ok();
        }
        #endregion

        #region Validation
        /// <summary>
        /// Validates session Id
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns>User object</returns>
        [Route("Validate")]
        [HttpPost]
        public ActionResult<User> Validate(string sessionId)
        {
            var user = (from elm in dataContext.Users
                        where elm.Id == Int32.Parse(sessionId)
                        select elm).FirstOrDefault();

            return Ok(user);
        }
        #endregion
    }
}
