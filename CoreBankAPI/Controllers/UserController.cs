using CoreBankAPI.CoreDbContext;
using CoreBankAPI.Logic.Interfaces;
using CoreBankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            this._userManager = userManager;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult create(UserDto model)
        {
            (bool errorInsert, var error, var response) = _userManager.Insert(model);

            if(errorInsert) return BadRequest(error);

            return Ok(response);
        }
    }
}
