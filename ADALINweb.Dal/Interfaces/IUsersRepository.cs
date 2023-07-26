using ADALINweb.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADALINweb.Dal.Interfaces
{
    public interface IUsersRepository:IBaseRepository<Users>
    {
        Task<Users> GetByName(string name);
    }
}
