using CoreBankAPI.Logic.Interfaces;
using CoreBankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreBankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ITransacionManager _transactionManager;
        public TransactionController(ITransacionManager _transactionManager) 
        {
            this._transactionManager = _transactionManager;
        }

        [HttpPost]
        [Route("deposits")]
        public IActionResult deposits(TransactionDto model)
        {
            (bool validateDeposit, var error, var response) = _transactionManager.deposit(model);
            if (validateDeposit) return BadRequest(error);

            return Ok(response);
        }
        [HttpPost]
        [Route("withdrawals")]
        public IActionResult withdrawals(TransactionDto model)
        {
            (bool validateDeposit, var error, var response) = _transactionManager.withdrawals(model);
            if (validateDeposit) return BadRequest(error);

            return Ok(response);
        }
        [HttpPost]
        [Route("history")]
        public IActionResult history(TransactionHistoryDto model)
        {
            (bool validateDeposit, var error, var response) = _transactionManager.history(model);
            if (validateDeposit) return BadRequest(error);

            return Ok(response);
        }
    }
}
