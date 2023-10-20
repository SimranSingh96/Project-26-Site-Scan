using Microsoft.AspNetCore.Mvc;
using SiteScanAPI.Model;
using SiteScanAPI.Services;

namespace SiteScanAPI.Controllers
{
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all-users")]
        public IActionResult GetAllUser()
        {
            try
            {
                var users = _userService.GetUsersList();
                if (users == null) return NotFound();
                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get user details by email
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{userEmail}")]
        public IActionResult GetUserById(string userEmail)
        {
            try
            {
                var user = _userService.GetUserDetailsById(userEmail);
                if (user == null) return NotFound("Opps! No user found");
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// create user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser([FromBody] User userModel)
        {
            try
            {
                bool result = _userService.SaveUser(userModel);
                if (!result) return BadRequest("Oops! unable to save user details");
                return Ok("User data saved Successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{userEmail}")]
        public IActionResult DeleteEmployee(string userEmail)
        {
            try
            {
                bool result = _userService.DeleteUser(userEmail);
                if (!result) return BadRequest("Oops! unable to delete  user");
                return Ok("User deleted Successfully");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
