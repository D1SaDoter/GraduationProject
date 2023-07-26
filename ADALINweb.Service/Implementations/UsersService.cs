using ADALINweb.Domain.Entity;
using ADALINweb.Domain.Response;
using ADALINweb.Service.Interfaces;
using ADALINweb.Dal.Interfaces;
using ADALINweb.Domain.Enum;
using ADALINweb.Domain.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.Reflection;
using System.Xml.Linq;

namespace ADALINweb.Service.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Users>>> GetUsers()
        {
            var baseResponse=new BaseResponse<IEnumerable<Users>>();
            try
            {
                var users = await _usersRepository.Select();
                if (users.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK; 
                    return baseResponse;
                }
                baseResponse.Data = users;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Users>>()
                {
                    Description = $"[GetUsers] : {ex.Message}"
                };
            }
            
        }
        public async Task<IBaseResponse<Users>> GetUser(int id)
        {
            var baseResponse=new BaseResponse<Users>();
            try
            {
                var user = await _usersRepository.Get(id);
                if (user == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                baseResponse.Data= user;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Users>()
                {
                    Description = $"[GetUser] : {ex.Message}"
                };
            }
        }
        public async Task<IBaseResponse<Users>> GetUserByName(string name)
        {
            var baseResponse = new BaseResponse<Users>();
            try
            {
                var user = await _usersRepository.GetByName(name);
                if (user == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                baseResponse.Data = user;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Users>()
                {
                    Description = $"[GetUserByName] : {ex.Message}",
                    StatusCode = StatusCode.UserNotFound
                };
            }
        }
        public async Task<IBaseResponse<bool>> DeleteUser(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var user = await _usersRepository.Get(id);
                
                if (user == null)
                {
                    baseResponse.Description = "User not found";
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                await _usersRepository.Delete(user);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteUser] : {ex.Message}", 
                    StatusCode=StatusCode.UserNotFound
                    
                };
            }
        }
        public async Task<IBaseResponse<UserViewModel>> CreateUser(UserViewModel userViewModel)
        {
            var baseResponse = new BaseResponse<UserViewModel>();
            try
            {
                var user = new Users()
                {
                    Role = userViewModel.Role,
                    Login = userViewModel.Login,
                    Password = userViewModel.Password,
                    FName = userViewModel.FName,
                    SName = userViewModel.SName,
                    OName = userViewModel.OName,
                    Gender=userViewModel.Gender,
                    Department=userViewModel.Department,
                    DateOfBirth=userViewModel.DateOfBirth,
                    DateOfAccept=userViewModel.DateOfAccept,
                    DateOfKick=userViewModel.DateOfKick,
                    WorkingTime=userViewModel.WorkingTime,
                    Salary=userViewModel.Salary,
                    Inn=userViewModel.Inn,
                    Snils=userViewModel.Snils,
                    SerialNumberOfPassport=userViewModel.SerialNumberOfPassport,
                    NumberOfPassport=userViewModel.NumberOfPassport,
                    IssuedBy=userViewModel.IssuedBy,
                    DateOfIssued=userViewModel.DateOfIssued,
                    Citizenship=userViewModel.Citizenship,
                    Registration=userViewModel.Registration,
                    Addres=userViewModel.Addres,
                    Mail=userViewModel.Mail,
                    FirstPhoneNumber=userViewModel.FirstPhoneNumber,
                    SecondPhoneNumber=userViewModel.SecondPhoneNumber,
                    BikOfBank=userViewModel.BikOfBank,
                    CheckingNumber=userViewModel.CheckingNumber,
                    Description=userViewModel.Description,
                    Image=userViewModel.Image

                };
                await _usersRepository.Create(user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserViewModel>()
                {
                    Description = $"[CreateUser] : {ex.Message}",
                    StatusCode = StatusCode.UserNotFound

                };
            }
            return baseResponse;
        }
        public async Task<IBaseResponse<Users>> Edit(int id, UserViewModel model)
        {
            var baseResponse = new BaseResponse<Users>();
            try
            {
                var user = await _usersRepository.Get(id);
                if (user == null)
                {
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Description = "User not found";

                }
                user.Role = model.Role;
                user.Login = model.Login;
                user.Password = model.Password;
                user.FName = model.FName;
                user.SName = model.SName;
                user.OName = model.OName;
                user.Gender = model.Gender;
                user.Department = model.Department;
                user.DateOfBirth = model.DateOfBirth;
                user.DateOfAccept = model.DateOfAccept;
                user.DateOfKick = model.DateOfKick;
                user.WorkingTime = model.WorkingTime;
                user.Salary = model.Salary;
                user.Inn = model.Inn;
                user.Snils = model.Snils;
                user.SerialNumberOfPassport = model.SerialNumberOfPassport;
                user.NumberOfPassport = model.NumberOfPassport;
                user.IssuedBy = model.IssuedBy;
                user.DateOfIssued = model.DateOfIssued;
                user.Citizenship = model.Citizenship;
                user.Registration = model.Registration;
                user.Addres = model.Addres;
                user.Mail = model.Mail;
                user.FirstPhoneNumber = model.FirstPhoneNumber;
                user.SecondPhoneNumber = model.SecondPhoneNumber;
                user.BikOfBank = model.BikOfBank;
                user.CheckingNumber = model.CheckingNumber;
                user.Description = model.Description;
                user.Image = model.Image;

                await _usersRepository.Update(user);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Users>()
                {
                    Description = $"[Edit] : {ex.Message}",
                    StatusCode = StatusCode.UserNotFound

                };
            }
            return baseResponse;
        }
    }
}
