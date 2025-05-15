using CoreBankAPI.Models;

namespace CoreBankAPI.Logic.Interfaces
{
    public interface IAccountManager
    {
        public (bool, ErrorModel, AccountResponse) insert(AccountDto model);
        public (bool, ErrorModel, BalanceResponse) balance(BalanceDto model);
    }
}
