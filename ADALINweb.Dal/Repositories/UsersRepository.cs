using ADALINweb.Dal.Interfaces;
using ADALINweb.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ADALINweb.Dal.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _db;

        public UsersRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Users entity)
        {
            _db.Users.Add(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Users entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Users> Get(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Users> GetByName(string name)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.FName == name);
        }

        public async Task<List<Users>> Select()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<Users> Update(Users entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
