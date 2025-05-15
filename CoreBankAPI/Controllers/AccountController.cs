using CoreBankAPI.Logic.Interfaces;
using CoreBankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountManager _accountManager;
        public AccountController(IAccountManager _accountManager) 
        {
            this._accountManager = _accountManager;
        }
        [HttpPost]
        [Route("create")]
        public IActionResult create(AccountDto model)
        {
            (bool iserror, var error, var response) = _accountManager.insert(model);
            if (iserror) return BadRequest(error);

            return Ok(response);
        }
        [HttpPost]
        [Route("balance")]
        public IActionResult balance(BalanceDto model)
        {
            (bool iserror, var error, var response) = _accountManager.balance(model);
            if (iserror) return BadRequest(error);

            return Ok(response);
        }
    }
}
