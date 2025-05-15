using CoreBankAPI.Models;

namespace CoreBankAPI.Logic.Interfaces
{
    public interface ITransacionManager
    {
        public (bool, ErrorModel,TransactionResponse) deposit(TransactionDto model);
        public (bool, ErrorModel,TransactionResponse) withdrawals(TransactionDto model);
        public (bool, ErrorModel, HistoryResponse) history(TransactionHistoryDto model);
    }
}
