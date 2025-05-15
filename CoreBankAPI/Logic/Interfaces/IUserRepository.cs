using CoreBankAPI.Data;

namespace CoreBankAPI.Logic.Interfaces
{
    public interface IUserRepository
    {
        UserDta GetByIdNumber(string IdNumber, string IdType);
        UserDta GetById(int Id);
        void add(UserDta model);
    }
}
