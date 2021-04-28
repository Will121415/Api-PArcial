using apiParcial.models;
using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace apiParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        private UserService _userService;
        public LoginController(ParcialContext context)
        {
	        _userService = new UserService(context);
        }

        [HttpPost]
        public IActionResult Login(LoginInputModel model)
        {
            var user = _userService.Login(model.UserName, model.Password);
            if (user == null) return BadRequest("Username or password is incorrect");
            return Ok(user.Object);
        }
    }
}