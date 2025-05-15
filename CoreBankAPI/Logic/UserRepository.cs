using CoreBankAPI.CoreDbContext;
using CoreBankAPI.Data;
using CoreBankAPI.Logic.Interfaces;

namespace CoreBankAPI.Logic
{
    public class UserRepository : IUserRepository
    {
        CoreDb db;
        public UserRepository(CoreDb db)
        {
            this.db = db;
        }
        public UserDta GetByIdNumber(string IdNumber, string IdType)
        {
            return db.UserDta.FirstOrDefault(a => a.Idnumber == IdNumber && a.Idtype == IdType)!;
        }

        public void add(UserDta model)
        {
            db.UserDta.Add(model);
        }

        UserDta IUserRepository.GetById(int Id)
        {
            return db.UserDta.FirstOrDefault(a => a.Id == Id)!;
        }
    }
}
