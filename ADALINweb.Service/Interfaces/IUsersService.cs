using ADALINweb.Domain.Entity;
using ADALINweb.Domain.Response;
using ADALINweb.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADALINweb.Service.Interfaces
{
    public  interface IUsersService
    {
        Task<IBaseResponse<IEnumerable<Users>>> GetUsers();
        Task<IBaseResponse<Users>> GetUser(int id);
        Task<IBaseResponse<Users>> GetUserByName(string name);
        Task<IBaseResponse<bool>> DeleteUser(int id);
        Task<IBaseResponse<UserViewModel>> CreateUser(UserViewModel userViewModel);
        Task<IBaseResponse<Users>> Edit(int id, UserViewModel model);
    }
}
