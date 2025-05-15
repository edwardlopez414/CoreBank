using CoreBankAPI.CoreDbContext;
using CoreBankAPI.Data;
using CoreBankAPI.Logic.Interfaces;

namespace CoreBankAPI.Logic
{
    public class TransactionRepository : ITransactionRepository
    {
        CoreDb db;
        public TransactionRepository(CoreDb db) 
        {
            this.db = db;
        }
        public void Add(TransactionDta transaction)
        {
            db.TransactionDta.Add(transaction);
        }

        public List<TransactionDta> GetByAccountId(int accountId)
        {
            return db.TransactionDta.Where(a => a.AccountId == accountId).ToList();
        }
    }
}
