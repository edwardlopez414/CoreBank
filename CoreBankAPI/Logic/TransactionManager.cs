using CoreBankAPI.CoreDbContext;
using CoreBankAPI.Data;
using CoreBankAPI.Logic.Interfaces;
using CoreBankAPI.Models;
using CoreBankAPI.Logic.Validator;

namespace CoreBankAPI.Logic
{
    public class TransactionManager : ITransacionManager
    {
        CoreDb db;
        ValidateRequest ValRequest = new ValidateRequest();
        ITransactionRepository _transactionRepository;
        IAccountRepository _accountRepository;
        private static readonly Random _random = new();
        public TransactionManager(CoreDb db, ValidateRequest ValRequest, ITransactionRepository _transactionRepository, IAccountRepository _accountRepository)
        {
            this.db = db;
            this.ValRequest = ValRequest;
            this._accountRepository = _accountRepository;
            this._transactionRepository = _transactionRepository;
        }
        public (bool, ErrorModel, TransactionResponse) deposit(TransactionDto model)
        {
            return ProcessTransaction(
                                        model,
                                        "DEPOSIT",
                                        (balance, amount) => true, // siempre permitido
                                        (balance, amount) => balance + amount
                                      );
        }

        public (bool, ErrorModel, TransactionResponse) withdrawals(TransactionDto model)
        {
            return ProcessTransaction(
                                      model,
                                      "WITHDRAWALS",
                                      (balance, amount) => balance >= amount,
                                      (balance, amount) => balance - amount
                                      );
        }

        public (bool, ErrorModel, HistoryResponse) history(TransactionHistoryDto model)
        {
            HistoryResponse response = new HistoryResponse();
            try
            {           
                response.Details = new List<HistoryInfo>();

                (bool iserror, var error) = ValRequest.validateModel(model);
                if (iserror) return (true, error, response);

                //agregamos la cantidad al monto actual 
                var account = _accountRepository.GetByIdentifier(model.Identifier!);

                var History = _transactionRepository.GetByAccountId(account!.Id);

                if (History != null)
                {

                    foreach (var item in History)
                    {
                        response.Details.Add(new HistoryInfo
                        {
                            Account = model.Identifier,
                            Type = item.Type,
                            TransactionAmount = item.Amount,
                            Descriptio = item.Description!,
                            Identifier = item.identifier
                        });
                    }
                    response.AccountBalance = account.Balance;

                    return (false, error, response);
                }
                else
                {
                    //el cliente no tiene transacciones
                    return (false, error, response);
                }
            }
            catch (Exception ex) 
            {
                ErrorModel error = new ErrorModel
                {
                    status = "error",
                    text = $"Transaction failed: {ex.Message}"
                };
                return (true, error, response);
            }
        }
    
        private (bool, ErrorModel, TransactionResponse) ProcessTransaction(TransactionDto model,string type,Func<decimal, decimal, bool> condition,Func<decimal, decimal, decimal> operation)
        {
            TransactionResponse response = new TransactionResponse();
            try
            {
                (bool iserror, var error) = ValRequest.validateModel(model);
                if (iserror) return (true, error, response);

                var account = _accountRepository.GetByIdentifier(model.Identifier!);
                if (account == null)
                {
                    error = new ErrorModel
                    {
                        status = "not found",
                        text = "Account not found"
                    };
                    return (true, error, response);
                }

                if (!condition(account.Balance, model.Amount))
                {
                    error = new ErrorModel
                    {
                        status = "insufficient funds",
                        text = "Insufficient balance"
                    };
                    return (true, error, response);
                }

                account.Balance = operation(account.Balance, model.Amount);
                _accountRepository.add(account);

                var transaction = new TransactionDta
                {
                    AccountId = account.Id,
                    Type = type,
                    Amount = model.Amount,
                    Description = model.Description,
                    Registered = DateTime.Now,
                    Isreversed = false,
                    identifier = Generate()
                };
                _transactionRepository.Add(transaction);
                db.SaveChanges();

                response = new TransactionResponse
                {
                    Status = "completed",
                    Account = account.identifier,
                    BalanceAccount = account.Balance,
                    TransactionAmount = model.Amount,
                    identifier = transaction.identifier
                };

                return (false, error, response);
            }
            catch (Exception ex) 
            {
            ErrorModel error = new ErrorModel
            {
              status = "error",
              text = $"Transaction failed: {ex.Message}"
            };
             return (true, error, response);
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
