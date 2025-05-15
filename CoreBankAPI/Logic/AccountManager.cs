using CoreBankAPI.CoreDbContext;
using CoreBankAPI.Data;
using CoreBankAPI.Logic.Interfaces;
using CoreBankAPI.Logic.Validator;
using CoreBankAPI.Models;

namespace CoreBankAPI.Logic
{
    public class AccountManager : IAccountManager
    {
        CoreDb db;
        private static readonly Random _random = new();
        IUserRepository _userRepository;
        IAccountRepository _accountRepository;
        ValidateRequest validate;
        public AccountManager(CoreDb db, IUserRepository _userRepository, IAccountRepository _accountRepository, ValidateRequest validate) 
        {
            this.db = db;
            this._userRepository = _userRepository;
            this._accountRepository = _accountRepository;
            this.validate = validate;
        }
        public (bool, ErrorModel, BalanceResponse) balance(BalanceDto model)
        {
            ErrorModel error = new ErrorModel();
            var account = _accountRepository.GetByIdentifier(model.identifier!);

            BalanceResponse response = new BalanceResponse();

            if (account != null)
            {
                response = new BalanceResponse
                {
                    identifier = model.identifier,
                    UserId = account.UserId,
                    Balance = account.Balance,
                    Currency = account.Currency,
                    Isactive = account.Isactive,
                    Registered = account.Registered
                };

                return (false, error, response);
            }
            else
            {
                error = new ErrorModel
                {
                    status = "error in balance query",
                    text = "Please validate the account and try again."
                };
                return (true, error, response);
            }
        }

        public (bool, ErrorModel, AccountResponse) insert(AccountDto model)
        {
            AccountResponse response = new AccountResponse();

            try
            {
                (bool validatereq, var error) = validate.validateModel(model);
                if (validatereq) return (true, error, response);

                var userId = _userRepository.GetById(model.UserId);
                if (userId == null)
                {
                    error.status = "user not found";
                    error.text = "validate UserId";

                    return (true, error, response);
                }

                AccoutDta account = new AccoutDta
                {
                    identifier = Generate(),
                    UserId = userId.Id,
                    Currency = "NIO",
                    Balance = model.InitialBalance,
                    Registered = DateTime.Now,
                    Isactive = true,
                };

                _accountRepository.add(account);
                db.SaveChanges();

                response = new AccountResponse
                {
                    Identifier = account.identifier,
                    Balance = account.Balance
                };

                return (false, error, response);
            }
            catch (Exception ex) 
            {
                ErrorModel errorInaccount = new ErrorModel
                {
                    status = "error",
                    text = $"Transaction failed: {ex.Message}"
                };
                return (true, errorInaccount, response);
            }

        }
        public static string Generate()
        {
            char firstLetter = (char)_random.Next('A', 'Z' + 1);
            int number = _random.Next(10000, 99999); // 5 dígitos
            char lastLetter = (char)_random.Next('A', 'Z' + 1);

            return $"{firstLetter}{number}{lastLetter}";
        }
    }
}
