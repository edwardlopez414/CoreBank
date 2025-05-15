using CoreBankAPI.Data;
namespace CoreBankAPI.Logic.Interfaces
{
    public interface IAccountRepository
    {
        AccoutDta? GetByIdentifier(string identifier);   

        void add(AccoutDta account);
    }
}
