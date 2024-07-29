using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using User_api.Data;

namespace User_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRespository _userRespository;
        public UserController(UserRespository userRespository) {
            _userRespository = userRespository;
        }
        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] User model)
        {
            await _userRespository.AddUser(model);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetUserList()
        {
            var userlist = await _userRespository.GetUserList();
            return Ok(userlist);
        }
        [HttpGet("{user_name}")]
        public async Task<ActionResult> UserByUser_name([FromRoute] string user_name)
        {
            var users = await _userRespository.UserByUser_nam(user_name);
            if (users == null)
            {
                return NotFound(new { message = "user not found" });
            }
            return Ok(users);
        }
        [HttpPut("{user_name}")]
        public async Task<ActionResult> UpdateUser([FromRoute] string user_name, [FromBody] User model)
        {
            await _userRespository.UpdateUser(user_name, model);
            return Ok();
        }
        [HttpDelete("{user_name}")]
        public async Task<ActionResult> DeleteUsers([FromRoute] string user_name)
        {
            await _userRespository.DeleteUser(user_name);
            return Ok();
        }
    }
}
    