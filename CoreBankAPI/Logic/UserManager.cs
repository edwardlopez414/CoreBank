using CoreBankAPI.CoreDbContext;
using CoreBankAPI.Data;
using CoreBankAPI.Logic.Interfaces;
using CoreBankAPI.Logic.Validator;
using CoreBankAPI.Models;

namespace CoreBankAPI.Logic
{
    public class UserManager : IUserManager
    {
        CoreDb db;
        ValidateRequest ValRequest;
        IUserRepository _userRepository;
        public UserManager(CoreDb db, ValidateRequest ValRequest, IUserRepository _userRepository) 
        {
            this.db = db;
            this.ValRequest = ValRequest;
            this._userRepository = _userRepository;
        }
        public (bool,ErrorModel, UserResponse) Insert(UserDto model)
        {
            ErrorModel userexist = new();
            var userFound = _userRepository.GetByIdNumber(model.Idnumber!, model.Idtype!);
            if (userFound != null) 
            {
               var responseUser = new UserResponse
                {
                    id = userFound.Id,
                    FirstName = userFound.FirstName,
                    MiddleName = userFound.MiddleName,
                    LastName = userFound.LastName,
                    LastName2 = userFound.LastName2

                };
                return (false, userexist, responseUser);

            }

            UserResponse response = new UserResponse();

            (bool iserror, var error) = ValRequest.ValidateModel(model);
            if (iserror) return (true, error, response);

            UserDta user = new UserDta
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                LastName2 = model.LastName2,
                Idtype = model.Idtype,
                Idnumber = model.Idnumber,
                Birthdate = model.Birthdate,
                Gender = model.Gender,
                Income = model.Income,
                Registered = DateTime.Now,
                Isactive = true,
            };
            _userRepository.add(user);
            db.SaveChanges();

            var userId = _userRepository.GetByIdNumber(model.Idnumber!, model.Idtype!);
             response = new UserResponse
            {
                id = userId.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                LastName2 = model.LastName2
            };

            return (false, error, response);
        }
    }
}
