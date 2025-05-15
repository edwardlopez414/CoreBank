using CoreBankAPI.Models;
namespace CoreBankAPI.Logic.Interfaces
{
    public interface IUserManager
    {
        public(bool, ErrorModel, UserResponse)  Insert(UserDto model);
    }
}
