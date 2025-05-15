using CoreBankAPI.Models;

namespace CoreBankAPI.Logic.Validator
{
    public class ValidateRequest
    {
        #region Validaciones para TransactionManager
        public (bool, ErrorModel) validateModel(TransactionDto model)
        {
            ErrorModel error = new ErrorModel();

            if (string.IsNullOrEmpty(model.Identifier))
            {
                error.status = "required field";
                error.text = "the field identifier is required";
                return (true, error);
            }
            if (model.Amount < 0)
            {
                error.status = "required field";
                error.text = "the field amount must be greater than zero";
                return (true, error);
            }
            return (false, error);
        }
        public (bool, ErrorModel) validateModel(TransactionHistoryDto model)
        {
            ErrorModel error = new ErrorModel();

            if (string.IsNullOrEmpty(model.Identifier))
            {
                error.status = "required field";
                error.text = "the field identifier is required";
                return (true, error);
            }
            return (false, error);
        }
        #endregion
        #region Validaciones para UserManager
        public (bool, ErrorModel) ValidateModel(UserDto model)
        {
            ErrorModel error = new ErrorModel();
            if (string.IsNullOrEmpty(model.FirstName))
            {
                error.status = "required field";
                error.text = "the field FirstName is required";
                return (true, error);
            }
            if (string.IsNullOrEmpty(model.MiddleName))
            {
                error.status = "required field";
                error.text = "the field MiddleName is required";
                return (true, error);
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                error.status = "required field";
                error.text = "the field LastName is required";
                return (true, error);
            }
            if (string.IsNullOrEmpty(model.LastName2))
            {
                error.status = "required field";
                error.text = "the field LastName2 is required";
                return (true, error);
            }
            if (string.IsNullOrEmpty(model.Idtype))
            {
                error.status = "required field";
                error.text = "the field Idtype is required";
                return (true, error);
            }
            if (string.IsNullOrEmpty(model.Idnumber))
            {
                error.status = "required field";
                error.text = "the field Idnumber is required";
                return (true, error);
            }
            if (string.IsNullOrEmpty(model.Gender))
            {
                error.status = "required field";
                error.text = "the field Gender is required";
                return (true, error);
            }
            if (model.Income < 0)
            {
                error.status = "required field";
                error.text = "the field Income must be greater than zero";
                return (true, error);
            }


            return (false, error);
        }
        #endregion
        #region validacion de request de AccountManager
        public (bool, ErrorModel) validateModel(AccountDto model)
        {
            ErrorModel error = new ErrorModel();

            if (model.InitialBalance < 0)
            {
                error.status = "required field";
                error.text = "the field InitialBalance must be greater than zero";
                return (true, error);
            }
            return (false, error);
        }
        #endregion
    }
}
