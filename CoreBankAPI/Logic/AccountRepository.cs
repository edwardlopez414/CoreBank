using CoreBankAPI.CoreDbContext;
using CoreBankAPI.Data;
using CoreBankAPI.Logic.Interfaces;

namespace CoreBankAPI.Logic
{
    public class AccountRepository : IAccountRepository
    {
        CoreDb db;
        public AccountRepository(CoreDb db) 
        {
            this.db = db;
        }
        public AccoutDta? GetByIdentifier(string identifier)
        {
            return db.AccountDta.FirstOrDefault(a => a.identifier == identifier);
        }

        public void add(AccoutDta account)
        {
            db.AccountDta.Update(account);
        }

    }
}
