using CoreBankAPI.Data;

namespace CoreBankAPI.Logic.Interfaces
{
    public interface ITransactionRepository
    {
        void Add(TransactionDta transaction);
        List<TransactionDta> GetByAccountId(int accountId);
    }
}
